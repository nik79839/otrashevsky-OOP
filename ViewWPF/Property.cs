using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ViewWPF
{
    public class Property
    {
        object _source;
        PropertyInfo _propertyInfo;
        public string PropertyName { get; }

        public object Value
        {
            get => _propertyInfo.GetValue(_source);
            set => _propertyInfo.SetValue(_source,
                       Convert.ChangeType(value, _propertyInfo.PropertyType));
        }

        public Property(object source, PropertyInfo propertyInfo)
        {
            _source = source;
            _propertyInfo = propertyInfo;
            PropertyName = propertyInfo.Name;
        }

    }
}
