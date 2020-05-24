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
            if (!File.Exists(path))
                CreateFileResultsOfTests(path);
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

                var fileInput = string.Format("{0, -25} {1,-30} \t{2, -12}", user.ReturnFIO,
                    user.Result, user.Diagnose);

                WriteToFileResultsOfTests(path, fileInput);

                Console.WriteLine("Вывести результаты предыдущих тестирований? y/n?");
                var keySymd = '\0';
                keySymd = inputsProvider.GetUserAnswer(keySymd);

                ShowResultsOfTests(path, keySymd);

                keySymd = '\0';
                Console.WriteLine("Вы хотите пройти тест заново? y/n");
                if (inputsProvider.GetUserAnswer(keySymd) == 'y')
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
        
        //static string ReturnDiagnose(List<Diagnose> diagnoses, int result)
        //{
        //    return diagnoses[result].ShowDiagnose();
        //}
        //static int GetNumberOfDiagnose(int countRigthAnswers, int numberOfQuetions, int numberOfDiagnoses)
        //{
        //    var result = 0;
        //    if (countRigthAnswers == 0)
        //        return 0;
        //    else
        //    {
        //        var rate = (double)numberOfQuetions / numberOfDiagnoses;
        //        for (var i = numberOfDiagnoses; i > 0; i--)
        //        {
        //            if (countRigthAnswers <= (rate * i) && countRigthAnswers > (rate * (i - 1)))
        //                result = i - 1;
        //        }
        //    }
        //    return result;
        //}
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