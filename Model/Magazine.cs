using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Magazine
    /// </summary>
    public class Magazine : EditionBase
    {
        /// <summary>
        /// Founder
        /// </summary>
        private string _founder;

        /// <summary>
        /// Type of book
        /// </summary>
        private string _type;

        /// <summary>
		/// Main Editor
		/// </summary>
		private string _mainEditor;

        /// <summary>
        /// Founder
        /// </summary>
        public string Founder
        {
            get => _founder;
            set => _founder = CheckEmptyOrNull(value);
        }

        /// <summary>
        /// Type
        /// </summary>
        public string Type
        {
            get => _type;
            set => _type = CheckEmptyAndLanguage(value);
        }

        /// <summary>
        /// Main Editor
        /// </summary>
        public string MainEditor
        {
            get => _mainEditor;
            set => _mainEditor = CheckEmptyAndLanguage(value);
        }

        /// <summary>
		/// Конструктор класса
		/// </summary>
		/// <param name="name">name</param>
		/// <param name="type">type</param>
		/// <param name="founder">founder</param>
		/// <param name="place">Место place</param>
		/// <param name="mainEditor">mainEditor</param>
		/// <param name="year">year</param>
		/// <param name="pageCount">count of pages</param>
		public Magazine(string name, string type, string founder, string place,
            string mainEditor, string year, string pageCount)
            :base(name, place, year, pageCount)
        {
            Type = type;
            Founder = founder;
            MainEditor = mainEditor;
        }

        /// <summary>
		/// Конструктор класса для сериализации
		/// </summary>
		public Magazine() : this("default", "default", "default", "default", "default", "1","1")
        {
        }

        //TODO: XML
        /// <summary>
        /// Information
        /// </summary>
        /// <returns></returns>
        public override string Info
        {
            get
            {
                return $"{Name}: {Type} / учредитель {Founder}; ред. {MainEditor}. - {Place}" +
                $", {Year}. - {PageCount} с.";
            }
        }
    }
}
