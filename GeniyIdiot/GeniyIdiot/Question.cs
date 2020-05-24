using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniyIdiot
{
    class Question
    {
        string text = "";
        int answer = 0;

        public Question(string text, int answer)
        {
            this.text = text;
            this.answer = answer;
        }
        public int Answer()
        {
            return answer;
        }
        public string ShowQuestion
        {
            get { return text; }
        }
    }
}
