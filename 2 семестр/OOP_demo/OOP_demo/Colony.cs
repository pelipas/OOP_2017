using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_demo
{
    class Colony
    {
        private string _name;

        public Colony(string name)
        {
            _name = name;
        }

        public string GetName()
        {
            return _name;
        }
    }
}
