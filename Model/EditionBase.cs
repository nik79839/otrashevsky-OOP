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
        private int _year;

        /// <summary>
        /// Count of pages
        /// </summary>
        private int _pageCount;

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
        public int Year
        {
            get => _year;
            set
            {
                CheckValueOnLimits(value,1,DateTime.Now.Year);
                _year = value;
            }
        }

        /// <summary>
        /// Count of pages
        /// </summary>
        public int PageCount
        {
            get => _pageCount;
            set
            {
                CheckValueOnLimits(value, 1, 100000);
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
        protected EditionBase(string name, string place, int year, int pageCount)
        {
            Name = name;
            Place = place;
            Year = year;
            PageCount = pageCount;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        protected EditionBase()
        {
        }

        /// <summary>
        /// Check on empty or null string
        /// </summary>
        /// <param name="value">value</param>
        /// //TODO: XML
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

        /// <summary>
        /// Check value on limits
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="minimum">minimum</param>
        /// <param name="maximum">maximum</param>
        /// <returns>value</returns>
        /// <exception cref="ArgumentException"></exception>
        private int CheckValueOnLimits(int value,int minimum,int maximum)
        {
            if (value > maximum || value < minimum)
            {
                throw new ArgumentException($"Value should be " +
                    $"between {minimum} and {maximum}");
            }
            return value;
        }
        
        /// <summary>
        /// Info about edition
        /// </summary>
        /// <returns></returns>
        public abstract string Info { get; }

    }
}
