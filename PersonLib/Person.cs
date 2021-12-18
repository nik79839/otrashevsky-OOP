using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PersonLib
{
    public class Person
    {
        /// <summary>
        /// Имя
        /// </summary>
        private string name;

        /// <summary>
        /// Фамилия
        /// </summary>
        private string surname;

        /// <summary>
        /// Возраст
        /// </summary>
        private int age;

        /// <summary>
        /// Пол человека
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name 
        { 
            get 
            { 
                return name;
            } 
            set 
            {
                CheckNameSurname(value);
                name = ConvertToRightRegister(value);
            }
        }

        /// <summary>
        /// Возраст
        /// </summary>
        public int Age
        { 
            get 
            { 
                return age;
            } 
            set 
            {
                CheckAge(value);
                age = value;
            }
        }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get { return surname; } set { surname = value; } }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="gender">Пол</param>
        public Person(string name, string surname, int age, Gender gender)
        {
            Name = name;
            Surname= surname;
            Age = age;
            Gender = gender;           
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Person() : this("Nikita", "Otrashevsky", 23, Gender.Male) { }

        /// <summary>
        /// Проеобразование к правильному регистру
        /// </summary>
        /// <param name="value">Фамилия или имя</param>
        /// <returns></returns>
        private string ConvertToRightRegister(string value)
        {
            var symbols = new[] { "-", " " };
            foreach (var symbol in symbols)
            {
                if (value.Contains(symbol))
                {
                    int indexOfSymbol = value.IndexOf(symbol);
                    return value.Substring(0, 1).ToUpper()
                        + value.Substring(1, indexOfSymbol - 1).ToLower()
                        + symbol
                        + value.Substring(indexOfSymbol + 1, 1).ToUpper()
                        + value.Substring(indexOfSymbol + 2).ToLower();
                }
            }
            return value.Substring(0, 1).ToUpper() +
                    value.Substring(1, value.Length - 1).ToLower(); ;
        }

        /// <summary>
        /// Проверка на пустую строку и английские или русские символы
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string CheckNameSurname(string value)
        {
            var regex = new Regex("^([A-Za-z]|[А-Яа-я])+(((-| )?([A-Za-z]|" +
                "[А-Яа-я])+))?$");
            if (value==string.Empty)
            {
                throw new Exception("Строка ввода пустая");
            }
            else if (!regex.IsMatch(value))
            {
                throw new Exception("Должны быть только русские или английские символы");
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Проверка возраста
        /// </summary>
        /// <param name="age">Возраст</param>
        /// <returns>Возраст</returns>
        /// <exception cref="Exception"></exception>
        public int CheckAge(int age)
        {
            if (age < 0 || age > 120)
            {
                throw new Exception("Указан неверный возраст");
            }
            else
            {
                return age;
            }
        }

        /// <summary>
        /// Проверка пола
        /// </summary>
        /// <param name="number">Номер пола</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static int CheckGender(int number)
        {
            if (number < 0 || number > 1)
            {
                throw new Exception("Введите 0 или 1, где 0 - М, 1 - Ж");
            }
            else
            {
                return number;
            }
        }
        
        /// <summary>
        /// Вывод информации о персоне
        /// </summary>
        public string Info
        {
            get
            {
                return $"{Name} {Surname}, Age: {Age}, Gender: {Gender}";
            }
        }

        /// <summary>
        /// Добавление персоны через консоль
        /// </summary>
        /// <returns>Персона</returns>
        public static Person AddPersonConsole()
        {
            Console.WriteLine("Введите имя");
            string name = Console.ReadLine();
            Console.WriteLine("Введите фамилию");
            string surname = Console.ReadLine();
            Console.WriteLine("Введите возраст");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите пол, 0 - мужской, 1 - женский");
            int gender = Convert.ToInt32(Console.ReadLine());
            Gender gender1 = (Gender)Enum.GetValues(typeof(Gender)).GetValue(gender);
            return new Person(name,surname,age,gender1);
        }

        public static Person GetRandomPerson()
        {
            string[] maleNames = new string[]
            {
                "John", "Carl", "Rick", "Mattew",
                "Nicholas", "Robert", "Samuel",
                "Stan", "Kenny", "Severus", "Jake"
            };

            string[] femaleNames = new string[]
            {
                "Lyla", "Samanta", "Kate", "Kira",
                "Amelia", "Julia", "Anastasia",
                "Sindy", "Luna", "Violet", "Anna"
            };

            string[] allSurnames = new string[]
            {
                "Potter", "Granger", "Black", "Malfoy",
                "Weasley", "Dursley", "Riddle",
                "Krum", "Snape", "Lovegood", "Lestrange"
            };
            Random random = new Random();
            string name;
            Gender gender = (Gender)random.Next(0, 2);
            switch (gender)
            {
                case Gender.Male:
                    name = maleNames[random.Next(maleNames.Length)];
                    break;
                case Gender.Female:
                    name = femaleNames[random.Next(femaleNames.Length)];
                    break;
                default:
                    return new Person("Default", "Person", 0, Gender.Male);
            }
            string surname = allSurnames[random.Next(allSurnames.Length)];
            int age = random.Next(0, 120);
            return new Person(name, surname, age, gender);
        }


    }
}
