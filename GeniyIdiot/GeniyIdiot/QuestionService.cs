using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniyIdiot
{
    class QuestionService
    {

       
       
        private List<Question> Questions = new List<Question>
        {
            new Question("Сколько будет два плюс два умножить на два?", 6),
            new Question("Бревно надо распелить на 10 частей сколько нужно сделать распилов?", 9),
            new Question("На двух руках 10 пальцев. Сколько пальцев на 5 руках?", 25),
            new Question("Укол делают каждые полчаса, сколько потребуется времени для 3-х уколов?", 60),
            new Question("Пять свечей горело, две потухло. Сколько свечей осталовь?", 2)
        };
        
       
        private int GetRandomValue(int numberOfQuestions)
        {
            var random = new Random();
            var randomValue = random.Next(0, numberOfQuestions);
            return randomValue;
        }

        public List<Question> GetQuestions()
        {
            var questionOut = new List<Question>();
            var numberOfQuestions = Questions.Count;
            for(int i = 0; i < numberOfQuestions; i++)
            {
                var rand = GetRandomValue(Questions.Count);
                questionOut.Add(Questions[rand]);
                Questions.RemoveAt(rand);
            }
            return questionOut;
        }


    }
}
