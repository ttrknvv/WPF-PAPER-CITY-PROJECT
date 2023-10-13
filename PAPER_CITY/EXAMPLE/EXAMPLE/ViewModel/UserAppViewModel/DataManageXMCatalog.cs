using EXAMPLE.Model;
using EXAMPLE.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EXAMPLE.ViewModel.UserAppViewModel
{
    public class DataManageXMCatalog : INotifyPropertyChanged
    {
        private ObservableCollection<Books> allBooks = new ObservableCollection<Books>(DataWorkerUserApp.GetCatalog());
        private ObservableCollection<Books> bookNow = new ObservableCollection<Books>();
        public ObservableCollection<Reviews> allReviews = new ObservableCollection<Reviews>();
        public ObservableCollection<Books> AllBooks
        {
            get
            {
                return allBooks;
            }
        }
        public ObservableCollection<Books> BookNow
        {
            get
            {
                return bookNow;
            }
        }
        public ObservableCollection<Reviews> AllReviews
        {
            get
            {
                return allReviews;
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private RelayCommand clickBook;
        private RelayCommand addBusket;
        private RelayCommand filterCatalog;
        private RelayCommand noSort;
        private RelayCommand descPriceSort;
        private RelayCommand incPriceSort;
        private RelayCommand popularitySort;
        public RelayCommand ClickBook
        {
            get
            {
                return clickBook ?? new RelayCommand(obj =>
                {
                    try
                    {
                        ClickOnBook(obj as Books);
                        allReviews = DataWorkerUserApp.GetReviews(bookNow.First().ID_BOOK);
                        DataWorkerUserApp.AddPopularity((obj as Books).ID_BOOK, 1);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ErrorClick", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
            }
        }
        public RelayCommand AddBusket
        {
            get
            {
                return addBusket ?? new RelayCommand(obj =>
                {
                    try
                    {
                        var list = obj as ObservableCollection<Books>;
                        AddBookToBusket(bookNow.First().ID_BOOK);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ErrorAdd", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
            }
        }
        public RelayCommand FilterCatalog
        {
            get
            {
                return filterCatalog ?? new RelayCommand(obj =>
                {
                    try
                    {
                        FilterCatalogMethod(obj as CatalogPage);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ErrorFilter", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
            }
        }
        public RelayCommand NoSort
        {
            get
            {
                return noSort ?? new RelayCommand(obj =>
                {
                    try
                    {
                        NoSortMethod();
                        NotifyPropertyChange("AllBooks");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ErrorSort", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
            }
        }
        public RelayCommand DescPriceSort
        {
            get
            {
                return descPriceSort ?? new RelayCommand(obj =>
                {
                    try
                    {
                        DescPriceSortMethod();
                        NotifyPropertyChange("AllBooks");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ErrorSort", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
            }
        }
        public RelayCommand IncPriceSort
        {
            get
            {
                return incPriceSort ?? new RelayCommand(obj =>
                {
                    try
                    {
                        IncPriceSortMethod();
                        NotifyPropertyChange("AllBooks");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ErrorSort", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
            }
        }
        public RelayCommand PopularitySort
        {
            get
            {
                return popularitySort ?? new RelayCommand(obj =>
                {
                    try
                    {
                        PopularitySortMethod();
                        NotifyPropertyChange("AllBooks");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ErrorSort", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
            }
        }
        public void ClickOnBook(Books book)
        {
            if (book != null)
            {
                if (bookNow.Count != 0)
                {
                    bookNow.Clear();
                }
                bookNow.Add(book);
            }
        }

        public void AddBookToBusket(int id_book)
        {
            DataWorkerUserApp.AddBookOnBusket(id_book);
        }
        private void FilterCatalogMethod(CatalogPage page)
        {
            string text = page.FilterText.Text.ToLower();
            if (!string.IsNullOrEmpty(text))
            {
                allBooks = new ObservableCollection<Books>(DataWorkerUserApp.GetCatalog().Where(el => el.GENRE.ToLower().Contains(text) ||
                                                                                                  el.NAME.ToLower().Contains(text) ||
                                                                                                  el.AUTHOR.ToLower().Contains(text)))
                                                                                                  ;
            }
            else
            {
                allBooks = new ObservableCollection<Books>(DataWorkerUserApp.GetCatalog());
            }
            NotifyPropertyChange("AllBooks");
        }
        private void NoSortMethod()
        {
            allBooks = new ObservableCollection<Books>(DataWorkerUserApp.GetCatalog());
        }
        private void DescPriceSortMethod()
        {
            allBooks = new ObservableCollection<Books>(allBooks.OrderByDescending(el => el.COST));
        }
        private void IncPriceSortMethod()
        {
            allBooks = new ObservableCollection<Books>(allBooks.OrderBy(el => el.COST));
        }
        private void PopularitySortMethod()
        {
            allBooks = new ObservableCollection<Books>(allBooks.OrderByDescending(el => el.POPULARITY));
        }
    }

}
