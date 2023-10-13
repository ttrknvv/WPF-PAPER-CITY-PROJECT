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
    /// Логика взаимодействия для BasketPage.xaml
    /// </summary>
    public partial class BasketPage : Page
    {
        public DataManageVMBasket context = new DataManageVMBasket();
        public BasketPage()
        {
            InitializeComponent();
            this.DataContext = context;
        }

        private void Basket_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (Basket.SelectedItem != null)
                {

                    this.MainGrid.Visibility = Visibility.Collapsed;
                    this.GridForBook.Visibility = Visibility.Visible;
                    context.ClickBook.Execute(Basket.SelectedItem);
                    Basket.Items.Refresh();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ErrorClick", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.MainGrid.Visibility == Visibility.Visible) return;
                this.MainGrid.Visibility = Visibility.Visible;
                this.GridForBook.Visibility = Visibility.Collapsed;
                var scroll = GetDescendantByType(this.BookNowSelected, typeof(ScrollViewer)) as ScrollViewer;
                scroll.ScrollToVerticalOffset(0);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ErrorClick", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void FilterText_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                context.FilterBusket.Execute(this.BusketPage);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ErrorFilter", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        public static Visual GetDescendantByType(Visual element, Type type)
        {
            if (element == null) return null;
            if (element.GetType() == type) return element;
            Visual foundElement = null;
            if (element is FrameworkElement frameworkElement)
            {
                frameworkElement.ApplyTemplate();
            }
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(element); i++)
            {
                Visual visual = VisualTreeHelper.GetChild(element, i) as Visual;
                foundElement = GetDescendantByType(visual, type);
                if (foundElement != null)
                    break;
            }
            return foundElement;
        }

        private void ReviewsList_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            try
            {
                var scroll = GetDescendantByType(this.BookNowSelected, typeof(ScrollViewer)) as ScrollViewer;
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
