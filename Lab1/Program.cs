using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonLib;

namespace Lab1
{
    internal class Program
    {
        //TODO: RSDN
        public static void Main(string[] args)
        {
            //TODO: Отработать вывод Unicode
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;

            PersonList personList1 = new PersonList();
            PersonList personList2 = new PersonList();

            Person[] personAr1 = new Person[]
            {
                new Person("Nick", "afaf", 23, Gender.Male),
                new Person("Stanislav", "pol", 28, Gender.Male),
                new Person("Boolean", "fol", 100, Gender.Female),
            };

            Person[] personAr2 = new Person[]
            {
                new Person("gsg", "ewgwegw", 15, Gender.Male),
                new Person("neko-rano", "Grri", 55, Gender.Male),
                new Person("Bojack", "Horseman", 60, Gender.Male),
            };

            personList1.AddPersons(personAr1);
            personList2.AddPersons(personAr2);
            Console.WriteLine("Список 1");
            Info(personList1);
            Console.WriteLine("\nСписок 2");
            Info(personList2);
            Console.ReadKey();
            Console.WriteLine("");

            personList1.AddPerson(new Person("Doc", "Fier", 98, Gender.Male));
            Console.WriteLine("Добавление новой персоны в список 1\nСписок 1");
            Info(personList1);
            Console.ReadKey();
            Console.WriteLine("");

            personList2.AddPerson(personList1.SearchByIndex(1));
            Console.WriteLine("Добавление новой персоны в список 2 из списка 1\nСписок 2");
            Info(personList2);
            Console.ReadKey();
            Console.WriteLine("");

            personList1.RemoveByIndex(1);
            Console.WriteLine("Удаление второй персоны из списка 1\nСписок 1");
            Info(personList1);
            Console.WriteLine("\nСписок 2");
            Info(personList2);
            Console.ReadKey();
            Console.WriteLine("");

            personList2.Clear();
            Console.WriteLine("\nОчистка списка 2\nСписок 2");
            Info(personList2);
            Console.ReadKey();
            Console.WriteLine("");

            personList2.AddPerson(AddPersonConsole());
            Console.WriteLine("\nСписок 2");
            Info(personList2);
            Console.ReadKey();
            Console.WriteLine("");

            personList2.AddPerson(Person.GetRandomPerson());
            Console.WriteLine("\nДобавление случайной персоны в Список 2");
            Info(personList2);
            Console.ReadKey();
            Console.WriteLine("");
        }
        
        /// <summary>
        /// Добавление персоны через консоль
        /// </summary>
        /// <returns>Персона</returns>
        public static Person AddPersonConsole()
        {
            var defaultPerson = new Person();
            var actionsTupleList = new List<(Action Action, string Message)>
            {
                (
                    () => { defaultPerson.Name = Console.ReadLine(); },
                    "Введите имя:"
                ),
                (
                    () =>
                    {
                        defaultPerson.Surname = Console.ReadLine();
                    },
                    "Введите фамилию:"),
                (
                    () =>
                    {
                        defaultPerson.Age = Convert.ToInt32(Console.ReadLine());
                    },
                    "Введите возраст:"
                    ),
                (
                    () =>
                    {
                        int gender = Convert.ToInt32(Console.ReadLine());
                        defaultPerson.Gender =
                            (Gender)Enum.GetValues(typeof(Gender)).GetValue(gender);
                    },
                    "Введите пол, 0 - мужской, 1 - женский"
                    )
            };

            foreach (var actionTuple in actionsTupleList)
            {
                ActionHandler(actionTuple.Action, actionTuple.Message);
            }
            return defaultPerson;
        }
        
        /// <summary>
        /// Обработчик ввода персоны через консоль
        /// </summary>
        /// <param name="action"></param>
        /// <param name="inputMessage"></param>
        private static void ActionHandler(Action action, string inputMessage)
        {
            while (true)
            {
                Console.WriteLine(inputMessage);
                try
                {
                    action.Invoke();
                    return;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Повторите ввод");
                }
            }
        }
        
        /// <summary>
        /// Вывод списка персон
        /// </summary>
        /// <param name="personList"></param>
        public static void Info(PersonList personList)
        {
            for (int i = 0; i < personList.Length; i++)
            {
                Console.WriteLine(personList.SearchByIndex(i).Info);
            }
        }
    }
}