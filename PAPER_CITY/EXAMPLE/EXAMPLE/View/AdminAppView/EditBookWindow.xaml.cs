using EXAMPLE.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace EXAMPLE.View.AdminAppView
{
    /// <summary>
    /// Логика взаимодействия для EditBookWindow.xaml
    /// </summary>
    public partial class EditBookWindow : Window
    {
        public Books bookEdit;
        bool cost = true;
        bool path = true;
        public EditBookWindow()
        {
            InitializeComponent();
        }
        public EditBookWindow(Books book)
        {
            InitializeComponent();
            this.bookEdit = new Books()
            {
                AUTHOR = book.AUTHOR, 
                COST = book.COST,
                DATE_PUBLICATION = book.DATE_PUBLICATION,
                DESCRIPTION = book.DESCRIPTION,
                ID_BOOK = book.ID_BOOK ,
                PATH_DOWNLOAD = book.PATH_DOWNLOAD,
                GENRE = book.GENRE,
                IMAGE_BOOK = book.IMAGE_BOOK,
                NAME = book.NAME,
                POPULARITY = book.POPULARITY,
                TYPE_PRICE = book.TYPE_PRICE
            };
            this.CostBook.Text = Convert.ToString(bookEdit.COST);
            this.NameBook.Text = bookEdit.NAME;
            this.AuthorBook.Text = bookEdit.AUTHOR;
            this.GenreBook.Text = bookEdit.GENRE;
            this.DescriptionBook.Text = bookEdit.DESCRIPTION;
            this.PathDownload.Text = bookEdit.PATH_DOWNLOAD;
            this.BookSelectImage.Source = new BitmapImage(new Uri(bookEdit.IMAGE_BOOK));
        }

        private void NoAddBook_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.DialogResult = false;
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(this.NameBook.Text))
                {
                    MessageBox.Show("Не указано имя книги!", "ErrorReplaceBook", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(this.AuthorBook.Text))
                {
                    MessageBox.Show("Не указан автор книги!", "ErrorReplaceBook", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(this.GenreBook.Text))
                {
                    MessageBox.Show("Не указан жанр книги!", "ErrorReplaceBook", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (!cost)
                {
                    MessageBox.Show("Неправильно указана цена книги!", "ErrorReplaceBook", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(this.DescriptionBook.Text))
                {
                    MessageBox.Show("Не указано описание книги!", "ErrorReplaceBook", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (!path)
                {
                    MessageBox.Show("Неправильно указан путь книги!", "ErrorReplaceBook", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                bookEdit.NAME = this.NameBook.Text;
                bookEdit.COST = float.Parse(this.CostBook.Text);
                bookEdit.TYPE_PRICE = this.CostBook.Text == "0" ? "free" : "paying";
                bookEdit.AUTHOR = this.AuthorBook.Text;
                bookEdit.DESCRIPTION = this.DescriptionBook.Text;
                bookEdit.GENRE = this.GenreBook.Text;
                bookEdit.PATH_DOWNLOAD = this.PathDownload.Text;
                this.DialogResult = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ErrorClick", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void VerifyPath_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog file = new OpenFileDialog();
                file.Filter = "Текстовые документы (*.pdf, *.txt, *.fb2, *.epub, *.rtf)|*.pdf;*.txt;*.fb2;*.epub;*.rtf";
                string pathFile = "";
                if (file.ShowDialog() == true)
                {
                    this.PathDownload.Text = file.FileName;
                    path = true;
                }
                else
                {
                    path = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ErrorClick", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CostBook_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                float a;
                if (float.TryParse(this.CostBook.Text, out a))
                {
                    cost = true;
                }
                else
                {
                    cost = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ErrorChanged", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void PathDownload_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (this.PathDownload.Text != bookEdit.PATH_DOWNLOAD)
                    path = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ErrorChanged", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BookSelectImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                OpenFileDialog file = new OpenFileDialog();
                file.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp|All files (*.*)|*.*";
                string pathFile = "";
                if (file.ShowDialog() == true)
                {
                    bookEdit.IMAGE_BOOK = file.FileName;
                    this.BookSelectImage.Source = new BitmapImage(new Uri(file.FileName));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ErrorClick", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
