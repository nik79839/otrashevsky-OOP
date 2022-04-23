using Model;
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
                "Москва", "Юнион", 2011, 126);

            Magazine magazine1 = new Magazine("Вопросы", "Научный журнал", "ООО 'Редация'",
                "Москва", "А.А. Искендеров", 2011, 518);

            Collection collection1 = new Collection("Инновации", "Международная конференция",
                "Москва", "Московский Государственный Унверститет", 2012, 58);

            Thesis thesis1 = new Thesis("Филиппова А.Г", "Название диссертации",
                "диссертация на соискание ученой степени","специальность 13.00.01 'Общая педагогика'",
                "Москва", "Кузбасская государственная педагогическая академия", 2000, 255);

            List<EditionBase> editionBases = new List<EditionBase>() 
                { book1, magazine1, collection1, thesis1};
            foreach (EditionBase editionBase in editionBases)
            {
                Console.WriteLine(editionBase.GetType().Name+"\n"+ editionBase.Info + "\n");
            }
            Console.ReadKey();
        }
    }
}
