using EXAMPLE.Model;
using EXAMPLE.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows;
using EXAMPLE.View.AdminAppView;
using System.Windows.Controls;

public enum MainAdminButtonEnum
{
    MainPageButton,
    AddEditBookPageButton,
    ListUserPageButton,
    AcceptBookPageButton,
    SendRequestPageButton
}
namespace EXAMPLE.ViewModel.AdminAppViewModel
{

    public class DataManageVMMain : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private RelayCommand clickMainPage;
        private RelayCommand clickAddEditPage;
        private RelayCommand clickUsersListPage;
        private RelayCommand clickAcceptPage;
        private RelayCommand clickRequestPage;
        private MainPageAdmin AdminPage = new MainPageAdmin();
        public MainPageAdmin PageAdmin
        {
            get
            {
                return AdminPage;
            }
        }
        private AcceptBuyPage AcceptPage = new AcceptBuyPage();
        private EditBooksPage EditPage = new EditBooksPage();
        private SendRequestPage RequestPage = new SendRequestPage();
        private UserListPage ListUserPage = new UserListPage();
        public RelayCommand ClickMainPage
        {
            get 
            {
                return clickMainPage ?? new RelayCommand(obj =>
            {
                try
                {
                    OpenMainPageMethod(obj as AdminMainWindow);
                    AdminMainWindow.ActiveButton = MainAdminButtonEnum.MainPageButton;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "ErrorClick", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
                    }
        }
        public RelayCommand ClickAddEditPage
        {
            get
            {
                return clickAddEditPage ?? new RelayCommand(obj =>
                {
                    try
                    {
                        OpenAddEditMethod(obj as AdminMainWindow);
                        AdminMainWindow.ActiveButton = MainAdminButtonEnum.AddEditBookPageButton;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ErrorClick", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
            }
        }
        public RelayCommand ClickUsersListPage
        {
            get
            {
                return clickUsersListPage ?? new RelayCommand(obj =>
                {
                    try
                    {
                        OpenUsersListMethod(obj as AdminMainWindow);
                        AdminMainWindow.ActiveButton = MainAdminButtonEnum.ListUserPageButton;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ErrorClick", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
            }
        }
        public RelayCommand ClickAcceptPage
        {
            get
            {
                return clickAcceptPage ?? new RelayCommand(obj =>
                {
                    try
                    {
                        OpenAcceptPageMethod(obj as AdminMainWindow);
                        AdminMainWindow.ActiveButton = MainAdminButtonEnum.AcceptBookPageButton;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ErrorClick", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
            }
        }
        public RelayCommand ClickRequestPage
        {
            get
            {
                return clickRequestPage ?? new RelayCommand(obj =>
                {
                    try
                    {
                        OpenRequestPageMethod(obj as AdminMainWindow);
                        AdminMainWindow.ActiveButton = MainAdminButtonEnum.SendRequestPageButton;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ErrorClick", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
            }
        }
        private void SelectActiveButton(MainAdminButtonEnum activeButton, AdminMainWindow window)
        {
            // цвет фона активной кнопки
            SolidColorBrush activeColor = new SolidColorBrush(Color.FromRgb(25, 35, 45));
            // прозрачный цвет фона
            SolidColorBrush transparent = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            switch (activeButton)
            {
                case MainAdminButtonEnum.MainPageButton:
                    FindVisualChild<Image>(window.MainPageButt).Source = new BitmapImage(new Uri("D:\\2k2s\\COURSE_PROJECT\\SOURCE\\PHOTOES\\homeActive.png", UriKind.RelativeOrAbsolute));
                    window.MainPageButt.Background = activeColor;
                    FindVisualChild<Image>(window.MainPageButt).Opacity = 1.0d;

                    FindVisualChild<Image>(window.AddBookAndEditPageButt).Source = new BitmapImage(new Uri("D:\\2k2s\\COURSE_PROJECT\\SOURCE\\PHOTOES\\addBookUnactive.png", UriKind.RelativeOrAbsolute));
                    window.AddBookAndEditPageButt.Background = transparent;
                    FindVisualChild<Image>(window.AddBookAndEditPageButt).Opacity = 0.5d;

                    FindVisualChild<Image>(window.ListUsersButt).Source = new BitmapImage(new Uri("D:\\2k2s\\COURSE_PROJECT\\SOURCE\\PHOTOES\\userListUnactive.png", UriKind.RelativeOrAbsolute));
                    window.ListUsersButt.Background = transparent;
                    FindVisualChild<Image>(window.ListUsersButt).Opacity = 0.5d;

                    FindVisualChild<Image>(window.AcceptBooksButt).Source = new BitmapImage(new Uri("D:\\2k2s\\COURSE_PROJECT\\SOURCE\\PHOTOES\\acceptBookUnactive.png", UriKind.RelativeOrAbsolute));
                    window.AcceptBooksButt.Background = transparent;
                    FindVisualChild<Image>(window.AcceptBooksButt).Opacity = 0.5d;

                    FindVisualChild<Image>(window.HelpPageButt).Source = new BitmapImage(new Uri("D:\\2k2s\\COURSE_PROJECT\\SOURCE\\PHOTOES\\question.png", UriKind.RelativeOrAbsolute));
                    window.HelpPageButt.Background = transparent;
                    FindVisualChild<Image>(window.HelpPageButt).Opacity = 0.5d;
                    break;
                case MainAdminButtonEnum.AddEditBookPageButton:
                    FindVisualChild<Image>(window.MainPageButt).Source = new BitmapImage(new Uri("D:\\2k2s\\COURSE_PROJECT\\SOURCE\\PHOTOES\\home.png", UriKind.RelativeOrAbsolute));
                    window.MainPageButt.Background = transparent;
                    FindVisualChild<Image>(window.MainPageButt).Opacity = 0.5d;

                    FindVisualChild<Image>(window.AcceptBooksButt).Source = new BitmapImage(new Uri("D:\\2k2s\\COURSE_PROJECT\\SOURCE\\PHOTOES\\acceptBookUnactive.png", UriKind.RelativeOrAbsolute));
                    window.AcceptBooksButt.Background = transparent;
                    FindVisualChild<Image>(window.AcceptBooksButt).Opacity = 0.5d;

                    FindVisualChild<Image>(window.ListUsersButt).Source = new BitmapImage(new Uri("D:\\2k2s\\COURSE_PROJECT\\SOURCE\\PHOTOES\\userListUnactive.png", UriKind.RelativeOrAbsolute));
                    window.ListUsersButt.Background = transparent;
                    FindVisualChild<Image>(window.ListUsersButt).Opacity = 0.5d;

                    FindVisualChild<Image>(window.HelpPageButt).Source = new BitmapImage(new Uri("D:\\2k2s\\COURSE_PROJECT\\SOURCE\\PHOTOES\\question.png", UriKind.RelativeOrAbsolute));
                    window.HelpPageButt.Background = transparent;
                    FindVisualChild<Image>(window.HelpPageButt).Opacity = 0.5d;

                    FindVisualChild<Image>(window.AddBookAndEditPageButt).Source = new BitmapImage(new Uri("D:\\2k2s\\COURSE_PROJECT\\SOURCE\\PHOTOES\\addBookActive.png", UriKind.RelativeOrAbsolute));
                    window.AddBookAndEditPageButt.Background = activeColor;
                    FindVisualChild<Image>(window.AddBookAndEditPageButt).Opacity = 1.0d;
                    break;

                case MainAdminButtonEnum.ListUserPageButton:
                    FindVisualChild<Image>(window.MainPageButt).Source = new BitmapImage(new Uri("D:\\2k2s\\COURSE_PROJECT\\SOURCE\\PHOTOES\\home.png", UriKind.RelativeOrAbsolute));
                    window.MainPageButt.Background = transparent;
                    FindVisualChild<Image>(window.MainPageButt).Opacity = 0.5d;
                    FindVisualChild<Image>(window.AddBookAndEditPageButt).Source = new BitmapImage(new Uri("D:\\2k2s\\COURSE_PROJECT\\SOURCE\\PHOTOES\\addBookUnactive.png", UriKind.RelativeOrAbsolute));
                    window.AddBookAndEditPageButt.Background = transparent;
                    FindVisualChild<Image>(window.AddBookAndEditPageButt).Opacity = 0.5d;
                    FindVisualChild<Image>(window.AcceptBooksButt).Source = new BitmapImage(new Uri("D:\\2k2s\\COURSE_PROJECT\\SOURCE\\PHOTOES\\acceptBookUnactive.png", UriKind.RelativeOrAbsolute));
                    window.AcceptBooksButt.Background = transparent;
                    FindVisualChild<Image>(window.AcceptBooksButt).Opacity = 0.5d;
                    FindVisualChild<Image>(window.HelpPageButt).Source = new BitmapImage(new Uri("D:\\2k2s\\COURSE_PROJECT\\SOURCE\\PHOTOES\\question.png", UriKind.RelativeOrAbsolute));
                    window.HelpPageButt.Background = transparent;
                    FindVisualChild<Image>(window.HelpPageButt).Opacity = 0.5d;
                    FindVisualChild<Image>(window.ListUsersButt).Source = new BitmapImage(new Uri("D:\\2k2s\\COURSE_PROJECT\\SOURCE\\PHOTOES\\userListActive.png", UriKind.RelativeOrAbsolute));
                    window.ListUsersButt.Background = activeColor;
                    FindVisualChild<Image>(window.ListUsersButt).Opacity = 1.0d;
                    break;
                case MainAdminButtonEnum.AcceptBookPageButton:
                    FindVisualChild<Image>(window.MainPageButt).Source = new BitmapImage(new Uri("D:\\2k2s\\COURSE_PROJECT\\SOURCE\\PHOTOES\\home.png", UriKind.RelativeOrAbsolute));
                    window.MainPageButt.Background = transparent;
                    FindVisualChild<Image>(window.MainPageButt).Opacity = 0.5d;
                    FindVisualChild<Image>(window.AddBookAndEditPageButt).Source = new BitmapImage(new Uri("D:\\2k2s\\COURSE_PROJECT\\SOURCE\\PHOTOES\\addBookUnactive.png", UriKind.RelativeOrAbsolute));
                    window.AddBookAndEditPageButt.Background = transparent;
                    FindVisualChild<Image>(window.AddBookAndEditPageButt).Opacity = 0.5d;
                    FindVisualChild<Image>(window.ListUsersButt).Source = new BitmapImage(new Uri("D:\\2k2s\\COURSE_PROJECT\\SOURCE\\PHOTOES\\userListUnactive.png", UriKind.RelativeOrAbsolute));
                    window.ListUsersButt.Background = transparent;
                    FindVisualChild<Image>(window.ListUsersButt).Opacity = 0.5d;
                    FindVisualChild<Image>(window.HelpPageButt).Source = new BitmapImage(new Uri("D:\\2k2s\\COURSE_PROJECT\\SOURCE\\PHOTOES\\question.png", UriKind.RelativeOrAbsolute));
                    window.HelpPageButt.Background = transparent;
                    FindVisualChild<Image>(window.HelpPageButt).Opacity = 0.5d;
                    FindVisualChild<Image>(window.AcceptBooksButt).Source = new BitmapImage(new Uri("D:\\2k2s\\COURSE_PROJECT\\SOURCE\\PHOTOES\\acceptBookActive.png", UriKind.RelativeOrAbsolute));
                    window.AcceptBooksButt.Background = activeColor;
                    FindVisualChild<Image>(window.AcceptBooksButt).Opacity = 1.0d;
                    break;
                case MainAdminButtonEnum.SendRequestPageButton:
                    FindVisualChild<Image>(window.AddBookAndEditPageButt).Source = new BitmapImage(new Uri("D:\\2k2s\\COURSE_PROJECT\\SOURCE\\PHOTOES\\addBookUnactive.png", UriKind.RelativeOrAbsolute));
                    window.AddBookAndEditPageButt.Background = transparent;
                    FindVisualChild<Image>(window.AddBookAndEditPageButt).Opacity = 0.5d;
                    FindVisualChild<Image>(window.ListUsersButt).Source = new BitmapImage(new Uri("D:\\2k2s\\COURSE_PROJECT\\SOURCE\\PHOTOES\\userListUnactive.png", UriKind.RelativeOrAbsolute));
                    window.ListUsersButt.Background = transparent;
                    FindVisualChild<Image>(window.ListUsersButt).Opacity = 0.5d;
                    FindVisualChild<Image>(window.AcceptBooksButt).Source = new BitmapImage(new Uri("D:\\2k2s\\COURSE_PROJECT\\SOURCE\\PHOTOES\\acceptBookUnactive.png", UriKind.RelativeOrAbsolute));
                    window.AcceptBooksButt.Background = transparent;
                    FindVisualChild<Image>(window.AcceptBooksButt).Opacity = 0.5d;
                    FindVisualChild<Image>(window.HelpPageButt).Source = new BitmapImage(new Uri("D:\\2k2s\\COURSE_PROJECT\\SOURCE\\PHOTOES\\questionActive.png", UriKind.RelativeOrAbsolute));
                    window.HelpPageButt.Background = activeColor;
                    FindVisualChild<Image>(window.HelpPageButt).Opacity = 1.0d;
                    FindVisualChild<Image>(window.MainPageButt).Source = new BitmapImage(new Uri("D:\\2k2s\\COURSE_PROJECT\\SOURCE\\PHOTOES\\home.png", UriKind.RelativeOrAbsolute));
                    window.MainPageButt.Background = transparent;
                    FindVisualChild<Image>(window.MainPageButt).Opacity = 0.5d;
                    break;
            }
        }
        private T FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child != null && child is T)
                    return (T)child;
                else
                {
                    var result = FindVisualChild<T>(child);
                    if (result != null)
                        return result;
                }
            }
            return null;
        }
        private void OpenMainPageMethod(AdminMainWindow wind)
        {
            if(wind != null)
            {
                wind.PageNow.Content = AdminPage;
                SelectActiveButton(MainAdminButtonEnum.MainPageButton, wind);
            }
        }
        private void OpenAddEditMethod(AdminMainWindow wind)
        {
            if (wind != null)
            {
                wind.PageNow.Content = EditPage;
                SelectActiveButton(MainAdminButtonEnum.AddEditBookPageButton, wind);
            }
        }
        private void OpenUsersListMethod(AdminMainWindow wind)
        {
            if (wind != null)
            {
                wind.PageNow.Content = ListUserPage;
                SelectActiveButton(MainAdminButtonEnum.ListUserPageButton, wind);
            }
        }
        private void OpenAcceptPageMethod(AdminMainWindow wind)
        {
            if (wind != null)
            {
                wind.PageNow.Content = AcceptPage;
                SelectActiveButton(MainAdminButtonEnum.AcceptBookPageButton, wind);
            }
        }
        private void OpenRequestPageMethod(AdminMainWindow wind)
        {
            if (wind != null)
            {
                wind.PageNow.Content = RequestPage;
                SelectActiveButton(MainAdminButtonEnum.SendRequestPageButton, wind);
            }
        }
    }
}
