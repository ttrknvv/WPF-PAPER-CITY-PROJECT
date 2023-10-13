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
using EXAMPLE.ViewModel;
using EXAMPLE.ViewModel.UserAppViewModel;

namespace EXAMPLE.View.UserAppView
{
    /// <summary>
    /// Логика взаимодействия для WindowInputUser.xaml
    /// </summary>
    public partial class WindowInputUser : Window
    {
        public WindowInputUser()
        {
            InitializeComponent();
            this.DataContext = new DataManageVM();
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
        // Свернуть приложение(нажать на минус)
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
        // Переместить форму приложения
        private void DragMoveApp(object sender, MouseButtonEventArgs e)
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
        // клик по регистрации
        private void LogUpButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.LogInButtonFrame.Opacity = 0.4f;
                this.LogUpButtonFrame.Opacity = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error LogUpButtonClick", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
        // клик по авторизации
        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.LogInButtonFrame.Opacity = 1;
                this.LogUpButtonFrame.Opacity = 0.4f;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error LogInButtonClick", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
    }
}
