using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EXAMPLE.Model;
using EXAMPLE.ViewModel.UserAppViewModel;

namespace EXAMPLE.View
{
    /// <summary>
    /// Логика взаимодействия для CatalogPage.xaml
    /// </summary>
    public partial class CatalogPage : Page
    {
        DataManageXMCatalog viewModel = new DataManageXMCatalog();
        public CatalogPage()
        {
            InitializeComponent();
            this.BookNowSelected.Items.Clear();
            this.list.Items.Clear();
            this.DataContext = viewModel;
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ErrorClick", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void list_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (list.SelectedItem != null)
                {
                    this.MainGrid.Visibility = Visibility.Collapsed;
                    this.GridForBook.Visibility = Visibility.Visible;
                    viewModel.ClickBook.Execute(list.SelectedItem);
                    list.Items.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ErrorClick", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void FilterText_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                viewModel.FilterCatalog.Execute(this.catalogPage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ErrorFilter", MessageBoxButton.OK, MessageBoxImage.Error);
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

        private void NoSort_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                viewModel.NoSort.Execute(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ErrorClick", MessageBoxButton.OK, MessageBoxImage.Error);
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
                    if(selected_value == res["NoSort"] as string)
                    {
                        viewModel.NoSort.Execute(null);
                        return;
                    }
                    if (selected_value == res["DescPriceSort"] as string)
                    {
                        viewModel.DescPriceSort.Execute(null);
                        return;
                    }
                    if (selected_value == res["IncPriceSort"] as string)
                    {
                        viewModel.IncPriceSort.Execute(null);
                        return;
                    }
                    if (selected_value == res["PopularitySort"] as string)
                    {
                        viewModel.PopularitySort.Execute(null);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ErrorSort", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
