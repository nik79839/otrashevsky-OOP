using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using Model;

namespace ViewWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        /// <summary>
        /// Список с изданиями
        /// </summary>
        private ObservableCollection<EditionBase> _editionBases;

        /// <summary>
        /// Переменная для фильтрации изданий
        /// </summary>
        private string _searchText;

        /// <summary>
        /// Выбранный элемент listbox
        /// </summary>
        public EditionBase SelectionEditionBase { get; set; }

        /// <summary>
        /// Свойство для фильтрации изданий
        /// </summary>
        public string SearchText
        {
            get
            {
                return _searchText;
            }
            set
            {
                _searchText = value;
                OnPropertyChanged("SearchText");
                OnPropertyChanged("EditionBases");
            }
        }

        /// <summary>
        /// Список изданий
        /// </summary>
        public ObservableCollection<EditionBase> EditionBases
        {
            get
            {
                if (string.IsNullOrEmpty(SearchText))
                {
                    return _editionBases;
                }
                else
                {
                    ObservableCollection<EditionBase> _editionBases1 = new ObservableCollection<EditionBase>(
                        _editionBases.Where(x => x.Info.ToLower().Contains(SearchText.ToLower())));
                    return _editionBases1;
                }
            }
            set
            {
                _editionBases = value;
                OnPropertyChanged("EditionBases");
            }
        }

        /// <summary>
        /// При иннициализации формы
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Book book1 = new Book("Филиппова А.Г", "История", "учебное пособие",
                "Москва", "Юнион", "2011", "126");
            EditionBases = new ObservableCollection<EditionBase>() { book1 };
        }

        /// <summary>
        /// При нажатии на кнопку добавления элемента
        /// </summary>
        private void AddObjectButton_Click(object sender, RoutedEventArgs e)
        {
            AddObject addObjectWindow=new AddObject();
            if (addObjectWindow.ShowDialog()==true)
            {
                EditionBases.Add(addObjectWindow.SelectedEdition);
            }
        }

        /// <summary>
        /// При нажатии на кнопку сохранения
        /// </summary>
        private void SaveMenu_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML приложения (.xml) | * .xml";
            if (saveFileDialog.ShowDialog()==false)
            {
                return;
            }
            string filename = saveFileDialog.FileName;
            try
            {
                Serializer.SaveFile(filename, EditionBases);
                MessageBox.Show("File saved");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + "Please do it again");
            }
}

        /// <summary>
        /// При нажатии кнопки сохранения файла
        /// </summary>
        private void OpenMenu_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML приложения (.xml) | * .xml";
            if (openFileDialog.ShowDialog() == false)
            {
                return;
            }
            string filename = openFileDialog.FileName;
            try
            {
                EditionBases = Serializer.OpenFile(filename);
                MessageBox.Show("File opened");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + "Incorrect file format");
            }
        }

        /// <summary>
        /// При нажатии кнопки удаления
        /// </summary>
        private void RemoveObjectButton_Click(object sender, RoutedEventArgs e)
        {
            EditionBases.Remove(SelectionEditionBase);
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
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
