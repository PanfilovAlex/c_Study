using System;
using System.Globalization;
using System.IO;
using System.Text;

/// <summary>
/// Добаввить вывод текстового файла с результатами теситрования
/// </summary>

namespace GeniyIdiot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            int numberOfQuestions = 5;
            int numberOfDiagnoses = 6;
            string path = $"{Environment.CurrentDirectory}\\ResultsOfTests.txt";
            string head = string.Format("{0, -25} {1, -30} \t{2, -12}", "ФИО:", "Количество правильных ответов:", "Ваш диагноз:" );
            FileStream fileResults;
            StreamWriter resultsOfTests;
            if (!File.Exists(path))
            {
                fileResults = new FileStream(path, FileMode.OpenOrCreate);
                resultsOfTests = new StreamWriter(fileResults, Encoding.UTF8);
                resultsOfTests.WriteLine(head);
                resultsOfTests.Dispose();
                fileResults.Close();
            }
            Console.WriteLine("Введите вашу фамилию: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Введите ваше имя: ");
            string secondName = Console.ReadLine();
            Console.WriteLine("Введите ваше отчество: ");
            string thirdName = Console.ReadLine();
            string[] questions = GetQuestions(numberOfQuestions);
            int[] answers = GetAnswers(numberOfQuestions);
            int[] randomValues = GetRandomValues(numberOfQuestions);

            int countRigthAnswers = 0;
            for (int i = 0; i < numberOfQuestions; i++)
            {
                Console.WriteLine($"Вопрос номер {i + 1}:" +
                    $"{Environment.NewLine}{questions[randomValues[i]]}");
                int userAnswer = GetUserAnswer();
                int rightAnswer = answers[randomValues[i]];
                if (userAnswer == rightAnswer)
                    countRigthAnswers++;
            }

            string diagnose = GetDiagnose(numberOfDiagnoses, GetNumberOfDiagnose(countRigthAnswers, numberOfQuestions, numberOfDiagnoses));

            string fio = $"{firstName} {GetFirstLetter(secondName)} {GetFirstLetter(thirdName)}";
            Console.WriteLine($"Количество правильных ответов: {countRigthAnswers}.");
            Console.Write($"{fio},{Environment.NewLine}Ваш диагноз: {diagnose}{Environment.NewLine}");

            string fileInput = string.Format("{0, -25} {1,-30} \t{2, -12}", fio, countRigthAnswers, diagnose);

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

        static string[] GetQuestions(int numberOfQuestions)
        {
            string[] questions = new string[numberOfQuestions];
            questions[0] = "Сколько будет два плюс два умножить на два?";
            questions[1] = "Бревно надо распелить на 10 частей сколько нужно сделать распилов?";
            questions[2] = "На двух руках 10 пальцев. Сколько пальцев на 5 руках?";
            questions[3] = "Укол делают каждые полчаса, сколько потребуется времени для 3-х уколов?";
            questions[4] = "Пять свечей горело, две потухло. Сколько свечей осталовь?";
            //questions[5] = "Сколько будет два плюс два умножить на два?";
            //questions[6] = "Бревно надо распелить на 10 частей сколько нужно сделать распилов?";
            //questions[7] = "На двух руках 10 пальцев. Сколько пальцев на 5 руках?";
            //questions[8] = "Укол делают каждые полчаса, сколько потребуется времени для 3-х уколов?";
            //questions[9] = "Пять свечей горело, две потухло. Сколько свечей осталовь?";
            return questions;
        }
        static int[] GetAnswers(int numberOfQuestions)
        {
            int[] answers = new int[numberOfQuestions];
            answers[0] = 6;
            answers[1] = 9;
            answers[2] = 25;
            answers[3] = 60;
            answers[4] = 2;
            //answers[5] = 6;
            //answers[6] = 9;
            //answers[7] = 25;
            //answers[8] = 60;
            //answers[9] = 2;
            return answers;
        }
        static string GetDiagnose(int numberOfDiagnoses, int counter)
        {
            string[] diagnoses = new string[numberOfDiagnoses];
            diagnoses[0] = "Идиот";
            diagnoses[1] = "Кретин";
            diagnoses[2] = "Дурак";
            diagnoses[3] = "Нормальный";
            diagnoses[4] = "Талант";
            diagnoses[5] = "Гений";
            return diagnoses[counter];
        }
        static int[] GetRandomValues(int numberOfQuestions)
        {
            Random random = new Random();
            int[] randomNumbers = new int[numberOfQuestions];
            int i = 0;
            while (i != numberOfQuestions)
            {
                bool alredyThere = false;
                int randomValue = random.Next(0, numberOfQuestions);
                for (int j = 0; j < i; j++)
                {
                    if (randomNumbers[j] == randomValue)
                    {
                        alredyThere = true;
                        break;
                    }
                }
                if (!alredyThere)
                {
                    randomNumbers[i] = randomValue;
                    i++;
                }
            }
            return randomNumbers;
        }
        static int GetUserAnswer()
        {
            int userAnswer;
            bool parsingSuccess = false;
            do
            {
                parsingSuccess = int.TryParse(Console.ReadLine(), out userAnswer);
                if (parsingSuccess == false)
                    Console.WriteLine("Ошибка ввода! Повторите попытку (введите целое число): ");
            } while (parsingSuccess == false);
            return userAnswer;
        }
      
        /*В данном случае решил установить диапазон правильных ответов для каждого диагноза. 
         Если правильный ответ попадает в этот диапазон, то возвращаем номер "диагноза - 1"*/
        static int GetNumberOfDiagnose(int countRigthAnswers, int numberOfQuetions, int numberOfDiagnoses)
        {
            int result = 0;
            if (countRigthAnswers == 0)
                return 0;
            else
            {
                double rate = (double)numberOfQuetions / numberOfDiagnoses;
                for (int i = numberOfDiagnoses; i > 0; i--)
                {
                    if (countRigthAnswers <= (rate * i) && countRigthAnswers > (rate * (i - 1)))
                        result = i - 1;
                }
            }
            return result;
        }
        static string GetFirstLetter(string name)
        {
            string firstLetter;
            if (name.Length < 1)
                firstLetter = name;
            else
                firstLetter = name[0] + ".";
            return firstLetter;
        }
    }
}
