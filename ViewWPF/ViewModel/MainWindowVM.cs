using Microsoft.Win32;
using Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
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

        /// <summary>
        /// Command to open addobject window
        /// </summary>
        public RelayCommand AddObjectCommand { get; }

        /// <summary>
        /// Command to remove object
        /// </summary>
        public RelayCommand RemoveObjectCommand { get; }

        /// <summary>
        /// Command to save
        /// </summary>
        public RelayCommand SaveCommand { get; }

        /// <summary>
        /// Command to open
        /// </summary>
        public RelayCommand OpenCommand { get; }

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
            SaveCommand = new RelayCommand(obj => SaveFile());
            OpenCommand = new RelayCommand(obj => OpenFile());
            AddObjectCommand=new RelayCommand(obj => AddObject());
            RemoveObjectCommand = new RelayCommand(obj => EditionBases.Remove(SelectionEditionBase));
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
            AddObjectVM addObjectVM = new AddObjectVM();
            if (addObjectVM.ShowDialog() != null)
            {
                EditionBases.Add(addObjectVM.SelectedEdition);
            }
        }
    }
}
