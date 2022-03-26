using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Collection
    /// </summary>
    public class Collection : EditionBase
    {
		/// <summary>
		/// Name Of Conference
		/// </summary>
		private string _nameOfConference;

		/// <summary>
		/// Publisher
		/// </summary>
		private string _publisher;

		/// <summary>
		/// Publisher
		/// </summary>
		public string Publisher
		{
			get => _publisher;
			set => _publisher = value;
		}

		/// <summary>
		/// Name Of Conference
		/// </summary>
		public string NameOfConference
		{
			get => _nameOfConference;
			set => _nameOfConference = value;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="name">name</param>
		/// <param name="nameOfConference">name Of Conference</param>
		/// <param name="place">place</param>
		/// <param name="publisher">publisher</param>
		/// <param name="year">year</param>
		/// <param name="pageCount">page count</param>
		public Collection(string name, string nameOfConference, string place,
			string publisher, string year, string pageCount)
		{
			Name = name;
			NameOfConference = nameOfConference;
			Place = place;
			Publisher = publisher;
			Year = year;
			PageCount = pageCount;
		}

        public override string Info()
        {
            return $"{Name}: {NameOfConference}. - {Place}: {Publisher}," +
			$" {Year}. - {PageCount} с.";
		}
    }
}
