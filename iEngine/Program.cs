using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace iEngine
{
    public class Program
    {
        public static string _kb;
        public static string _query;
        public static void Main(string[] args)
        {
            //args contains:
            //  [0] - method name
            //  [1] - filename

            if (args.Length < 2)
            {
                Console.WriteLine("Usage: iengine <search-method> <FileName>.");
                Environment.Exit(1);
            }
            string method = args[0];
            string path = args[1];
            
            if (ReadFromFile(path))
            {
                InferenceEngine engine = new InferenceEngine(_kb, _query);

                engine.Solve(method);
                //Console.ReadLine();
               Environment.Exit(0);
            }

        }

        public static bool ReadFromFile(string FileName)
        {

            List<string> inputRows = new List<string>();
            try
            {
                StreamReader file = null;
                file = new StreamReader(FileName);
                string line = file.ReadLine();
                if (line.Equals("TELL")){
                    inputRows.Add(file.ReadLine());
                    _kb = inputRows[0];
                }
                line = file.ReadLine();
                if (line.Equals("ASK"))
                {
                    inputRows.Add(file.ReadLine());
                    _query = inputRows[1];
                }
                file.Close();
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine("Error: Couldn't locate the file " + FileName + "."+ ex);
                return false;
            }
            
            return true;

        }
    }
}
