using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;

namespace ViewWPF
{
    /// <summary>
    /// Логика взаимодействия для AddObject.xaml
    /// </summary>
    public partial class AddObject : Window, INotifyPropertyChanged
    {
        //TODO: VM

        /// <summary>
        /// Выбранный тип в combobox
        /// </summary>
        private Type _selectedTypeOFEdition;

        /// <summary>
        /// Список подтипов класса EditionBase
        /// </summary>
        private IEnumerable<Type> _listNameClass;

        /// <summary>
        /// Список открытых свойств класса
        /// </summary>
        private ObservableCollection<Property> _propertyes;

        /// <summary>
        /// Экземпляр издания
        /// </summary>
        public EditionBase SelectedEdition { get; set; }

        /// <summary>
        /// Список открытых свойств класса
        /// </summary>
        public ObservableCollection<Property> Propertyes
        {
            get
            {
                if (SelectedTypeOFEdition != null)
                {
                    object source = SelectedEdition;
                    _propertyes = new ObservableCollection<Property>();
                    foreach (var pi in PropertyInfo(source))
                    {
                        _propertyes.Add(new Property(source, pi));
                    }
                }
                return _propertyes;
            }
            set
            {
                _propertyes = value;
                //TODO:nameof
                OnPropertyChanged("Propertyes");
            }
        }

        /// <summary>
        /// Список подтипов класса EditionBase
        /// </summary>
        public IEnumerable<Type> ListNameClass
        {
            get => _listNameClass;
            set
            {
                _listNameClass = value;
                //TODO:nameof
                OnPropertyChanged("ListNameClass");
            }
        }

        /// <summary>
        /// Выбранный тип в combobox
        /// </summary>
        public Type SelectedTypeOFEdition
        {
            get => _selectedTypeOFEdition;
            set
            {
                _selectedTypeOFEdition = value;
                switch (_selectedTypeOFEdition.Name)
                {
                    case nameof(Book):
                        SelectedEdition = new Book();
                        break;
                    case nameof(Collection):
                        SelectedEdition = new Collection();
                        break;
                    case nameof(Magazine):
                        SelectedEdition = new Magazine("Вопросы", "Научный журнал", "ООО 'Редация'",
                            "Москва", "А.А. Искендеров", "2011", "518");
                        break;
                    case nameof(Thesis):
                        SelectedEdition = new Thesis();
                        break;
                }
                //OnPropertyChanged("SelectedTypeOFEdition");
                //TODO: nameof
                OnPropertyChanged("Propertyes");
            }
        }

        /// <summary>
        /// При иннициализации формы
        /// </summary>
        public AddObject()
        {          
            InitializeComponent();
            ListNameClass =new List<Type>();
            ListNameClass = Assembly.GetAssembly(typeof(EditionBase))
                .GetTypes().Where(type => type.IsSubclassOf(typeof(EditionBase)));
        }

        /// <summary>
        /// Получение свойств объекта класса
        /// </summary>
        /// <param name="editionBase">Объект</param>
        /// <returns>Список свойств</returns>
        private List<PropertyInfo> PropertyInfo(object editionBase)
        {
            var propertyInfo = new List<PropertyInfo>();
            foreach (var info in editionBase.GetType().GetProperties())
            {
                //TODO: Item?
                if (info.Name == nameof(EditionBase.Info) || info.Name == "Item")
                {
                    continue;
                }
                propertyInfo.Add(info);
            }
            return propertyInfo;
        }       

        /// <summary>
        /// При нажатии кнопки "Ок"
        /// </summary>
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var property in Propertyes)
            {
                if (property.Value.ToString() == "")
                {                  
                    property.Value = "";
                }

                if (property.PropertyInfo.GetValue(property.Source) == null) return;
            }
            this.DialogResult = true;
        }

        /// <summary>
        /// Событие изменения свойства
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Уведомление об изменении свойства
        /// </summary>
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            //TODO: {}
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
