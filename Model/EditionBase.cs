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
                CheckEmptyOrNull(value);
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
                CheckEmptyAndLanguage(value);
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
                CheckYear(value);
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
                CheckPageCount(value);
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
        /// Check on empty or null string
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="name">name of value</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        protected string CheckEmptyOrNull(string value)
        {
            if (string.IsNullOrEmpty(value))
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
        protected string CheckEmptyAndLanguage(string value)
        {
            var regex = new Regex(@"^([-.,a-zA-Z\s]|[-.,а-яА-Я\s])*$");
            if (value == string.Empty)
            {
                throw new Exception("The input line is empty");
            }
            else if (!regex.IsMatch(value))
            {
                throw new Exception("There should be only Russian or English characters");
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Check year
        /// </summary>
        /// <param name="value">value</param>
        /// <returns>year</returns>
        /// <exception cref="ArgumentException"></exception>
        private string CheckYear(string value)
        {
            CheckEmptyOrNull(value);

            string pattern = @"^[0-9]*$";
            const int maximumYear = 2022;
            const int minimumYear = 0;
            if (!Regex.IsMatch(value, pattern))
            {
                throw new ArgumentException($"Year must only contain numbers");
            }           
            if (Convert.ToInt32(value) > maximumYear || Convert.ToInt32(value) < minimumYear)
            {
                throw new ArgumentException($"Year should be " +
                    $"between {minimumYear} and {maximumYear}");
            }
            return value;
        }

        /// <summary>
        /// Check count of pages
        /// </summary>
        /// <param name="value">value</param>
        /// <returns>value</returns>
        /// <exception cref="ArgumentException"></exception>
        private string CheckPageCount(string value)
        {
            CheckEmptyOrNull(value);
            string pattern = @"^[0-9]*$";
            if (!Regex.IsMatch(value, pattern))
            {
                throw new ArgumentException($"Count of page must only contain numbers");
            }
            const int maximumPageLimits = 100000;
            const int minimumPageLimits = 0;
            if (Convert.ToInt32(value) > maximumPageLimits || Convert.ToInt32(value) < minimumPageLimits)
            {
                throw new ArgumentException($"Count of page should be " +
                    $"between {minimumPageLimits} and {maximumPageLimits}");
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
