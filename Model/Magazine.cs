﻿using System;
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
            set => _founder = CheckEmpty(value);
        }

        /// <summary>
        /// Type
        /// </summary>
        public string Type
        {
            get => _type;
            set
            {
                CheckEmpty(value);
                CheckLanguage(value);
                _type = value;
            }
        }

        /// <summary>
        /// Main Editor
        /// </summary>
        public string MainEditor
        {
            get => _mainEditor;
            set
            {
                CheckEmpty(value);
                CheckLanguage(value);
                _mainEditor = value;
            }
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
            string mainEditor, int year, int pageCount)
            :base(name, place, year, pageCount)
        {
            Type = type;
            Founder = founder;
            MainEditor = mainEditor;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        protected Magazine()
        {
        }

        /// <summary>
        /// Information
        /// </summary>
        public override string Info =>
            $"{Name}: {Type} / учредитель {Founder}; ред. {MainEditor}. - {Place}" +
            $", {Year}. - {PageCount} с.";
    }
}
