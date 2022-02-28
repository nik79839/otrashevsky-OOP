using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLib
{
    /// <summary>
    /// Класс списка персон
    /// </summary>
    public class PersonList
    {
        /// <summary>
        /// Создание списка персон
        /// </summary>
        private Person[] _personList = new Person[0];

        /// <summary>
        /// Добавление персоны в конец списка
        /// </summary>
        /// <param name="person">Персона</param>
        public void AddPerson(Person person)
        {
            Array.Resize(ref _personList, _personList.Length + 1);
            _personList[_personList.Length-1] = person;
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
            for (int index = 0; index < _personList.Length; index++)
            {
                if (_personList[index] == person)
                {
                    return index;
                }
            }
            throw new Exception("Данного человека не существует");
        }

        //TODO: RSDN
        /// <summary>
        /// Удаление из списка персон по индексу
        /// </summary>
        /// <param name="index"></param>
        public void RemoveByIndex(int index)
        {
            _personList = _personList.Where((person, i) => i != index).ToArray();
        }

        /// <summary>
        /// Удаление определенной персоны
        /// </summary>
        /// <param name="person">Персона</param>
        public void DeletePersonByName(Person person)
        {
            RemoveByIndex(GetIndexPerson(person));
        }

        /// <summary>
        /// Поиск персоны по индексу
        /// </summary>
        /// <param name="index">Индекс</param>
        /// <returns>Найденная персона</returns>
        /// <exception cref="Exception"></exception>
        public Person SearchByIndex(int index)
        {
            if (index >= 0 && index < _personList.Length)
            {
                return _personList[index];
            }
            else
            {
                throw new Exception("Данного индекса не существует");
            }
        }

        /// <summary>
        /// Возвращает количество персон в списке
        /// </summary>
        public int Length => _personList.Length;

        /// <summary>
        /// Очистка всех персон
        /// </summary>
        public void Clear()
        {
            Array.Resize(ref _personList, 0);
        }       
    }
}
