using EXAMPLE.ViewModel.AdminAppViewModel;
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

namespace EXAMPLE.View.AdminAppView
{
    /// <summary>
    /// Логика взаимодействия для EditBooksPage.xaml
    /// </summary>
    public partial class EditBooksPage : Page
    {
        DataManageVMEditBook context = new DataManageVMEditBook();
        public EditBooksPage()
        {
            InitializeComponent();
            this.DataContext = context;
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (this.CatalogBooks.SelectedItem != null)
                {
                    this.GridForBook.Visibility = Visibility.Visible;
                    this.ListBooks.Visibility = Visibility.Collapsed;
                    context.ClickBook.Execute(this.CatalogBooks.SelectedItem);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ErrorClick", MessageBoxButton.OK, MessageBoxImage.Error);
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

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.GridForBook.Visibility = Visibility.Collapsed;
                this.ListBooks.Visibility = Visibility.Visible;
                var scroll = BasketPage.GetDescendantByType(this.BookNowSelected, typeof(ScrollViewer)) as ScrollViewer;
                scroll.ScrollToVerticalOffset(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ErrorClick", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void FilterCatalog_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                context.FilterCatalog.Execute(this.PageEdit);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ErrorFilter", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Sort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ComboBoxItem selectedItem = Sort.SelectedItem as ComboBoxItem;

                if (selectedItem != null)
                {
                    string selected_value = selectedItem.Content.ToString();
                    ResourceDictionary res = Application.Current.Resources;
                    if (selected_value == res["NoSort"] as string)
                    {
                        context.NoSort.Execute(null);
                        return;
                    }
                    if (selected_value == res["DescPriceSort"] as string)
                    {
                        context.DescPriceSort.Execute(null);
                        return;
                    }
                    if (selected_value == res["IncPriceSort"] as string)
                    {
                        context.IncPriceSort.Execute(null);
                        return;
                    }
                    if (selected_value == res["PopularitySort"] as string)
                    {
                        context.PopularitySort.Execute(null);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ErrorSort", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ListViewItem_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            try
            {
                context.DeleteReview.Execute(this.ReviewsList.SelectedItem);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ErrorClick", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
