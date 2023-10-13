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
    /// Логика взаимодействия для UserListPage.xaml
    /// </summary>
    public partial class UserListPage : Page
    {
        DataManageVMListUsers context = new DataManageVMListUsers();
        public UserListPage()
        {
            InitializeComponent();
            this.DataContext = context;
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (this.ListUsers.SelectedItem != null)
                {
                    context.ClickUser.Execute(this.ListUsers.SelectedItem);
                    this.GridForUser.Visibility = Visibility.Visible;
                    this.GridListUsers.Visibility = Visibility.Collapsed;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ErrorClick", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.GridForUser.Visibility = Visibility.Collapsed;
                this.GridListUsers.Visibility = Visibility.Visible;
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
                context.FilterUsers.Execute(this.FilterCatalog.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ErrorFilter", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
