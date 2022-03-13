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

            /*Adult sten = new Adult("4276", "workman", MaritalStatus.Single, "afaf", "weden", 22, Gender.Male);
            Child tom = new Child(sten,"afsf", "sten", "asfasf", 15, Gender.Male);
            Console.WriteLine(tom.Info());*/
            PersonList personList1 = new PersonList();
            Console.WriteLine("Adding 7 person to list");
            Adult adult1 = new Adult("1000", "Hospital", MaritalStatus.Married, "Hanna", "Green", 26, Gender.Female);
            Adult adult2 = new Adult(adult1,"2000", "School", MaritalStatus.Married, "Argg", "Green", 24, Gender.Male);
            adult1.Spouse = adult2;
            Adult adult3 = new Adult("12345", "", MaritalStatus.Single, "Olga", "Gray", 57, Gender.Female);
            Child child1 = new Child(adult1, adult2, "School №2", "Tom","Green", 10, Gender.Male);
            Child child2 = new Child("School №1", "Ray", "Black", 17, Gender.Male);
            Adult adultRandom = Adult.GetRandomAdult();
            Child childRandom=Child.GetRandomChild();
            PersonBase[] personArr = new PersonBase[]
            {
                adult1,child1,adult2,child2,adult3,adultRandom,childRandom
            };
            personList1.AddPersons(personArr);
            Info(personList1);
        }

        static void Info(PersonList personList)
        {
            for (int i = 0; i < personList.Length; i++)
            {
                Console.WriteLine(personList.SearchByIndex(i).Info());
            }
        }
    }
}
