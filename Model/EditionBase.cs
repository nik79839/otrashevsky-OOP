﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Edition (book, collection, magazine, article)
    /// </summary>
    public class EditionBase
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
            set => _name = value;
        }

        /// <summary>
        /// Place of publication
        /// </summary>
        public string Place
        {
            get => _year;
            set => _year = value;
        }

        /// <summary>
        /// Year of publication
        /// </summary>
        public string Year
        {
            get => _pageCount;
            set => _pageCount = value;
        }

        /// <summary>
        /// Count of pages
        /// </summary>
        public string PageCount
        {
            get => _pageCount;
            set => _pageCount = value;
        }


        //public abstract string Info { get; }

    }
}
