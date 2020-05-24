using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;


namespace GeniyIdiot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            var fileResultsOfTest = new FileResults();
            fileResultsOfTest.CreatinFileOfResults();
            while (true)
            {
                var questionService = new QuestionService();
                var questions = questionService.GetQuestions();
                var numberOfQuestions = questions.Count;
                var inputsProvider = new InputsProvider();
                var user = inputsProvider.GetUserData();

                for (var i = 0; i < numberOfQuestions; i++)
                {
                    Console.WriteLine($"Вопрос номер {i + 1}:" +
                        $"{Environment.NewLine}{questions[i].ShowQuestion}");
                    if (questions[i].Answer() == inputsProvider.GetUserAnswer())
                        user.Result++;
                }
                var diagnose = new DiagnoseService();

                user.Diagnose = diagnose.GetDiagnose(user, numberOfQuestions);
                Console.WriteLine($"Количество правильных ответов: {user.Result}.");
                Console.Write($"{user.ReturnFIO},{Environment.NewLine}Ваш диагноз: " +
                    $"{user.Diagnose}{Environment.NewLine}");
                fileResultsOfTest.WriteToFileOfResults(user);
                Console.WriteLine("Вывести результаты предыдущих тестирований? y/n?");
                var keySymb = '\0';
                keySymb = inputsProvider.GetUserAnswer(keySymb);
                fileResultsOfTest.ShowResultsOfTests(keySymb);
                keySymb = '\0';
                Console.WriteLine("Вы хотите пройти тест заново? y/n");
                if (inputsProvider.GetUserAnswer(keySymb) == 'y')
                {
                    Console.Clear();
                    continue;
                }
                else
                    break;
            }
        }
    }
}