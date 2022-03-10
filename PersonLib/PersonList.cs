using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLib
{
    /// <summary>
    /// Class of list of persons
    /// </summary>
    public class PersonList
    {
        /// <summary>
        /// Create list of the persons
        /// </summary>
        private Person[] _personList = new Person[0];

        /// <summary>
        /// Add person to end of the list
        /// </summary>
        /// <param name="person">Person</param>
        public void AddPerson(Person person)
        {
            Array.Resize(ref _personList, _personList.Length + 1);
            _personList[_personList.Length-1] = person;
        }

        /// <summary>
        /// Add a few of persons
        /// </summary>
        /// <param name="persons">List of the person</param>
        public void AddPersons(Person[] persons)
        {
            foreach (Person person in persons)
            {
                AddPerson(person);
            }
        }

        /// <summary>
        /// Get index of the person
        /// </summary>
        /// <param name="person">Person</param>
        /// <returns>Index of person</returns>
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
            throw new Exception("This person does not exist");
        }

        //TODO: RSDN
        /// <summary>
        /// Removing persons from the list by index
        /// </summary>
        /// <param name="index">Index</param>
        public void RemoveByIndex(int index)
        {
            _personList = _personList.Where((person, i) => i != index).ToArray();
        }

        /// <summary>
        /// Removing a certain person
        /// </summary>
        /// <param name="person">Person</param>
        public void DeletePersonByName(Person person)
        {
            RemoveByIndex(GetIndexPerson(person));
        }

        /// <summary>
        /// Search person by index
        /// </summary>
        /// <param name="index">Index</param>
        /// <returns>Found person</returns>
        /// <exception cref="Exception"></exception>
        public Person SearchByIndex(int index)
        {
            if (index >= 0 && index < _personList.Length)
            {
                return _personList[index];
            }
            else
            {
                throw new Exception("This index does not exist");
            }
        }

        /// <summary>
        /// Returns the number of persons in the list
        /// </summary>
        public int Length => _personList.Length;

        /// <summary>
        /// Clearing all persons
        /// </summary>
        public void Clear()
        {
            Array.Resize(ref _personList, 0);
        }       
    }
}
