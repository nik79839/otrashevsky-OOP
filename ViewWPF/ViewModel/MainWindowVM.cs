using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace ViewWPF.ViewModel
{
    //TODO: XML
    /// <summary>
    /// ViewModel
    /// </summary>
    public class MainWindowVM : ObservableObject
    {
        /// <summary>
        /// Список с изданиями
        /// </summary>
        private ObservableCollection<EditionBase> _editionBases;

        /// <summary>
        /// Поиск
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
                OnPropertyChanged(nameof(EditionBases));
            }
        }

        /// <summary>
        /// Команда открытия окна для добавления объекта
        /// </summary>
        public RelayCommand AddObjectCommand { get; }

        /// <summary>
        /// Команда удаления объекта
        /// </summary>
        public RelayCommand RemoveObjectCommand { get; }

        /// <summary>
        /// Команда сохранения в файл
        /// </summary>
        public RelayCommand SaveCommand { get; }

        /// <summary>
        /// Команжа открытия файла
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
                    return new ObservableCollection<EditionBase>(_editionBases.Where(
                            x => x.Info.ToLower().Contains(SearchText.ToLower())));
                }
            }
            set
            {
                _editionBases = value;
                OnPropertyChanged(nameof(EditionBases));
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
            SaveCommand = new RelayCommand(SaveFile);
            OpenCommand = new RelayCommand(OpenFile);
            AddObjectCommand = new RelayCommand(AddObject);
            RemoveObjectCommand = new RelayCommand(() => DeleteObjects());
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
                MessageBox.Show(exception.GetBaseException().Message + 
                    " Please do it again");
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
                MessageBox.Show(exception.GetBaseException().Message + 
                    " Incorrect file format");
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

        /// <summary>
        /// Удаление выбранного элемента
        /// </summary>
        /// <param name="obj"></param>
        private void DeleteObjects()
        {
            while (SelectionEditionBase !=null)
            {
                EditionBases.Remove(SelectionEditionBase);
            }
        }
    }
}
