using System;
using System.Reflection;
using System.Text.RegularExpressions;
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
                else
                {
                    if (PropertyInfo.GetValue(Source).ToString() == "0")
                    {
                        return "";
                    }
                    return PropertyInfo.GetValue(Source);
                }
            }
            set
            {
                try
                {
                    if (PropertyInfo.PropertyType == typeof(int))
                    {
                        PropertyInfo.SetValue(Source, Convert.ToInt32(value));
                    }
                    else
                    {
                        PropertyInfo.SetValue(Source, value);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(PropertyName+"\n " + ex.GetBaseException().Message,"",
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
