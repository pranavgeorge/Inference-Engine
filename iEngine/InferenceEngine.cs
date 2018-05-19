using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEngine
{
    public class InferenceEngine
    {
        private List<string> KB;
        private string _Query;
        private List<string> _variables;

        public InferenceEngine(string kb,string query)
        {
            KB = new List<string>();
            _variables = new List<string>();
            if (kb.Contains(";"))
            {
                kb = RemoveSpace(kb);
                _Query = RemoveSpace(query);
            }
            char[] delimiters = new char[] { ';' };
            string[] kbValues = kb.Split(delimiters,StringSplitOptions.RemoveEmptyEntries);
            foreach(string it in kbValues)
            {
                KB.Add(it);
            }
            Variables();
        }
        /// <summary>
        /// add all the variables present in the KB list to _variable list to use it for truth table
        /// </summary>
        private void Variables()
        {
            char[] delimiters = new char[] { '=', '>' };
            foreach(string item in KB)
            {
                foreach(string item1 in item.Split(delimiters,StringSplitOptions.RemoveEmptyEntries))
                {
                    foreach(string variable in item1.Split('&'))
                    {
                        if (_variables.Contains(variable))
                        {
                            continue;
                        }
                        _variables.Add(variable);
                    }
                }
            }
        }
        /// <summary>
        /// remove all the space in the kb string passed
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string RemoveSpace(string str)
        {
            string[] items = str.Split(' ');
            string result = "";
            foreach(string item in items)
            {
                result += item;
            }
            return result;
        }

        /// <summary>
        /// solve the specific method asked by the user
        /// </summary>
        /// <param name="method"></param>
        public void Solve(string method)
        {
            SearchMethod search;
            switch (method)
            {
                case "FC":
                    search = new ForwardChaining(KB,_Query);
                    break;
                case "BC":
                    search = new BackwardChaining(KB, _Query);
                    break;
                case "TT":
                    search = new TruthTable(KB, _Query, _variables);
                    break;
                default:
                    search = null;
                    
                    break;
            }
            if(search == null)
            {
                Console.WriteLine("Method case are sensitive, Enter TT, FC or BC");
                Environment.Exit(1);
            }
            else
            {
                search.Solve();
            }
        }
    }
}
