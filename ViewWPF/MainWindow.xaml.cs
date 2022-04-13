using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
using Model;

namespace ViewWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Список с изданиями
        /// </summary>
        public ObservableCollection<EditionBase> EditionBases = new ObservableCollection<EditionBase>();
        public MainWindow()
        {
            InitializeComponent();
            items.ItemsSource = EditionBases;
            //items.DataContext = EditionBases;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Book book1 = new Book("Филиппова А.Г", "История", "учебное пособие",
                "Москва", "Юнион", "2011", "126");
            EditionBases.Add(book1);
            
        }

        private void AddObjectButton_Click(object sender, RoutedEventArgs e)
        {
            AddObject addObjectWindow=new AddObject();
            addObjectWindow.Show();
        }
    }
}
