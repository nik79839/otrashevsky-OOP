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
        static void Main(string[] args)
        {
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
            PersonList.Info(personList1);
            Console.WriteLine("\nList 2");
            PersonList.Info(personList2);
            Console.ReadKey();
            Console.WriteLine("");

            personList1.AddPerson(new Person("Doc", "Fier", 98, Gender.Male));
            Console.WriteLine("Добавление новой персоны в List 1\nList 1");
            PersonList.Info(personList1);
            Console.ReadKey();
            Console.WriteLine("");

            personList2.AddPerson(personList1.SearchByIndex(1));
            Console.WriteLine("Добавление новой персоны в List 2 из List 1\nList 2");
            PersonList.Info(personList2);
            Console.ReadKey();
            Console.WriteLine("");

            personList1.RemovebyIndex(1);
            Console.WriteLine("Удаление второй персоны из List 1\nList 1");
            PersonList.Info(personList1);
            Console.WriteLine("\nList 2");
            PersonList.Info(personList2);
            Console.ReadKey();
            Console.WriteLine("");

            personList2.Clear();
            Console.WriteLine("\nОчистка List 2\nList 2");
            PersonList.Info(personList2);
            Console.ReadKey();
            Console.WriteLine("");

            personList2.AddPerson(Person.AddPersonConsole());
            Console.WriteLine("\nList 2");
            PersonList.Info(personList2);
            Console.ReadKey();
            Console.WriteLine("");

            personList2.AddPerson(Person.GetRandomPerson());
            Console.WriteLine("\nДобавление случайной персоны в List 2");
            PersonList.Info(personList2);
            Console.ReadKey();
            Console.WriteLine("");
        }
    }
}