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
    public class Property
    {
        object _source;
        PropertyInfo _propertyInfo;
        public string PropertyName { get; }

        public object Value
        {
            get
            {
                return _propertyInfo.GetValue(_source);
            }
            set
            {
                try
                {
                    _propertyInfo.SetValue(_source, value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.InnerException.Message);
                }
            }
        }

        public Property(object source, PropertyInfo propertyInfo)
        {
            _source = source;
            _propertyInfo = propertyInfo;
            PropertyName = Regex.Replace(propertyInfo.Name, @"([A-Z])", " $1").Trim().ToLower()+":"; ;
        }

    }
}
