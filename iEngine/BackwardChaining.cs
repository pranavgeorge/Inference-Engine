using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEngine
{
    public class BackwardChaining : SearchMethod
    {
        private List<string> _true;
        private List<string> knowledgeBase;
        private string _query;
        public BackwardChaining(List<string> kb, string query) : base(kb)
        {
            code = "BC";
            longName = "BackwardChaining";
            _true = new List<string>();
            knowledgeBase = new List<string>();
            _query = query;
            TrueValues();
        }
        private void TrueValues()
        {

            char[] delimiters = new char[] { '=', '>' };
            foreach (string item in _kb)
            {
                if (item.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length == 1)
                {
                    _true.Add(item);
                }
            }
        }
        private void GetSolution(bool result)
        {
            Console.WriteLine(longName + " : " + code);
            char[] delimiters = new char[] { '=', '>' };

            if (result)
            {
                HashSet<string> set = new HashSet<string>();
                foreach (string item in knowledgeBase)
                {
                    string[] val = item.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                    if (val.Length == 1)
                    {
                        set.Add(val[0]);
                    }
                    else
                    {
                        set.Add(val[1]);
                    }
                }
                
                Console.WriteLine("Yes: " + string.Join(",", set.Reverse()));
            }
            else
            {
                Console.WriteLine("NO:");
            }
        }
        /// <summary>
        /// calling this function will start the Backward chaining algorithm and prints the result
        /// </summary>
        public override void Solve()
        {
            bool result = false;
            //if the query is already known to be true
            if (_true.Contains(_query))
            {
                knowledgeBase.Add(_query);
                result = true;
            }
            else
            {
                // discover all the unknown variables which relates to the query
                result = Explore(_query);
            }
            GetSolution(result);
        }

        private bool Explore(string currentQuery)
        {
            bool result = false;
            char[] delimiters = new char[] { '=', '>' };
            // for every rule in KB
            foreach (string clause in _kb)
            {
                string[] items = clause.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                if (items.Length == 2)
                {
                    if (currentQuery.Equals(items[1]))
                    {
                        // repeat checking
                        if (knowledgeBase.Contains(clause))
                        {
                            continue;
                        }
                        else
                        {
                            knowledgeBase.Add(clause);
                        }
                        // every variable on the left side of implication
                        foreach (string val in items[0].Split('&'))
                        {
                            if (!_true.Contains(val))
                            {
                                // if any val on left side is false then the rule is false
                                if (!Explore(val))
                                {
                                    result = false;
                                    continue;
                                }
                                _true.Add(val); // add val to the true list
                            }
                            else
                            {
                                knowledgeBase.Add(val);
                            }
                        }
                        // all variable pass return true
                        result = true;
                    }
                }
            }
            // no matching rule found for this val
            return result;
        }
    }
}
