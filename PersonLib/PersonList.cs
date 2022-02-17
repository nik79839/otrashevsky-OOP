using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLib
{
    public class PersonList
    {
        /// <summary>
        /// Создание списка персон
        /// </summary>
        public Person[] personList = new Person[0];

        /// <summary>
        /// Добавление персоны в конец списка
        /// </summary>
        /// <param name="person">Персона</param>
        public void AddPerson(Person person)
        {
            Array.Resize(ref personList, personList.Length + 1);
            personList[personList.Length-1] = person;
        }

        /// <summary>
        /// Добавление нескольких персон
        /// </summary>
        /// <param name="persons">Список персон</param>
        public void AddPersons(Person[] persons)
        {
            foreach (Person person in persons)
            {
                AddPerson(person);
            }
        }

        /// <summary>
        /// Получение индекса персоны
        /// </summary>
        /// <param name="person">Персона</param>
        /// <returns>Индекс персоны</returns>
        /// <exception cref="Exception"></exception>
        public int GetIndexPerson(Person person)
        {
            for (int index = 0; index < personList.Length; index++)
            {
                if (personList[index] == person)
                {
                    return index;
                }
            }
            throw new Exception("Данного человека не существует");
        }

        /// <summary>
        /// Удаление из списка персон по индексу
        /// </summary>
        /// <param name="index"></param>
        public void RemovebyIndex(int index)
        {
            personList = personList.Where((person, i) => i != index).ToArray();
        }

        /// <summary>
        /// Удаление определенной персоны
        /// </summary>
        /// <param name="person">Персона</param>
        public void DeletePersonByName(Person person)
        {
            RemovebyIndex(GetIndexPerson(person));
        }

        /// <summary>
        /// Поиск персоны по индексу
        /// </summary>
        /// <param name="index">Индекс</param>
        /// <returns>Найденная персона</returns>
        /// <exception cref="Exception"></exception>
        public Person SearchByIndex(int index)
        {
            if (index >= 0 && index < personList.Length)
            {
                return personList[index];
            }
            else
            {
                throw new Exception("Данного индекса не существует");
            }
        }

        /// <summary>
        /// Возвращает количество персон в списке
        /// </summary>
        public int Length => personList.Length;

        /// <summary>
        /// Очистка всех персон
        /// </summary>
        public void Clear()
        {
            Array.Resize(ref personList, 0);
        }

        public static void Info(PersonList personList)
        {
            for (int i = 0; i < personList.Length; i++)
            {
                Console.WriteLine(personList.SearchByIndex(i).Info);
            }
        }
    }
}
