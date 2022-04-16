using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ViewWPF
{
    /// <summary>
    /// Логика взаимодействия для AddObject.xaml
    /// </summary>
    public partial class AddObject : Window,INotifyPropertyChanged
    {
        private Type _selectedTypeOFEdition;
        private IEnumerable<Type> _listNameClass;
        private ObservableCollection<Property> _propertyes;
        public EditionBase _selectedEdition { get; set; }
        public ObservableCollection<Property> Propertyes
        {
            get
            {
                return _propertyes;
            }
            set
            {
                _propertyes = value;
                OnPropertyChanged("Propertyes");
            }
        }
        public IEnumerable<Type> ListNameClass
        {
            get
            {
                return _listNameClass;
            }
            set
            {
                _listNameClass = value;
                OnPropertyChanged("ListNameClass");
            }
        }

        public Type SelectedTypeOFEdition
        {
            get
            {
                return _selectedTypeOFEdition;
            }
            set
            {
                _selectedTypeOFEdition = value;
                OnPropertyChanged("SelectedTypeOFEdition");
            }
        }

        public AddObject()
        {          
            InitializeComponent();
            DataContext = this;
            ListNameClass =new List<Type>();
            ListNameClass = Assembly.GetAssembly(typeof(EditionBase))
                .GetTypes().Where(type => type.IsSubclassOf(typeof(EditionBase)));
        }

        private List<PropertyInfo> PropertyInfo(object editionBase)
        {
            var propertyInfo = new List<PropertyInfo>();
            foreach (var info in editionBase.GetType().GetProperties())
            {
                if (info.Name == nameof(EditionBase.Info) || info.Name == "Item")
                {
                    continue;
                }
                propertyInfo.Add(info);
            }
            return propertyInfo;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private void combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (SelectedTypeOFEdition.Name)
            {
                case nameof(Book):
                    {
                        _selectedEdition = new Book();
                        break;
                    }
                case nameof(Collection):
                    {
                        _selectedEdition = new Collection("Инновации", "Международная конференция",
                "Москва", "Московский Государственный Унверститет", "2012", "58");
                        break;
                    }
                case nameof(Magazine):
                    {
                        _selectedEdition = new Magazine("Вопросы", "Научный журнал", "ООО 'Редация'",
                "Москва", "А.А. Искендеров", "2011", "518");
                        break;
                    }
                case nameof(Thesis):
                    {
                        _selectedEdition = new Thesis("Филиппова А.Г", "Название диссертации",
                "диссертация на соискание ученой степени", "специальность 13.00.01 'Общая педагогика'",
                "Москва", "Кузбасская государственная педагогическая академия", "2000", "255");
                        break;
                    }
            }
            object source = _selectedEdition;
            var propertyes=new ObservableCollection<Property>();
            foreach (var pi in PropertyInfo(source))
            {
                propertyes.Add(new Property(source, pi));
            }               
            Propertyes = propertyes;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult=true;
        }
    }
}
