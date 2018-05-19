using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEngine
{
    public abstract class SearchMethod
    {
        public string code;             //the code used to identify the method at the command line
        public string longName;			//the actual name of the method.
        protected List<string> _kb;
        public SearchMethod(List<string> kb)
        {
            _kb = kb;
        }
        public abstract void Solve();
    }
}
