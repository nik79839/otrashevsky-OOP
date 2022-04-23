using Microsoft.Win32;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ViewWPF.Command;

namespace ViewWPF.ViewModel
{
    public class MainWindowVM : ViewModelBase
    {
        //TODO: VM
        /// <summary>
        /// Список с изданиями
        /// </summary>
        private ObservableCollection<EditionBase> _editionBases;

        /// <summary>
        /// Выбранный элемент listbox
        /// </summary>
        public EditionBase SelectionEditionBase { get; set; }

        /// <summary>
        /// Свойство для фильтрации изданий
        /// </summary>
        public string SearchText { get; set; }
                //TODO:nameof
        
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
                    //TODO: RSDN
                    ObservableCollection<EditionBase> _editionBases1 =
                        new ObservableCollection<EditionBase>(_editionBases.Where(
                            x => x.Info.ToLower().Contains(SearchText.ToLower())));
                    return _editionBases1;
                }
            }
            set
            {
                _editionBases = value;
            }
        }

        /// <summary>
        /// При иннициализации формы
        /// </summary>
        public MainWindowVM()
        {
            Book book1 = new Book("Филиппова А.Г", "История", "учебное пособие",
                "Москва", "Юнион", 2011, 126);
            EditionBases = new ObservableCollection<EditionBase>() { book1 };
        }

        /// <summary>
        /// При нажатии на кнопку сохранения
        /// </summary>
        private void SaveFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "XML приложения (.xml) | * .xml"
            };
            if (saveFileDialog.ShowDialog() == false)
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
                MessageBox.Show(exception.GetBaseException().Message + " Please do it again");
            }
}

        /// <summary>
        /// При нажатии кнопки открытия файла
        /// </summary>
        private void OpenFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "XML приложения (.xml) | * .xml"
            };
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
                MessageBox.Show(exception.GetBaseException().Message + " Incorrect file format");
            }
        }       

        /// <summary>
        /// При нажатии на кнопку добавления элемента
        /// </summary>
        private void AddObject()
        {
            AddObject addObjectWindow = new AddObject();
            AddObjectVM addObjectVM = new AddObjectVM();
            addObjectWindow.DataContext = addObjectVM;
            if (addObjectWindow.ShowDialog() == true && addObjectVM.SelectedEdition != null)
            {
                EditionBases.Add(addObjectVM.SelectedEdition);
            }
        }

        public RelayCommand AddObjectCommand
        {
            get
            {
                return new RelayCommand(obj => AddObject());
            }
        }

        public RelayCommand RemoveObjectCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    EditionBases.Remove(SelectionEditionBase);
                });
            }
        }

        public RelayCommand SaveCommand
        {
            get
            {
                return new RelayCommand(obj => SaveFile());
            }
        }

        public RelayCommand OpenCommand
        {
            get
            {
                return new RelayCommand(obj => OpenFile());
            }
        }
    }
}
