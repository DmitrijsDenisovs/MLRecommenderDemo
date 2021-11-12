using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MLWithRealataConsoleApp.Models.FileManipulators
{
    public class TransactionReader
    {
        private StreamReader Reader { get; set; }
        public TransactionReader()
        {
            string dataPath = "C:\\Users\\dod30\\source\\repos\\MLWithRealDataConsoleAppAugmented\\MLWithRealataConsoleApp\\Data\\Transactions.txt";
            Reader = new StreamReader(dataPath);
        }

        ~TransactionReader()
        {
            CloseFile();
        }

        public List<Transaction> ReadFile()
        {
            List<Transaction> transactions = new List<Transaction>();
            
            while (!Reader.EndOfStream)
            {
                string line = Reader.ReadLine().Trim();
                Transaction transaction = new Transaction {
                    ProductIds = new List<int>()
                };
                foreach (string idString in line.Split('\t'))
                {
                    transaction.ProductIds.Add(Int32.Parse(idString));
                }
                transactions.Add(transaction);
            }
            return transactions;
        }

        public void CloseFile()
        {
            Reader.Close();
        }
    }
}
