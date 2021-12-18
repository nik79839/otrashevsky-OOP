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
                new Person("Stanislav junior", "pol", 28, Gender.Male),
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
            PersonList.info(personList1);
            Console.WriteLine("\nList 2");
            PersonList.info(personList2);
            Console.ReadKey();

            personList1.AddPerson(new Person("Doctor", "Zoidberg", 98, Gender.Male));
            Console.WriteLine("List 1");
            PersonList.info(personList1);
            Console.ReadKey();

            personList2.AddPerson(personList1.SearchByIndex(1));
            Console.WriteLine("List 2");
            PersonList.info(personList2);
            Console.ReadKey();

            personList1.DelIndex(1);
            Console.WriteLine("List 1");
            PersonList.info(personList1);
            Console.WriteLine("\nList 2");
            PersonList.info(personList2);
            Console.ReadKey();

            personList2.Clear();
            Console.WriteLine("\nList 2");
            PersonList.info(personList2);
            Console.ReadKey();

            personList2.AddPerson(Person.AddPersonConsole());
            Console.WriteLine("\nList 2");
            PersonList.info(personList2);
            Console.ReadKey();

            personList2.AddPerson(Person.GetRandomPerson());
            Console.WriteLine("\nList 2");
            PersonList.info(personList2);
            Console.ReadKey();
        }
    }
}
