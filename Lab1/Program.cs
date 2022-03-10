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
            Console.WriteLine("List 1");
            Info(personList1);
            Console.WriteLine("\nList 2");
            Info(personList2);
            Console.ReadKey();
            Console.WriteLine("");

            personList1.AddPerson(new Person("Doc", "Fier", 98, Gender.Male));
            Console.WriteLine("Adding a new person to the list 1\nList 1");
            Info(personList1);
            Console.ReadKey();
            Console.WriteLine("");

            personList2.AddPerson(personList1.SearchByIndex(1));
            Console.WriteLine("Adding a new person to List 2 from List 1\nList 2");
            Info(personList2);
            Console.ReadKey();
            Console.WriteLine("");

            personList1.RemoveByIndex(1);
            Console.WriteLine("Removing the second person from the list 1\nList 1");
            Info(personList1);
            Console.WriteLine("\nList 2");
            Info(personList2);
            Console.ReadKey();
            Console.WriteLine("");

            personList2.Clear();
            Console.WriteLine("\nClearing the list 2\nList 2");
            Info(personList2);
            Console.ReadKey();
            Console.WriteLine("");

            personList2.AddPerson(AddPersonConsole());
            Console.WriteLine("\nList 2");
            Info(personList2);
            Console.ReadKey();
            Console.WriteLine("");

            personList2.AddPerson(Person.GetRandomPerson());
            Console.WriteLine("\nAdding a random person to the list 2");
            Info(personList2);
            Console.ReadKey();
            Console.WriteLine("");
        }

        /// <summary>
        /// Adding a person via the console
        /// </summary>
        /// <returns>Person</returns>
        public static Person AddPersonConsole()
        {
            var defaultPerson = new Person();
            var actionsTupleList = new List<(Action Action, string Message)>
            {
                (
                    () => { defaultPerson.Name = Console.ReadLine(); },
                    "Enter a name:"
                ),
                (
                    () =>
                    {
                        defaultPerson.Surname = Console.ReadLine();
                    },
                    "Enter a surname:"),
                (
                    () =>
                    {
                        defaultPerson.Age = Convert.ToInt32(Console.ReadLine());
                    },
                    "Enter the age:"
                    ),
                (
                    () =>
                    {
                        int gender = Convert.ToInt32(Console.ReadLine());
                        defaultPerson.Gender =
                            (Gender)Enum.GetValues(typeof(Gender)).GetValue(gender);
                    },
                    "Enter the gender, 0 - male, 1 - female"
                    )
            };

            foreach (var actionTuple in actionsTupleList)
            {
                ActionHandler(actionTuple.Action, actionTuple.Message);
            }
            return defaultPerson;
        }

        /// <summary>
        /// Person input handler via the console
        /// </summary>
        /// <param name="action">Action</param>
        /// <param name="inputMessage">Message</param>
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
                    Console.WriteLine("Repeat the input");
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