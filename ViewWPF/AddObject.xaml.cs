using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using ViewWPF.ViewModel;

namespace ViewWPF
{
    /// <summary>
    /// Логика взаимодействия для AddObject.xaml
    /// </summary>
    public partial class AddObject : Window
    {
        /// <summary>
        /// При иннициализации формы
        /// </summary>
        public AddObject()
        {          
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

    }
}
