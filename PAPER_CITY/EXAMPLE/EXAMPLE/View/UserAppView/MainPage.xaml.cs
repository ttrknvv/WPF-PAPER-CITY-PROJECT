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
using System.Windows.Navigation;
using System.Windows.Shapes;
using EXAMPLE.Model;
using EXAMPLE.ViewModel.UserAppViewModel;

namespace EXAMPLE.View
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            this.DataContext = DataManageVM.contextData;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.MainGrid.Visibility == Visibility.Visible) return;
                this.MainGrid.Visibility = Visibility.Visible;
                this.GridForBook.Visibility = Visibility.Collapsed;
                var scroll = BasketPage.GetDescendantByType(this.BookNowSelected, typeof(ScrollViewer)) as ScrollViewer;
                scroll.ScrollToVerticalOffset(0);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ErrorClick", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ListOfPopularBooks_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (ListOfPopularBooks.SelectedItem != null)
                {

                    this.MainGrid.Visibility = Visibility.Collapsed;
                    this.GridForBook.Visibility = Visibility.Visible;
                    DataManageVM.contextData.ClickBook.Execute(ListOfPopularBooks.SelectedItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ErrorClick", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ListOfNewBooks_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (ListOfNewBooks.SelectedItem != null)
                {

                    this.MainGrid.Visibility = Visibility.Collapsed;
                    this.GridForBook.Visibility = Visibility.Visible;
                    DataManageVM.contextData.ClickBook.Execute(ListOfNewBooks.SelectedItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ErrorClick", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ListOfFreeBooks_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (ListOfFreeBooks.SelectedItem != null)
                {

                    this.MainGrid.Visibility = Visibility.Collapsed;
                    this.GridForBook.Visibility = Visibility.Visible;
                    DataManageVM.contextData.ClickBook.Execute(ListOfFreeBooks.SelectedItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ErrorClick", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ListOfPaidBooks_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (ListOfPaidBooks.SelectedItem != null)
                {

                    this.MainGrid.Visibility = Visibility.Collapsed;
                    this.GridForBook.Visibility = Visibility.Visible;
                    DataManageVM.contextData.ClickBook.Execute(ListOfPaidBooks.SelectedItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ErrorClick", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            try
            {
                var scrollViewer = sender as ScrollViewer;
                scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - (e.Delta / 3));
                e.Handled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ErrorScroll", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ReviewsList_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            try
            {
                var scroll = BasketPage.GetDescendantByType(this.BookNowSelected, typeof(ScrollViewer)) as ScrollViewer;
                scroll.ScrollToVerticalOffset(scroll.VerticalOffset - (e.Delta / 3));
                e.Handled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ErrorScroll", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
