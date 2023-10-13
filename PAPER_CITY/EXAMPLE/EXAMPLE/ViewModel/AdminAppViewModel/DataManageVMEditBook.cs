using EXAMPLE.Model;
using EXAMPLE.View;
using EXAMPLE.View.AdminAppView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EXAMPLE.ViewModel.AdminAppViewModel
{
    public class DataManageVMEditBook : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private ObservableCollection<Books> allBooks = DataWorkerAdminApp.GetCatalog();
        private ObservableCollection<Books> bookNow = new ObservableCollection<Books>();
        private ObservableCollection<Reviews> allReviews = new ObservableCollection<Reviews>();
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
        private RelayCommand clickBook;
        private RelayCommand filterCatalog;
        private RelayCommand noSort;
        private RelayCommand descPriceSort;
        private RelayCommand incPriceSort;
        private RelayCommand popularitySort;
        private RelayCommand addNewBook;
        private RelayCommand addBookFinally;
        private RelayCommand removeBook;
        private RelayCommand changeBook;
        private RelayCommand refreshBook;
        private RelayCommand deleteReview;
        public RelayCommand ClickBook
        {
            get
            {
                return clickBook ?? new RelayCommand(obj =>
                {
                    try
                    {
                        if ((obj as Books) != null)
                        {
                            ClickBookMethod((obj as Books));
                            allReviews = DataWorkerAdminApp.GetReviews(bookNow.First().ID_BOOK);
                            NotifyPropertyChange("BookNow");
                            NotifyPropertyChange("AllReviews");
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ErrorClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        if ((obj as EditBooksPage) != null)
                        {
                            FilterCatalogMethod(obj as EditBooksPage);
                            NotifyPropertyChange("AllBooks");
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ErrorFilter", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ErrorSort", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ErrorSort", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show(ex.Message, "ErrorSort", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show(ex.Message, "ErrorSort", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                });
            }
        }
        public RelayCommand AddNewBook
        {
            get
            {
                return addNewBook ?? new RelayCommand(obj =>
                {
                    try
                    {
                        AddNewBookMethod();
                        allBooks.Clear();
                        allBooks = DataWorkerAdminApp.GetCatalog();
                        NotifyPropertyChange("AllBooks");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ErrorAddBook", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                });
            }
        }
        public RelayCommand AddBookFinally
        {
            get
            {
                return addBookFinally ?? new RelayCommand(obj =>
                {
                    try
                    {
                        var wind = (obj as AddBookWindow);
                        FinalyAddBook(wind);
                        NotifyPropertyChange("AllBooks");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ErrorAddBook", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                });
            }
        }
        public RelayCommand RemoveBook
        {
            get
            {
                return removeBook ?? new RelayCommand(obj =>
                {
                    try
                    {
                        if (bookNow.Count > 0)
                        {
                            DataWorkerAdminApp.DeleteBook(bookNow.First());
                            bookNow.Clear();
                            (obj as EditBooksPage).Button_Click(null, null);
                            allBooks.Clear();
                            allBooks = DataWorkerAdminApp.GetCatalog();
                            NotifyPropertyChange("AllBooks");
                            MessageBox.Show("Книга успешно удалена!", "RemoveBook", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Произошла ошибка! Книга не удалена!", "RemoveBook", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Произошла ошибка! Книга не удалена!", "RemoveBook", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                });
            }
        }
        public RelayCommand ChangeBook
        {
            get
            {
                return changeBook ?? new RelayCommand(obj => {
                    try
                    {
                        ChangeBookMethod(bookNow.First());
                        allBooks.Clear();
                        allBooks = DataWorkerAdminApp.GetCatalog();
                        NotifyPropertyChange("AllBooks");
                        NotifyPropertyChange("BookNow");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ErrorChageBook", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                });
            }
           
        }
        public RelayCommand DeleteReview
        {
            get
            {
                return deleteReview ?? new RelayCommand(obj => {
                    try
                    {
                        RemoveReviewMethod(obj as Reviews);
                        allReviews.Clear();
                        allReviews = DataWorkerAdminApp.GetReviews(bookNow.First().ID_BOOK);
                        NotifyPropertyChange("AllReviews");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ErrorDeleteReview", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                });
            }

        }
        public RelayCommand RefreshBook
        {
            get
            {
                return refreshBook ?? new RelayCommand(obj => {
                    try
                    {
                        allBooks = DataWorkerAdminApp.GetCatalog();
                        NotifyPropertyChange("AllBooks");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ErrorRefresh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                });
            }

        }
        public void ClickBookMethod(Books book)
        {
            if(bookNow.Count > 0)
            {
                bookNow.Clear();
            }
            bookNow.Add(book);
        }
        private void FilterCatalogMethod(EditBooksPage page)
        {
            string text = page.FilterCatalog.Text.ToLower();
            if (!string.IsNullOrEmpty(text))
            {
                allBooks = new ObservableCollection<Books>(DataWorkerUserApp.GetCatalog().Where(el => el.GENRE.ToLower().Contains(text) ||
                                                                                                  el.NAME.ToLower().Contains(text) ||
                                                                                                  el.AUTHOR.ToLower().Contains(text) ||
                                                                                                  Convert.ToString(el.ID_BOOK).Contains(text)))
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
            allBooks = new ObservableCollection<Books>(DataWorkerUserApp.GetCatalog().OrderByDescending(el => el.COST));
        }
        private void IncPriceSortMethod()
        {
            allBooks = new ObservableCollection<Books>(DataWorkerUserApp.GetCatalog().OrderBy(el => el.COST));
        }
        private void PopularitySortMethod()
        {
            allBooks = new ObservableCollection<Books>(DataWorkerUserApp.GetCatalog().OrderByDescending(el => el.POPULARITY));
        }
        private void AddNewBookMethod()
        {
            AddBookWindow bookNew = new AddBookWindow();
            if(bookNew.ShowDialog() == true)
            {
                MessageBox.Show("Книга успешно добавлена!", "AddBook", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void FinalyAddBook(AddBookWindow wind)
        {
            if (wind != null)
            {
                if (String.IsNullOrWhiteSpace(wind.NameBook.Text))
                {
                    MessageBox.Show("Вы не указали название книги!", "ErrorAddBook", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (String.IsNullOrWhiteSpace(wind.AuthorBook.Text))
                {
                    MessageBox.Show("Вы не указали Автора книги!", "ErrorAddBook", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (String.IsNullOrWhiteSpace(wind.GenreBook.Text))
                {
                    MessageBox.Show("Вы не указали жанр книги!", "ErrorAddBook", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (String.IsNullOrWhiteSpace(wind.DescriptionBook.Text))
                {
                    MessageBox.Show("Вы не указали описание книги!", "ErrorAddBook", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!wind.cost)
                {
                    MessageBox.Show("Вы неправильно указали цену книги!", "ErrorAddBook", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!wind.pathDownl)
                {
                    MessageBox.Show("Вы не указали путь скачивания книги!", "ErrorAddBook", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!wind.image)
                {
                    MessageBox.Show("Вы не указали фото книги!", "ErrorAddBook", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Books newBook = new Books()
                {
                    AUTHOR = wind.AuthorBook.Text,
                    COST = float.Parse(wind.CostBook.Text),
                    DATE_PUBLICATION = DateTime.Now,
                    DESCRIPTION = wind.DescriptionBook.Text,
                    IMAGE_BOOK = wind.imageBook,
                    NAME = wind.NameBook.Text,
                    GENRE = wind.GenreBook.Text,
                    POPULARITY = 0,
                    PATH_DOWNLOAD = wind.PathDownload.Text,
                    TYPE_PRICE = wind.CostBook.Text == "0" ? "free" : "paying"
                };
                DataWorkerAdminApp.AddBook(newBook);
                wind.DialogResult = true;
                wind.Close();
            }
        }
        private void ChangeBookMethod(Books bookEd)
        {
            EditBookWindow edit = new EditBookWindow(bookEd);
            if(edit.ShowDialog() == true)
            {
                bookNow.Clear();
                bookNow.Add(edit.bookEdit);
                DataWorkerAdminApp.RefreshBook(bookNow.First().ID_BOOK, edit.bookEdit);
                MessageBox.Show("Книга успешно изменена!", "EditBook", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void RemoveReviewMethod(Reviews review)
        {
            if(review != null)
            {
                DelereReviewWindow wid = new DelereReviewWindow();
                if (wid.ShowDialog() == true)
                {
                    DataWorkerAdminApp.DeleteReview(review);
                    MessageBox.Show("Отзыв удален!", "DeleteReview", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
