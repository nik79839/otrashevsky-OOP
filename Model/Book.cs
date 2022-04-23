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
                CheckEmpty(value);
                CheckLanguage(value);
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
                CheckEmpty(value);
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
                CheckLanguage(value);
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
            string publisher, int year, int pageCount)
            : base(name, place, year, pageCount)
        {
            MainAuthor = mainAuthor;
            Type = type;
            Publisher = publisher;
        }

        /// <summary>
		/// Конструктор класса для сериализации
		/// </summary>
		public Book()
        {
        }

        /// <summary>
        /// Information
        /// </summary>
        public override string Info
        {
            get
            {
                string type = Type == ""
                    ? ""
                    : ": " + Type;
                return $"{MainAuthor} {Name}{type}. - {Place}.: {Publisher}" +
                    $", {Year}. - {PageCount} с.";
            }
        }
    }
}
