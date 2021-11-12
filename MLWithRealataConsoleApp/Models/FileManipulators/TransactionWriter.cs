using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MLWithRealataConsoleApp.Models.Database;

namespace MLWithRealataConsoleApp.Models.FileManipulators
{
    public class TransactionWriter
    {
        private StreamWriter Writer { get; set; }
        public TransactionWriter()
        {
            string dataPath = "C:\\Users\\dod30\\source\\repos\\MLWithRealDataConsoleAppAugmented\\MLWithRealataConsoleApp\\Data\\Transactions.txt";
            Writer = new StreamWriter(dataPath);
        }

        ~TransactionWriter()
        {
            CloseFile();
        }

        public void WriteTransactions(List<Order> orders, List<OrderProduct> orderProducts)
        {
            List<Transaction> transactions = new List<Transaction>();
            foreach (Order order in orders)
            {
                transactions.Add(new Transaction {
                    Id = order.Id,
                    ProductIds = new List<int>()
                });
            }

            foreach (OrderProduct orderProduct in orderProducts)
            {
                if (orderProduct.ProductId != null)
                {
                    transactions.Where(transaction => transaction.Id == orderProduct.OrderId).First().ProductIds.Add((int) orderProduct.ProductId);
                }
            }

            transactions.RemoveAll(transaction => transaction.ProductIds.Count < 1);

            foreach (Transaction transaction in transactions.ToList())
            {
                bool isFirst = true;
                foreach (int id in transaction.ProductIds)
                {
                    if (isFirst)
                    {                   
                        Writer.Write(id);
                        isFirst = false;
                    }
                    else
                    {
                        Writer.Write("\t" + id);
                    }
                }
                Writer.Write("\n");
            }
        }

        public void Flush()
        {
            Writer.Flush();
        }

        public void CloseFile()
        {
            Writer.Close();
        }
    }
}
