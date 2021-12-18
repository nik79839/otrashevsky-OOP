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
            Person person1 = new Person("nick", "Otrashevsky", 23, Gender.Male);
            Console.WriteLine(person1.Age);
            Console.ReadKey();
        }
    }
}
