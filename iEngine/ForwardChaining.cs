using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEngine
{
    public class ForwardChaining : SearchMethod
    {
        private string _query;
        private List<string> _true;
        public ForwardChaining(List<string> kb, string query) : base(kb)
        {
            code = "FC";
            longName = "ForwardChaining";
            _query = query;
            _true = new List<string>();
            
        }
        /// <summary>
        /// print the solution from the true list
        /// </summary>
        /// <param name="result"></param>

        private void GetSolution(bool result)
        {
            Console.WriteLine(longName + " : " + code);
            if (result)
            {
                Console.WriteLine("Yes: "+ string.Join(",", _true));
            }
            else
            {
                Console.WriteLine("NO:");
            }
        }
        public override void Solve()
        {
            bool result = false;
            bool valid = false;

            //loop until to find the solution
            while (!result)
            {
                bool added = false;
                char[] delimiters = new char[] { '=', '>' };
                
                foreach(string item in _kb)// splits the Kb list each item with => and checks the length to find the query or add it into _true list
                {
                    
                    string[] items = item.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                    if (item.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length == 1)
                    {
                        valid = true;
                        if (valid)
                        {
                            if (!_true.Contains(item))
                            {
                                added = true;
                                _true.Add(item);
                            }
                            if (item.Equals(_query))
                            {
                                result = true;
                                break;
                            }
                        }
                        
                    }
                    if (items.Length == 2)
                    {
                        valid = true;
                        
                        foreach (string Var in items[0].Split('&'))
                        {
                            //if the variable is not known the rule cant be proven
                            if (!_true.Contains(Var))
                            {
                                valid = false;
                                break;
                            }
                        }

                        if (valid)
                        {
                            if (!_true.Contains(items[1]))//check if the _true list contains the implies value
                            {
                                added = true;
                                _true.Add(items[1]); //add the implie value in the _true list 
                            }
                            if (items[1].Equals(_query))// check the added value in the _true list is equal to the query
                            {
                                result = true;
                                break;
                            }
                        }
                    }
                }
                if (!added)
                {
                    break;
                }
            }
            GetSolution(result);
        }
    }
}
