using EXAMPLE.Model.Data;
using EXAMPLE.ViewModel.AdminAppViewModel;
using EXAMPLE.ViewModel.UserAppViewModel;
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
    /// Логика взаимодействия для SendRequestPage.xaml
    /// </summary>
    public partial class SendRequestPage : Page
    {
        DataManageVMHelpAdmin context = new DataManageVMHelpAdmin();
        public SendRequestPage()
        {
            InitializeComponent();
            this.DataContext = context;
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                context.ClickReview.Execute(this.ListReviews.SelectedItem);
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
                context.FilterReview.Execute(this.FilterCatalog.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ErrorFilter", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
