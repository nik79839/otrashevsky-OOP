﻿using System;
using System.Text.RegularExpressions;

namespace PersonLib
{
    public abstract class PersonBase
    {
        /// <summary>
        /// Name
        /// </summary>
        private string _name;

        /// <summary>
        /// Surname
        /// </summary>
        private string _surname;

        /// <summary>
        /// Age
        /// </summary>
        private int _age;
        
        /// <summary>
        /// Gender of person
        /// </summary>
        private Gender _gender;

        /// <summary>
        /// Language
        /// </summary>
        private string _lang;

        /// <summary>
        /// Gender of person
        /// </summary>
        public Gender Gender 
        {
            get => _gender;
            set
            {
                CheckGender((int)value);
                _gender = value;
            }
        }

        /// <summary>
        /// Name
        /// </summary>
        public string Name 
        {
            get => _name;
            set 
            {
                CheckNameSurname(value);
                _name = ConvertToRightRegister(value);
            }
        }

        /// <summary>
        /// Age
        /// </summary>
        public int Age
        {
            get => _age;
            set 
            {
                CheckAge(value);
                _age = value;
            }
        }

        /// <summary>
        /// Surname
        /// </summary>
        public string Surname 
        { 
            get => _surname;
            set 
            {
                CheckNameSurname(value);
                this._lang = null;
                _surname = ConvertToRightRegister(value);
            }
        }
        
        /// <summary>
        /// Maximum age
        /// </summary>
        protected abstract int MaxAge { get; }

        /// <summary>
        /// Minimum age
        /// </summary>
        protected abstract int MinAge { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="surname">Surname</param>
        /// <param name="age">Age</param>
        /// <param name="gender">Gender</param>
        public PersonBase(string name, string surname, int age, Gender gender)
        {
            Name = name;
            Surname= surname;
            Age = age;
            Gender = gender;           
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public PersonBase() : this("Nikita", "Otrashevsky", 23, Gender.Male) { }

        /// <summary>
        /// Convert to right register
        /// </summary>
        /// <param name="value">Surname or name</param>
        /// <returns>String with right register</returns>
        private string ConvertToRightRegister(string value)
        {
            var symbols = new[] { "-", " " };
            foreach (var symbol in symbols)
            {
                if (value.Contains(symbol))
                {
                    int indexOfSymbol = value.IndexOf(symbol);
                    return value.Substring(0, 1).ToUpper()
                        + value.Substring(1, indexOfSymbol - 1).ToLower()
                        + symbol
                        + value.Substring(indexOfSymbol + 1, 1).ToUpper()
                        + value.Substring(indexOfSymbol + 2).ToLower();
                }
            }
            return value.Substring(0, 1).ToUpper() +
                    value.Substring(1, value.Length - 1).ToLower(); ;
        }

        /// <summary>
        /// Checking for an empty string and English or Russian characters
        /// </summary>
        /// <param name="value">Surname or name</param>
        /// <returns>Source string in case of no errors</returns>
        /// <exception cref="Exception"></exception>
        private string CheckNameSurname(string value)
        {
            Regex regexRus = new Regex("^([А-Яа-я])+(((-| )?([А-Яа-я])+))?$");
            Regex regexEng = new Regex("^([A-Za-z])+(((-| )?([A-Za-z])+))?$");
            if (value==string.Empty)
            {
                throw new Exception("The input line is empty");
            }
            else if (regexRus.IsMatch(value) && (this._lang == null || this._lang == "Rus"))
            {
                this._lang = "Rus";
                return value;
            }
            else if (regexEng.IsMatch(value) && (this._lang == null || this._lang == "Eng"))
            {
                this._lang = "Eng";
                return value;
            }
            else
            {
                throw new Exception("There should be only Russian or only English characters");
            }
        }

        /// <summary>
        /// Age checking
        /// </summary>
        /// <param name="age">Age</param>
        /// <returns>Age</returns>
        /// <exception cref="Exception"></exception>
        protected int CheckAge(int age)
        {
            if (age < MinAge || age > MaxAge)
            {
                throw new Exception($"The age should be in the range from {MinAge} to {MaxAge}");
            }
            else
            {
                return age;
            }
        }

        /// <summary>
        /// Gender checking
        /// </summary>
        /// <param name="number">Number of gender</param>
        /// <returns>Number of gender</returns>
        /// <exception cref="Exception"></exception>
        private static int CheckGender(int number)
        {
            if (number < 0 || number > 1)
            {
                throw new Exception("Enter 0 or 1, where 0 - Мale, 1 - Female");
            }
            else
            {
                return number;
            }
        }

        /// <summary>
        /// Output of information about a base person
        /// </summary>
        public string InfoPerson() => $"{Name} {Surname}, Age: {Age}, Gender: {Gender}";

        /// <summary>
        /// Output of information about a person 
        /// </summary>
        /// <returns></returns>
        public abstract string Info();

        /// <summary>
        /// Special action
        /// </summary>
        /// <returns></returns>
        public abstract string SpecialAction();

    }
}
