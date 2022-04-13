using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    public partial class AddObject : Window
    {
        public IEnumerable<Type> listNameClass = Assembly.GetAssembly(typeof(EditionBase))
                .GetTypes().Where(type => type.IsSubclassOf(typeof(EditionBase)));

        public AddObject()
        {
            InitializeComponent();
            combo.ItemsSource = listNameClass;       
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(nameof(Book));
        }
    }
}
