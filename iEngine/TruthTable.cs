using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEngine
{
    public class TruthTable : SearchMethod
    {
        private List<string> _variables;
        private string _alpha;
        private bool[,] _truthTable;
        public TruthTable(List<string> kb, string query,List<string> variables): base(kb)
        {
            code = "TT";
            longName = "TruthTable";
            _alpha = query;
            _variables = variables;
            InitTT(_variables.Count);
        }
        /// <summary>
        /// Initialize the truth table in 2D array with total variables as totalvar is the number of col in the truth table
        /// </summary>
        /// <param name="totalVar"></param>
        private void InitTT(int totalVar)
        {
            int truthTableSize = (int)Math.Pow(2, totalVar);
            _truthTable = new bool[truthTableSize,totalVar];

            for(int i = 0; i < truthTableSize; i++)
            {
                string binaryRow = Convert.ToString(i,2).PadLeft(totalVar,'0');// convert the integer to binary string with padleft function that adds zeros to the left of totalvar
                
                for(int j = 0; j < totalVar; j++)
                {
                    if(binaryRow[j] == '1')
                    {
                        _truthTable[i, j] = true;
                    }
                    else
                    {
                        _truthTable[i, j] = false;
                    }
                }
            }
        }
        /// <summary>
        /// find the column number of the variable
        /// </summary>
        /// <param name="var"></param>
        /// <returns>column position of the variable</returns>
        private int Indexof(string var)
        {
            for(int i = 0; i < _variables.Count; i++)
            {
                if (_variables[i].Equals(var))
                {
                    return i;
                }
            }

            return Convert.ToInt32(null) ;
        }
        /// <summary>
        /// prints the solution
        /// </summary>
        /// <param name="result"></param>
        /// <param name="count"></param>
        private void GetSolution2(bool result, int count)
        {
            Console.WriteLine(longName + " : " + code);
            if (!result)
            {
                Console.WriteLine("No:");
                
            }
            else
            {
                Console.WriteLine("Yes: "+ count);

            }
        }
        /// <summary>
        /// print the row number
        /// </summary>
        /// <param name="row"></param>
        private void GetSolution(int row)
        {
            Console.Write("Row:" + row);
            for (int col = 0; col < _variables.Count; col++)
            {
                string value = Convert.ToString(_truthTable[row, col]);

                Console.Write(" " + _variables[col] + "=" + value);
            }
            Console.Write(Environment.NewLine);
        }
        public override void Solve()
        {
            int count = 0;// number of times KB|= alpha
            bool result;
            bool KbAlpha = true;
            char[] delimiters = new char[] { '=', '>' };
            for (int i = 0; i < _truthTable.GetLength(0); i++)
            {
                result = true;
                //check every clause
                foreach(string item in _kb)
                {
                    string[] items = item.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                    if(items.Length == 2)
                    {
                        string[] lVars = items[0].Split('&');// find the variable on the left hand side of the implication
                        string[] rVars = items[1].Split('&');// find the variable on the right hand side of the implication
                        int[] varIndex = new int[lVars.Length];
                        int[] currIndex = new int[rVars.Length];

                        for(int j = 0; j < lVars.Length; j++)
                        {
                            
                            varIndex[j] = Indexof(lVars[j]);
                        }
                        for(int k = 0; k < currIndex.Length; k++)
                        {
                            currIndex[k] = Indexof(rVars[k]);
                        }
                        bool leftSide = false;
                        foreach(int col in varIndex)
                        {
                            //check if any of them is false
                            if (_truthTable[i,col] == false)
                            {
                                leftSide = false;
                                break;
                            }
                            else
                            {
                                leftSide = true;
                            }
                        }
                        if(leftSide == true)
                        {
                            foreach(int col in currIndex)
                            {
                                if(_truthTable[i,col] == false)
                                {
                                    result = false;
                                }
                            }
                        }
                    }
                    else
                    {
                        // if the kb length is equal to 1
                        string[] rVars = items[0].Split('&'); 
                        int[] currIndex = new int[rVars.Length];
                        for(int k = 0; k < currIndex.Length; k++)
                        {
                            currIndex[k] = Indexof(rVars[k]);
                        }
                        foreach(int col in currIndex)
                        {
                            if(_truthTable[i,col] == false)
                            {
                                result = false;
                            }
                        }
                    }
                }
                if(result == true)
                {
                    if (!_alpha.Contains("~"))
                    {
                        if(!ReferenceEquals( Indexof(_alpha),null) && _truthTable[i,Indexof(_alpha)]){
                            GetSolution(i); // testing purpose
                            count++;
                        }
                        else
                        {
                            KbAlpha = false;
                            break;
                        }
                    }
                    else
                    {
                        string var = _alpha.Substring(1);
                        if (!ReferenceEquals(Indexof(var), null) && !_truthTable[i, Indexof(var)])
                        {
                            GetSolution(i); //testing purpose
                            count++;
                        }
                        else
                        {
                            KbAlpha = false;
                            break;
                        }
                    }
                }
            }
            GetSolution2(KbAlpha, count);

        }
    }
}
