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
        private string _searchText;
        public EditionBase SelectionEditionBase { get; set; }
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
                    ObservableCollection<EditionBase> _editionBases1 = new ObservableCollection<EditionBase>(_editionBases.
                        Where(x => x.Info.ToLower().Contains(SearchText.ToLower())));
                    return _editionBases1;
                }
            }
            set
            {
                _editionBases = value;
                OnPropertyChanged("EditionBases");
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Book book1 = new Book("Филиппова А.Г", "История", "учебное пособие",
                "Москва", "Юнион", "2011", "126");
            EditionBases = new ObservableCollection<EditionBase>();
            EditionBases.Add(book1);
        }

        private void AddObjectButton_Click(object sender, RoutedEventArgs e)
        {
            AddObject addObjectWindow=new AddObject();
            if (addObjectWindow.ShowDialog()==true)
            {
                EditionBases.Add(addObjectWindow.SelectedEdition);
            }
        }

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

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private void RemoveObjectButton_Click(object sender, RoutedEventArgs e)
        {
            EditionBases.Remove(SelectionEditionBase);
        }
    }
}
