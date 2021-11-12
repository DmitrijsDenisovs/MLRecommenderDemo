using MLWithRealataConsoleApp.Models;
using MLWithRealataConsoleApp.Models.MLPipeline;
using MLWithRealataConsoleApp.Models.Database;
using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using MLWithRealataConsoleApp.Models.FileManipulators;

namespace MLWithRealataConsoleApp
{
    class Program
    {

        private static List<Transaction> Transactions { get; set; }
        private static List<int> GlobalProductIds { get; set; }
        private static Dictionary<Tuple<int, int>, double> PairToLiftDictionary { get; set; }
        private static MLModelPipeline MLModelPipeline { get; set; }
        private static MaxedBuyContext DbContext { get; set; }

        static void Main(string[] args)
        {
            DbContext = new MaxedBuyContext();
            Transactions = new List<Transaction>();
            GlobalProductIds = new List<int>();
            PairToLiftDictionary = new Dictionary<Tuple<int, int>, double>();
            MLModelPipeline = new MLModelPipeline();

            PrepareData();

            MLModelPipeline.CreateAndTrainModel();
            MLModelPipeline.SaveModel();

            Random rand = new Random();
            for (int i = 0; i < 2; i++)
            {
                int firstProductId = GlobalProductIds[rand.Next(GlobalProductIds.Count)];
                int secondProductId = GlobalProductIds[rand.Next(GlobalProductIds.Count)];
                float score = MLModelPipeline.MakeSinglePrediction(firstProductId, secondProductId);

                Console.WriteLine("Lift of ( " + firstProductId + "; " + secondProductId + " ) is " + score);

                Dictionary<int, float> idToLift = MLModelPipeline.GetRelevantProductList(firstProductId, GlobalProductIds);

                Console.WriteLine("Top 5 for " + firstProductId + ": ");
                foreach (KeyValuePair<int, float> pair in idToLift.Take(5))
                {
                    Console.WriteLine("Id: " + pair.Key + "; Lift: " + pair.Value);
                }
            }

            Console.WriteLine("END OF PROGRAM");
        }

        private static void PrepareData()
        {
            TransactionReader transactionReader = new TransactionReader();
            Transactions = transactionReader.ReadFile();
            transactionReader.CloseFile();

            GlobalProductIds = DbContext.OrderProducts
               .Where(orderProduct => orderProduct.ProductId != null)
               .Select(orderProduct => (int)orderProduct.ProductId).Distinct().ToList();

            List<int> unpairedProductIds = GlobalProductIds;

            List<Transaction> transactionsWithMoreProducts = Transactions.Where(transaction => transaction.ProductIds.Count > 1).ToList();

            foreach (Transaction transaction in transactionsWithMoreProducts)
            {
                for (int i = 0; i < transaction.ProductIds.Count; i++)
                {
                    for (int j = i + 1; j < transaction.ProductIds.Count; j++)
                    {
                        Tuple<int, int> productPair = new Tuple<int, int>(transaction.ProductIds[i], transaction.ProductIds[j]);

                        if (!PairToLiftDictionary.ContainsKey(productPair))
                        {
                            unpairedProductIds.Remove(productPair.Item1);
                            unpairedProductIds.Remove(productPair.Item2);

                            long firstIdCount = Transactions
                                .Where(transaction => transaction.ProductIds.Contains(productPair.Item1))
                                .LongCount();
                            long secondIdCount = Transactions
                                .Where(transaction => transaction.ProductIds.Contains(productPair.Item2))
                                .LongCount();
                            long firstAndSecondIdCount = transactionsWithMoreProducts
                                .Where(transaction => transaction.ProductIds.Contains(productPair.Item2) && transaction.ProductIds.Contains(productPair.Item1))
                                .LongCount();
                            long transactionCount = Transactions.LongCount();

                            double lift = (firstAndSecondIdCount * transactionCount) / (firstIdCount * secondIdCount);

                            PairToLiftDictionary.Add(productPair, lift);
                            Console.WriteLine(productPair.Item1 + " - " + productPair.Item2 + "; Lift - " + lift);
                        }
                    }
                }
            }

            CombinedProductWriter writer = new CombinedProductWriter();
            writer.WritePairToLift(PairToLiftDictionary);

            PairToLiftDictionary = new Dictionary<Tuple<int, int>, double>();

            for (int i = 0; i < unpairedProductIds.Count - 1; i++)
            {
                PairToLiftDictionary.Add(new Tuple<int, int>(unpairedProductIds[i], unpairedProductIds[i + 1]), 0);
            }

            writer.WritePairToLift(PairToLiftDictionary);
            writer.CloseFile();
        }
    }  
}
