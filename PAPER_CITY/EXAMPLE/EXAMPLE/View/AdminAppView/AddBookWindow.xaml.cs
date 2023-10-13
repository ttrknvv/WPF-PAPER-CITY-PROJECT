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
using EXAMPLE.ViewModel.AdminAppViewModel;
using Microsoft.Win32;

namespace EXAMPLE.View.AdminAppView
{
    /// <summary>
    /// Логика взаимодействия для AddBookWindow.xaml
    /// </summary>
    public partial class AddBookWindow : Window
    {
        public bool cost = false;
        public bool pathDownl = false;
        public bool image = false;
        public string imageBook;
        public AddBookWindow()
        {
            InitializeComponent();
            this.DataContext = new DataManageVMEditBook();
        }

        private void NoAddBook_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.DialogResult = false;
                this.Close();
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
                if (float.TryParse((sender as TextBox).Text, out a))
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
                MessageBox.Show(ex.Message, "ErrorParse", MessageBoxButton.OK, MessageBoxImage.Error);
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
                    pathDownl = true;
                }
                else
                {
                    pathDownl = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ErrorClick", MessageBoxButton.OK, MessageBoxImage.Error);
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
                    imageBook = file.FileName;
                    this.BookSelectImage.Source = new BitmapImage(new Uri(file.FileName));
                    image = true;
                }
                else
                {
                    image = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ErroClickr", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
