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
        public Diagnose(string diagnose)
        {
            this.diagnose = diagnose;
        }

        public string ShowDiagnose 
        {
            get
            {
                return diagnose;
            }
        }

        
    }
}
