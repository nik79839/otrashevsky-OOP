﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ViewWPF.ViewModel
{
    //TODO: XML
    /// <summary>
    /// ViewModel
    /// </summary>
    public class AddObjectVM : ObservableObject
    {
        //TODO: RSDN
        /// <summary>
        /// Выбранный тип в combobox
        /// </summary>
        private Type _selectedTypeOfEdition;

        /// <summary>
        /// Список открытых свойств класса
        /// </summary>
        private ObservableCollection<Property> _propertyes;

        /// <summary>
        /// View
        /// </summary>
        private AddObject _view;

        //TODO: RSDN
        /// <summary>
        /// Экземпляр издания
        /// </summary>
        public bool IsVisibleRandomButton { get; set; }

        /// <summary>
        /// Экземпляр издания
        /// </summary>
        public EditionBase SelectedEdition { get; set; }

        /// <summary>
        /// Список подтипов класса EditionBase
        /// </summary>
        public List<Type> ListNameClass { get; set; }

        /// <summary>
        /// Команда при нажатии кнопки "Ок"
        /// </summary>
        public RelayCommand OkCommand { get; }

        /// <summary>
        /// Команда для создания случайного объекта
        /// </summary>
        public RelayCommand RandomDataCommand { get; }

        /// <summary>
        /// Список открытых свойств класса
        /// </summary>
        public ObservableCollection<Property> Propertyes
        {
            get
            {
                object source = SelectedEdition;
                _propertyes = new ObservableCollection<Property>();
                foreach (var pi in PropertyInfo(source))
                {
                    _propertyes.Add(new Property(source, pi));
                }

                return _propertyes;
            }
            set
            {
                _propertyes = value;
                OnPropertyChanged(nameof(Propertyes));
            }
        }

        /// <summary>
        /// Выбранный тип в combobox
        /// </summary>
        public Type SelectedTypeOFEdition
        {
            get => _selectedTypeOfEdition;
            set
            {
                _selectedTypeOfEdition = value;
                switch (_selectedTypeOfEdition.Name)
                {
                    case nameof(Book):
                        SelectedEdition = new Book();
                        break;
                    case nameof(Collection):
                        SelectedEdition = new Collection();
                        break;
                    case nameof(Magazine):
                        SelectedEdition = new Magazine("Вопросы", "Научный журнал",
                            "ООО 'Редация'", "Москва", "А.А. Искендеров", 2011, 518);
                        break;
                    case nameof(Thesis):
                        SelectedEdition = new Thesis();
                        break;
                }
                OnPropertyChanged(nameof(Propertyes));
            }
        }

        /// <summary>
        /// При иннициализации формы
        /// </summary>
        public AddObjectVM()
        {
            ListNameClass = Assembly.GetAssembly(typeof(EditionBase))
                .GetTypes().Where(type => type.IsSubclassOf(typeof(EditionBase))).ToList();
            SelectedTypeOFEdition = ListNameClass[0];
            OkCommand = new RelayCommand(OkButton);
            RandomDataCommand = new RelayCommand(RamdomData);
#if (DEBUG)
            IsVisibleRandomButton = true;
#else
            IsVisibleRandomButton = false;
#endif
            _view = new AddObject();
            _view.DataContext = this;
        }

        public EditionBase ShowDialog()
        {
            return _view.ShowDialog() == true 
                ? SelectedEdition 
                : null;
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
                if (info.Name == nameof(EditionBase.Info))
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
        private void OkButton()
        {
            foreach (var property in Propertyes)
            {
                property.Value = property.Value;
                if (property.PropertyInfo.GetValue(property.Source) == null ||
                    property.PropertyInfo.GetValue(property.Source).ToString()=="0")
                {
                    return;
                }
            }
            _view.DialogResult = true;
        }

        /// <summary>
        /// Случайное заполнение полей объекта
        /// </summary>
        private void RamdomData()
        {
            foreach (var property in Propertyes)
            {
                if (property.PropertyInfo.PropertyType == typeof(string))
                {
                    property.Value = "Random " + property.PropertyName;
                }
            }
            Random random = new Random();
            SelectedEdition.Year = random.Next(1, DateTime.Now.Year);
            SelectedEdition.PageCount = random.Next(1, 10000);
            OnPropertyChanged(nameof(Propertyes));
        }
    }
}
