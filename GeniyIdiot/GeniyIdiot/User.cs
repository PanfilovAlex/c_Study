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

        public void InputFirstName()
        {
            Console.WriteLine($"Введите Ваше имя:");
            firstName = Console.ReadLine();
        }
        public void InputSecondName()
        {
            Console.WriteLine($"Введите Ваше отчество:");
            secondName = Console.ReadLine();
        }
        public void InputLastName()
        {
            Console.WriteLine($"Введите Вашу фамилию:");
            lastName = Console.ReadLine();
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
