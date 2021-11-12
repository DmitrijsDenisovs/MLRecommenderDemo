using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MLWithRealataConsoleApp.Models.FileManipulators
{
    public class CombinedProductWriter
    {
        private StreamWriter Writer { get; set; }
        public CombinedProductWriter()
        {
            string dataPath = Path.Combine("C:\\Users\\dod30\\source\\repos\\MLWithRealDataConsoleAppAugmented\\MLWithRealataConsoleApp\\Data", "PairToLift.txt");
            Writer = new StreamWriter(dataPath);
            Writer.WriteLine("ProductId\tCombinedId\tLift");
        }

        ~CombinedProductWriter()
        {
            CloseFile();
        }

        public void WritePairToLift(Dictionary<Tuple<int, int>, double> productPairToLiftDictionary)
        {
            foreach (KeyValuePair<Tuple<int, int>, double> pairToLift in productPairToLiftDictionary)
            {
                if (pairToLift.Value != 0) {
                    Writer.WriteLine(pairToLift.Key.Item1 + "\t" + pairToLift.Key.Item2 + "\t" + pairToLift.Value);
                    Writer.WriteLine(pairToLift.Key.Item2 + "\t" + pairToLift.Key.Item1 + "\t" + pairToLift.Value);
                } 
                else
                {
                    Writer.WriteLine(pairToLift.Key.Item1 + "\t" + pairToLift.Key.Item2 + "\t");
                    Writer.WriteLine(pairToLift.Key.Item2 + "\t" + pairToLift.Key.Item1 + "\t");
                }
            }
        }

        public void CloseFile()
        {
            Writer.Close();
        }

        public void Flush()
        {
            Writer.Flush();
        }
    }
}
