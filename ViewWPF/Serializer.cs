using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ViewWPF
{
	/// <summary>
	/// Класс для сериализации и десереализации
	/// </summary>
    public class Serializer
    {
		// <summary>
		/// Сериализатор
		/// </summary>
		private static readonly XmlSerializer _xmlSerializer =
			new XmlSerializer(typeof(ObservableCollection<EditionBase>),
				new[]
				{
					typeof(Book),
					typeof(Thesis),
					typeof(Collection),
					typeof(Magazine)
				});

		/// <summary>
		/// Cохранение в файл
		/// </summary>
		public static void SaveFile(string path, ObservableCollection<EditionBase> editionList)
		{
			using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
			{
				_xmlSerializer.Serialize(fs, editionList);
			}
		}

		/// <summary>
		/// Открытие файла
		/// </summary>
		public static ObservableCollection<EditionBase> OpenFile(string path)
		{
			ObservableCollection<EditionBase> editionList = new ObservableCollection<EditionBase>();
			using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
			{
				editionList = (ObservableCollection<EditionBase>)_xmlSerializer.Deserialize(fs);
			}
			return editionList;
		}
	}
}

