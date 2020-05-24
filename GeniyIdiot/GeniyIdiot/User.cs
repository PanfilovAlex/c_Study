using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniyIdiot
{
    class User
    {
        private string firstName;
        private string secondName;
        private string lastName;
        private int result;
        private string diagnose;

        public User() { }
        public User(string firstName, string secondName, string lastName)
        {
            this.firstName = firstName;
            this.secondName = secondName;
            this.lastName = lastName;
        }

        public string ReturnFIO
        {
            get
            {
                return $"{lastName} {GetFirstLetter(firstName)} {GetFirstLetter(secondName)}";
            }
        }

        
        private string GetFirstLetter(string name)
        {
            string firstLetter;
            if (name.Length < 1)
                firstLetter = name;
            else
                firstLetter = name[0] + ".";
            return firstLetter;
        }
        public string Diagnose
        {
            get
            {
                return diagnose;
            }
            set
            {
                diagnose = value;
            }
        }
        public int Result
        {
            get
            {
                return result;
            }
            set
            {
                result = value;
            }
        }

    }
}
