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
			set => _author = CheckEmptyAndLanguage(value);
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
			set => _specialization = CheckEmptyOrNull(value);
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
			set => _type = CheckEmptyAndLanguage(value);
		}

		/// <summary>
		/// University
		/// </summary>
		public string University
		{
			get => _university;
			set => _university = CheckEmptyOrNull(value);
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
			: base(name, place, year, pageCount)
		{
			Author = author;
			Type = type;
			Specialization = specialization;
			University = university;
		}

		/// <summary>
		/// Конструктор класса для сериализации
		/// </summary>
		public Thesis() : this("default", "default", "default", "default", "default", "default", "1","1")
		{
		}

		public override string Info
		{
			get
			{
				return $"{Author}. {Name}: {Specialization}: {Type} ; {University}. - {Place}" +
				$", {Year}. - {PageCount} с.";
			}
		}
    }
}
