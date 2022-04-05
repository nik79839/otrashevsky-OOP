using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Book
    /// </summary>
    public class Book : EditionBase
    {
        /// <summary>
        /// Main author
        /// </summary>
        private string _mainAuthor;

        /// <summary>
        /// Publisher
        /// </summary>
        private string _publisher;

        /// <summary>
        /// Type of book
        /// </summary>
        private string _type;

        /// <summary>
        /// Main author
        /// </summary>
        public string MainAuthor
        {
            get => _mainAuthor;
            set
            {
                CheckEmptyAndLanguage(value);
                _mainAuthor = value;
            }
        }

        /// <summary>
        /// Publisher
        /// </summary>
        public string Publisher
        {
            get => _publisher;
            set
            {
                CheckEmptyOrNull(value);
                _publisher = value;
            }
        }

        /// <summary>
        /// Type
        /// </summary>
        public string Type
        {
            get => _type;
            set
            {
                CheckEmptyAndLanguage(value);
                _type = value;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mainAuthor">main author</param>
        /// <param name="name">name</param>
        /// <param name="type">type</param>
        /// <param name="place">place</param>
        /// <param name="publisher">publisher</param>
        /// <param name="year">year</param>
        /// <param name="pageCount">count of pages</param>
        public Book(string mainAuthor, string name, string type, string place,
            string publisher, string year, string pageCount)
            : base(name, place, year, pageCount)
        {
            MainAuthor = mainAuthor;
            Type = type;
            Publisher = publisher;
        }

        //TODO: XML
        public override string Info()
        {
            string mainAuthor = MainAuthor == ""
                        ? ""
                        : MainAuthor + " ";
            string type = Type == ""
                ? ""
                : ": " + Type + ",";
            return $"{mainAuthor}{Name}{type}. - {Place}.: {Publisher}" +
                $", {Year}. - {PageCount} с.";
        }
    }
}
