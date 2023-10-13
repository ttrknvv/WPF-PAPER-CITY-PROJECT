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
using EXAMPLE.View.UserAppView;
using EXAMPLE.ViewModel;
using EXAMPLE.ViewModel.UserAppViewModel;

namespace EXAMPLE.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainButtonEnum ActiveButton = MainButtonEnum.MainPageButton;
        // цвет фона активной кнопки
        SolidColorBrush activeColor = new SolidColorBrush(Color.FromRgb(25, 35, 45));
        // прозрачный цвет фона
        SolidColorBrush transparent = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new DataManageVM();
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

        private void MainPageButt_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {
                if (ActiveButton != MainButtonEnum.MainPageButton)
                {
                    this.MainPage.Opacity = 1.0d;
                    this.MainPageButt.Background = activeColor;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ErrorEnter", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MainPageButt_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                if (ActiveButton != MainButtonEnum.MainPageButton)
                {
                    this.MainPage.Opacity = 0.3d;
                    this.MainPageButt.Background = transparent;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ErrorLeave", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CatalogPageButt_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {
                if (ActiveButton != MainButtonEnum.CatalogPageButton)
                {
                    this.CatalogPage.Opacity = 1.0d;
                    this.CatalogPageButt.Background = activeColor;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ErrorEnter", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CatalogPageButt_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                if (ActiveButton != MainButtonEnum.CatalogPageButton)
                {
                    this.CatalogPage.Opacity = 0.3d;
                    this.CatalogPageButt.Background = transparent;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ErrorLeave", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BasketPageButt_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {
                if (ActiveButton != MainButtonEnum.BasketPageButton)
                {
                    this.BasketPage.Opacity = 1.0d;
                    this.BasketPageButt.Background = activeColor;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ErrorEnter", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BasketPageButt_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                if (ActiveButton != MainButtonEnum.BasketPageButton)
                {
                    this.BasketPage.Opacity = 0.3d;
                    this.BasketPageButt.Background = transparent;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ErrorLeave", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ProfilePageButt_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {
                if (ActiveButton != MainButtonEnum.ProfilePageButton)
                {
                    this.ProfilePage.Opacity = 1.0d;
                    this.ProfilePageButt.Background = activeColor;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ErrorEnter", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ProfilePageButt_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                if (ActiveButton != MainButtonEnum.ProfilePageButton)
                {
                    this.ProfilePage.Opacity = 0.3d;
                    this.ProfilePageButt.Background = transparent;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ErrorLeave", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void HelpPageButt_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {
                if (ActiveButton != MainButtonEnum.HelpPageButton)
                {
                    this.HelpPage.Opacity = 1.0d;
                    this.HelpPageButt.Background = activeColor;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ErrorEnter", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void HelpPageButt_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                if (ActiveButton != MainButtonEnum.HelpPageButton)
                {
                    this.HelpPage.Opacity = 0.3d;
                    this.HelpPageButt.Background = transparent;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ErrorLeave", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WindowInputUser wid = new WindowInputUser();
                wid.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ErrorClick", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
