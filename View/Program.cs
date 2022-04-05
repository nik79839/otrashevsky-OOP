﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book("Филиппова А.Г", "История", "учебное пособие",
                "Москва", "Юнион", "2011", "126");
            Console.WriteLine("Книга");
            Console.WriteLine(book1.Info());

            Magazine magazine1 = new Magazine("Вопросы", "Научный журнал", "ООО 'Редация'",
                "Москва", "А.А. Искендеров", "2011", "518");
            Console.WriteLine("Журнал");
            Console.WriteLine(magazine1.Info());

            Collection collection1 = new Collection("Инновации", "Международная конференция",
                "Москва", "Московский Государственный Унверститет", "2012", "58");
            Console.WriteLine("Сборник");
            Console.WriteLine(collection1.Info());

            Thesis thesis1 = new Thesis("Филиппова А.Г", "Название диссертации",
                "диссертация на соискание ученой степени","специальность 13.00.01 'Общая педагогика'",
                "Москва", "Кузбасская государственная педагогическая академия", "2000", "255");
            Console.WriteLine("Диссертация");
            Console.WriteLine(thesis1.Info());
            Console.ReadKey();


        }
    }
}