using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniyIdiot
{
    class InputsProvider
    {
        public User GetUserData()
        {
            string firstName = InputFirstName();
            string secondName = InputSecondName();
            string lastName = InputLastName();
            return new User(firstName, secondName, lastName);                        
        }
        private string InputFirstName()
        {
            Console.WriteLine($"Введите Ваше имя:");
            return Console.ReadLine();
        }
        private string InputSecondName()
        {
            Console.WriteLine($"Введите Ваше отчество:");
            return Console.ReadLine();
        }
        public string InputLastName()
        {
            Console.WriteLine($"Введите Вашу фамилию:");
            return Console.ReadLine();
        }
        public int GetUserAnswer()
        {
            int userAnswer;
            while (!int.TryParse(Console.ReadLine(), out userAnswer))
            {
                Console.WriteLine("Ошибка ввода! Повторите попытку: ");
            }
            return userAnswer;
        }
        public char GetUserAnswer(char symb)
        {
            var userAnswer = '\0';
            while (userAnswer != 'y' && userAnswer != 'n')
            {
                while (!char.TryParse(Console.ReadLine(), out userAnswer))
                {
                    Console.WriteLine("Ошибка ввода! Повторите попытку: ");
                }
                if (userAnswer != 'y' && userAnswer != 'n')
                    Console.WriteLine("Ошибка ввода! Повторите попытку: ");
            }
            return userAnswer;
        }
    }
}
