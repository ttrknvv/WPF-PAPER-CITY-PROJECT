using EXAMPLE.View.UserAppView;
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
using System.Windows.Shapes;

namespace EXAMPLE.View.AdminAppView
{
    /// <summary>
    /// Логика взаимодействия для AdminMainWindow.xaml
    /// </summary>
    public partial class AdminMainWindow : Window
    {
        public static MainAdminButtonEnum ActiveButton = MainAdminButtonEnum.MainPageButton;
        // цвет фона активной кнопки
        SolidColorBrush activeColor = new SolidColorBrush(Color.FromRgb(25, 35, 45));
        // прозрачный цвет фона
        SolidColorBrush transparent = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
        public AdminMainWindow()
        {
            InitializeComponent();
            this.DataContext = new DataManageVMMain();
        }

        private void CollapseApp_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.WindowState = WindowState.Minimized;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error CollapseAppClick", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }

        private void CloseApp_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error CloseAppDown", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }

        private void MainPageButt_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {
                if (ActiveButton != MainAdminButtonEnum.MainPageButton)
                {
                    MainPage.Opacity = 1d;
                    (sender as Button).Background = activeColor;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MainPageButt_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                if (ActiveButton != MainAdminButtonEnum.MainPageButton)
                {
                    MainPage.Opacity = 0.5d;
                    (sender as Button).Background = transparent;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ToolBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.ChangedButton == MouseButton.Left)
                {
                    this.DragMove();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error DragMoveApp", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }

        private void AddBookAndEditPageButt_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {
                if (ActiveButton != MainAdminButtonEnum.AddEditBookPageButton)
                {
                    AddBookEdit.Opacity = 1d;
                    (sender as Button).Background = activeColor;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddBookAndEditPageButt_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                if (ActiveButton != MainAdminButtonEnum.AddEditBookPageButton)
                {
                    AddBookEdit.Opacity = 0.5d;
                    (sender as Button).Background = transparent;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BasketPageButt_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {
                if (ActiveButton != MainAdminButtonEnum.ListUserPageButton)
                {
                    ListUsers.Opacity = 1d;
                    (sender as Button).Background = activeColor;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BasketPageButt_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                if (ActiveButton != MainAdminButtonEnum.ListUserPageButton)
                {
                    ListUsers.Opacity = 0.5d;
                    (sender as Button).Background = transparent;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ProfilePageButt_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {
                if (ActiveButton != MainAdminButtonEnum.AcceptBookPageButton)
                {
                    AcceptBooks.Opacity = 1d;
                    (sender as Button).Background = activeColor;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ProfilePageButt_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                if (ActiveButton != MainAdminButtonEnum.AcceptBookPageButton)
                {
                    AcceptBooks.Opacity = 0.5d;
                    (sender as Button).Background = transparent;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void HelpPageButt_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {
                if (ActiveButton != MainAdminButtonEnum.SendRequestPageButton)
                {
                    HelpPage.Opacity = 1d;
                    (sender as Button).Background = activeColor;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void HelpPageButt_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                if (ActiveButton != MainAdminButtonEnum.SendRequestPageButton)
                {
                    HelpPage.Opacity = 0.5d;
                    (sender as Button).Background = transparent;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WindowInputUser wind = new WindowInputUser();
                wind.Show();
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ErrorLeave", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
