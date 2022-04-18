using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Edition (book, collection, magazine, article)
    /// </summary>
    public abstract class EditionBase
    {
        /// <summary>
        /// Name of edition
        /// </summary>
        private string _name;

        /// <summary>
        /// Place of publication
        /// </summary>
        private string _place;

        /// <summary>
        /// Year of publication
        /// </summary>
        private string _year;

        /// <summary>
        /// Count of pages
        /// </summary>
        private string _pageCount;

        /// <summary>
        /// Name of edition
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                CheckEmpty(value);
                _name = value;
            }          
        }

        /// <summary>
        /// Place of publication
        /// </summary>
        public string Place
        {
            get => _place;
            set 
            {
                CheckEmpty(value);
                CheckLanguage(value);
                _place = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
            }
            
        }

        /// <summary>
        /// Year of publication
        /// </summary>
        public string Year
        {
            get => _year;
            set
            {
                CheckValueOnLimits(value,0,DateTime.Now.Year);
                _year = value;
            }
        }

        /// <summary>
        /// Count of pages
        /// </summary>
        public string PageCount
        {
            get => _pageCount;
            set
            {
                CheckValueOnLimits(value, 0, 100000);
                _pageCount = value;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="place">Place</param>
        /// <param name="year">Year</param>
        /// <param name="pageCount">Count of page</param>
        protected EditionBase(string name, string place, string year, string pageCount)
        {
            Name = name;
            Place = place;
            Year = year;
            PageCount = pageCount;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        protected EditionBase()
        {
        }

        /// <summary>
        /// Check on empty or null string
        /// </summary>
        /// <param name="value">value</param>
        /// //TODO: XML
        /// <param name="name">name of value</param>
        /// <returns>value</returns>
        /// <exception cref="ArgumentException"></exception>
        protected string CheckEmpty(string value)
        {
            if (value==String.Empty)
            {
                throw new ArgumentException($"Line should not be empty!");
            }
            return value;
        }

        /// <summary>
        /// Check empty and language
        /// </summary>
        /// <param name="value">value</param>
        /// <returns>value</returns>
        /// <exception cref="Exception"></exception>
        protected string CheckLanguage(string value)
        {
            var regex = new Regex(@"^([-.,a-zA-Z\s]|[-.,а-яА-Я\s])*$");
            if (!regex.IsMatch(value))
            {
                throw new Exception("There should be only Russian or English characters");
            }
            else
            {
                return value;
            }
        }

        private string CheckValueOnLimits(string value,int minimum,int maximum)
        {
            CheckEmpty(value);
            //TODO: duplication
            string pattern = @"^[0-9]*$";
            //TODO:
            if (!Regex.IsMatch(value, pattern))
            {
                throw new ArgumentException($"Value must only contain numbers");
            }
            if (Convert.ToInt32(value) > maximum || Convert.ToInt32(value) < minimum)
            {
                throw new ArgumentException($"Value should be " +
                    $"between {minimum} and {maximum}");
            }
            return value;
        }


        //TODO: В свойство
        /// <summary>
        /// Info about edition
        /// </summary>
        /// <returns></returns>
        public abstract string Info { get; }

    }
}
