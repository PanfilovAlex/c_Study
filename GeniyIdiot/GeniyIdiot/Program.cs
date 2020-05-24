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
            var path = $"{Environment.CurrentDirectory}\\ResultsOfTests.txt";
            //var path1 = $"{Environment.CurrentDirectory}\\Questions.txt";
            //var quest = new List<string>();
            //string[] line = File.ReadAllLines(path1);
            
            //foreach(var i in line)
            //{
            //    Console.WriteLine(i);
            //}
            if (!File.Exists(path))
                CreateFileResultsOfTests(path);
            while (true)
            {
                var questions = GetQuestions();
                var numberOfQuestions = questions.Count;
                User user = new User();
                user.InputFirstName();
                user.InputSecondName();
                user.InputLastName();
                for (var i = 0; i < numberOfQuestions; i++)
                {
                    var randomValue = GetRandomValue(questions.Count);
                    Console.WriteLine($"Вопрос номер {i + 1}:" +
                        $"{Environment.NewLine}{questions[randomValue].ShowQuestion}");
                    if (questions[randomValue].Answer() == user.GetUserAnswer())
                        user.Result++;
                    questions.RemoveAt(randomValue);
                }
                user.Diagnose = ReturnDiagnose(GetDiagnose(), GetNumberOfDiagnose(user.Result,
                    numberOfQuestions, GetDiagnose().Count));
                Console.WriteLine($"Количество правильных ответов: {user.Result}.");
                Console.Write($"{user.ReturnFIO},{Environment.NewLine}Ваш диагноз: " +
                    $"{user.Diagnose}{Environment.NewLine}");

                var fileInput = string.Format("{0, -25} {1,-30} \t{2, -12}", user.ReturnFIO,
                    user.Result, user.Diagnose);

                WriteToFileResultsOfTests(path, fileInput);

                Console.WriteLine("Вывести результаты предыдущих тестирований? y/n?");
                var keySymd = '\0';
                keySymd = user.GetUserAnswer(keySymd);

                ShowResultsOfTests(path, keySymd);

                keySymd = '\0';
                Console.WriteLine("Вы хотите пройти тест заново? y/n");
                if (user.GetUserAnswer(keySymd) == 'y')
                {
                    Console.Clear();
                    continue;
                }
                else
                    break;
            }
        }
        static void CreateFileResultsOfTests(string path)
        {
            var head = string.Format("{0, -25} {1, -30} \t{2, -12}", "ФИО:", "Количество правильных ответов:", "Ваш диагноз:");
            var fileResults = new FileStream(path, FileMode.OpenOrCreate);
            var resultsOfTests = new StreamWriter(fileResults, Encoding.UTF8); ;
            resultsOfTests.WriteLine(head);
            resultsOfTests.Dispose();
            fileResults.Close();
        }
        static List<Question> GetQuestions()
        {
            var questions = new List<Question>();
            questions.Add(new Question("Сколько будет два плюс два умножить на два?", 6));
            questions.Add(new Question("Бревно надо распелить на 10 частей сколько нужно сделать распилов?", 9));
            questions.Add(new Question("На двух руках 10 пальцев. Сколько пальцев на 5 руках?", 25));
            questions.Add(new Question("Укол делают каждые полчаса, сколько потребуется времени для 3-х уколов?", 60));
            questions.Add(new Question("Пять свечей горело, две потухло. Сколько свечей осталовь?", 2));
            return questions;
        }
        static List<Diagnose> GetDiagnose()
        {
            var diagnoses = new List<Diagnose>();
            diagnoses.Add(new Diagnose("Идиот"));
            diagnoses.Add(new Diagnose("Кретин"));
            diagnoses.Add(new Diagnose("Дурак"));
            diagnoses.Add(new Diagnose("Нормальный"));
            diagnoses.Add(new Diagnose("Талант"));
            diagnoses.Add(new Diagnose("Гений"));
            return diagnoses;
        }
        static int GetRandomValue(int numberOfQuestions)
        {
            var random = new Random();
            var randomValue = random.Next(0, numberOfQuestions);
            return randomValue;
        }
        static string ReturnDiagnose(List<Diagnose> diagnoses, int result)
        {
            return diagnoses[result].ShowDiagnose();
        }
        static int GetNumberOfDiagnose(int countRigthAnswers, int numberOfQuetions, int numberOfDiagnoses)
        {
            var result = 0;
            if (countRigthAnswers == 0)
                return 0;
            else
            {
                var rate = (double)numberOfQuetions / numberOfDiagnoses;
                for (var i = numberOfDiagnoses; i > 0; i--)
                {
                    if (countRigthAnswers <= (rate * i) && countRigthAnswers > (rate * (i - 1)))
                        result = i - 1;
                }
            }
            return result;
        }
        static void WriteToFileResultsOfTests(string path, string fileInput)
        {
            try
            {
                using (FileStream fileStream = new FileStream(path, FileMode.Append))
                {
                    using (StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.UTF8))
                    {
                        streamWriter.WriteLine(fileInput);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void ShowResultsOfTests(string path, char keySymb)
        {
            if (keySymb == 'y')
            {
                Console.WriteLine("Результаты тестирования: ");
                try
                {
                    using (StreamReader readerResultsOfTests = new StreamReader(path))
                    {
                        Console.WriteLine(readerResultsOfTests.ReadToEnd());
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }
    }
}