using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GeniyIdiot
{
    class Diagnose
    {
        private string diagnose;
        static public int id;
        public Diagnose(string diagnose)
        {
            this.diagnose = diagnose;
            id++;
        }

        public string ShowDiagnose()
        {
            return diagnose;
        }

        
    }
}
