using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Thesis
    /// </summary>
    public class Thesis : EditionBase
    {
		/// <summary>
		/// Главный автор
		/// </summary>
		private string _author;

		/// <summary>
		/// Главный автор
		/// </summary>
		public string Author
		{
			get => _author;
			set => _author = value;
		}

		/// <summary>
		/// Specialization
		/// </summary>
		private string _specialization;

		/// <summary>
		/// Specialization
		/// </summary>
		public string Specialization
		{
			get => _specialization;
			set => _specialization = value;
		}

		/// <summary>
		/// University
		/// </summary>
		private string _university;

		/// <summary>
		/// Type
		/// </summary>
		private string _type;

		/// <summary>
		/// Type
		/// </summary>
		public string Type
		{
			get => _type;
			set => _type = value;
		}

		/// <summary>
		/// University
		/// </summary>
		public string University
		{
			get => _university;
			set => _university = value;
		}

		/// <summary>
		/// Конструктор класса
		/// </summary>
		/// <param name="author">Автор</param>
		/// <param name="name">Название</param>
		/// <param name="type">Тип</param>
		/// <param name="specialization">Специализация исследования</param>
		/// <param name="place">Место издания</param>
		/// <param name="university">Университет</param>
		/// <param name="year">Год издания</param>
		/// <param name="pageLimits">Количество страниц</param>
		public Thesis(string author, string name, string type, string specialization, string place,
			string university, string year, string pageCount)
		{
			Author = author;
			Name = name;
			Type = type;
			Specialization = specialization;
			Place = place;
			University = university;
			Year = year;
			PageCount = pageCount;
		}

        public override string Info()
        {
            return $"{Author}. {Name}: {Specialization}: {Type} ; {University}. - {Place}" +
			$", {Year}. - {PageCount} с.";
		}
    }
}
