using PersonLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;

            Random random= new Random();
            PersonList personList1 = new PersonList();
            Console.WriteLine("Adding 7 person to list");
            Adult adult1 = new Adult("1000", "Hospital", MaritalStatus.Married, "Hanna", "Green", 26, Gender.Female);
            Adult adult2 = new Adult(adult1,"2000", "School", MaritalStatus.Married, "Argg", "Green", 24, Gender.Male);
            Child child1 = new Child(adult1, adult2, "School №2", "Tom","Green", 10, Gender.Male);
            PersonBase[] personArr = new PersonBase[] { adult1, adult2, child1 };
            personList1.AddPersons(personArr);
            for (int i = 0; i < 4; i++)
            {
                if (random.Next(2) == 0)
                {
                    personList1.AddPerson(Adult.GetRandomAdult(random));
                }
                else
                {
                    personList1.AddPerson(Child.GetRandomChild(random));
                }
            }
            Console.WriteLine("\nList");
            Info(personList1);

            var fourthPerson = personList1.SearchByIndex(3);
            Console.WriteLine($"\nFourth person: {fourthPerson.Info()}, \nType: {fourthPerson.GetType()}");
            switch (fourthPerson)
            {
                case Adult adult:
                    Console.WriteLine(adult.SpecialActionForAdult());
                    break;
                case Child child:
                    Console.WriteLine(child.SpecialActionForChild());
                    break;
            }
        }
        /// <summary>
        /// Input information about all persons
        /// </summary>
        /// <param name="personList">List of the persons</param>
        static void Info(PersonList personList)
        {
            for (int i = 0; i < personList.Length; i++)
            {
                Console.WriteLine(personList.SearchByIndex(i).Info());
            }
        }
    }
}
