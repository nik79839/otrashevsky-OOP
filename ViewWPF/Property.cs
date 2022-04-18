using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace ViewWPF
{
    /// <summary>
    /// Класс для описания свойства
    /// </summary>
    public class Property
    {
        /// <summary>
        /// Объект для получения списка свойств
        /// </summary>
        public object Source { get; set; }

        /// <summary>
        /// Объект свойства
        /// </summary>
        public PropertyInfo PropertyInfo { get; set; }

        /// <summary>
        /// Имя свойства
        /// </summary>
        public string PropertyName { get; }

        /// <summary>
        /// Значение свойства
        /// </summary>
        public object Value
        {
            get
            {
                if (PropertyInfo.GetValue(Source) == null)
                {
                    return "";
                }
                return PropertyInfo.GetValue(Source);
            }
            set
            {
                try
                {
                    PropertyInfo.SetValue(Source, value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(PropertyName+"\n " + ex.InnerException.Message,"",
                        MessageBoxButton.OK,MessageBoxImage.Error);
                }
            }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="source">объект</param>
        /// <param name="propertyInfo">свойство</param>
        public Property(object source, PropertyInfo propertyInfo)
        {
            Source = source;
            PropertyInfo = propertyInfo;
            PropertyName = propertyInfo.Name.Substring(0,1)+Regex.Replace(
                propertyInfo.Name.Substring(1),@"([A-Z])", " $1").Trim().ToLower();
        }

    }
}
