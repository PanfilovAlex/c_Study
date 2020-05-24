using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniyIdiot
{
    class FileResults
    {
        string path = $"{Environment.CurrentDirectory}\\ResultsOfTests.txt";

        public void CreatinFileOfResults()
        {
            if (!File.Exists(this.path))
            {
                var head = string.Format("{0, -25} {1, -30} \t{2, -12}", "ФИО:", "Количество правильных ответов:", "Ваш диагноз:");
                var fileResults = new FileStream(path, FileMode.OpenOrCreate);
                var resultsOfTests = new StreamWriter(fileResults, Encoding.UTF8); ;
                resultsOfTests.WriteLine(head);
                resultsOfTests.Dispose();
                fileResults.Close();
            }
        }
        public void WriteToFileOfResults(User user)
        {
            string fileWriter = string.Format("{0, -25} {1, -30} \t{2, -12}", user.ReturnFIO, user.Result, user.Diagnose);
            try
            {
                using (FileStream fileStream = new FileStream(this.path, FileMode.Append))
                {
                    using (StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.UTF8))
                    {
                        streamWriter.WriteLine(fileWriter);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void ShowResultsOfTests(char keySymb)
        {
            if (keySymb == 'y')
            {
                Console.WriteLine("Результаты тестирования: ");
                try
                {
                    using (StreamReader readerResultsOfTests = new StreamReader(this.path))
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