using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using EXAMPLE.Model;
using EXAMPLE.Model.Data;
using EXAMPLE.View;
using EXAMPLE.View.UserAppView;
using GalaSoft.MvvmLight.Command;
using RelayCommand = EXAMPLE.Model.RelayCommand;
using PaperCity.MD5Hash;

public enum MainButtonEnum
{
    MainPageButton,
    CatalogPageButton,
    BasketPageButton,
    ProfilePageButton,
    HelpPageButton
}


namespace EXAMPLE.ViewModel.UserAppViewModel
{
    public class DataManageVM : INotifyPropertyChanged
    {
        public static DataManageVM contextData = new DataManageVM();


        private List<Books> allPopularBooks = DataWorkerUserApp.GetCatalog().OrderBy(el => el.POPULARITY).Take(30).ToList();
        private List<Books> allPopularFreeBooks = DataWorkerUserApp.GetCatalog().Where(x => x.TYPE_PRICE == "free").OrderBy(el => el.POPULARITY).Take(30).ToList();
        private List<Books> allPopularPaidBooks = DataWorkerUserApp.GetCatalog().Where(x => x.TYPE_PRICE != "free").OrderBy(el => el.POPULARITY).Take(30).ToList();
        private List<Books> allNewBooks = DataWorkerUserApp.GetCatalog().Where(x => (DateTime.Now - x.DATE_PUBLICATION).TotalDays <= 7).Take(30).ToList();
        private ObservableCollection<Books> bookNow = new ObservableCollection<Books>();
        public ObservableCollection<Reviews> allReviews = new ObservableCollection<Reviews>();
        public ObservableCollection<Reviews> AllReviews
        {
            get
            {
                return allReviews;
            }
        }

        public List<Books> AllPopularBooks
        {
            get
            {
                return allPopularBooks;
            }
        }

        public List<Books> AllNewBooks
        {
            get
            {
                return allNewBooks;
            }
        }
        public List<Books> AllPopularFreeBooks
        {
            get
            {
                return allPopularFreeBooks;
            }
        }
        public List<Books> AllPopularPaidBooks
        {
            get
            {
                return allPopularPaidBooks;
            }
        }
        public ObservableCollection<Books> BookNow
        {
            get
            {
                return bookNow;
            }
            set
            {
                bookNow = value;
            }
        }



        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #region COMMANDS
        private RelayCommand openMainPage;
        private RelayCommand openCatalogPage;
        private RelayCommand openBasketPage;
        private RelayCommand openProfilePage;
        private RelayCommand openHelpPage;
        private RelayCommand openLogInPage;
        private RelayCommand openLogUpPage;
        private RelayCommand registerNewUser;
        private RelayCommand logingUser;
        private RelayCommand clickBook;
        private RelayCommand addBusket;
        public RelayCommand ClickBook
        {
            get
            {
                return clickBook ?? new RelayCommand(obj =>
                {
                    try
                    {
                        ClickOnBook(obj as Books);
                        allReviews = DataWorkerUserApp.GetReviews(bookNow.First().ID_BOOK);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ErrorClick", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
            }
        }

        public RelayCommand OpenMainPage
        {
            get
            {
                return openMainPage ?? new RelayCommand(obj =>
                {
                    try
                    {
                        OpenMainPageMethod(obj as MainWindow);
                        MainWindow.ActiveButton = MainButtonEnum.MainPageButton;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ErrorChoisePage", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
            }
        }
        public RelayCommand OpenCatalogPage
        {
            get
            {
                return openCatalogPage ?? new RelayCommand(obj =>
                {
                    try
                    {
                        OpenCatalogPageMethod(obj as MainWindow);
                        MainWindow.ActiveButton = MainButtonEnum.CatalogPageButton;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ErrorChoisePage", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
            }
        }
        public RelayCommand OpenBasketPage
        {
            get
            {
                return openBasketPage ?? new RelayCommand(obj =>
                {
                    try
                    {
                        OpenBasketPageMethod(obj as MainWindow);
                        MainWindow.ActiveButton = MainButtonEnum.BasketPageButton;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ErrorChoisePage", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
            }
        }
        public RelayCommand OpenProfilePage
        {
            get
            {
                return openProfilePage ?? new RelayCommand(obj =>
                {
                    try
                    {
                        OpenProfilePageMethod(obj as MainWindow);
                        MainWindow.ActiveButton = MainButtonEnum.ProfilePageButton;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ErrorChoisePage", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
            }
        }
        public RelayCommand OpenHelpPage
        {
            get
            {
                return openHelpPage ?? new RelayCommand(obj =>
                {
                    try
                    {
                        OpenHelpPageMethod(obj as MainWindow);
                        MainWindow.ActiveButton = MainButtonEnum.HelpPageButton;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ErrorChoisePage", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
            }
        }
        public RelayCommand OpenLogInPage
        {
            get
            {
                return openLogInPage ?? new RelayCommand(obj =>
                {
                    try
                    {
                        OpenLogInPageMethod(obj as WindowInputUser);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ErrorChoisePage", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
            }
        }
        public RelayCommand OpenLogUpPage
        {
            get
            {
                return openLogUpPage ?? new RelayCommand(obj =>
                {
                    try
                    {
                        OpenLogUpPageMethod(obj as WindowInputUser);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ErrorChoisePage", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
            }
        }
        public RelayCommand RegisterNewUser
        {
            get
            {
                return registerNewUser ?? new RelayCommand(async obj =>
                {
                    try
                    {
                        LogUpPage wind = obj as LogUpPage;
                        if (wind != null && wind.LoginCheck && wind.EmailCheck && wind.PasswordCheck && wind.PasswordConfCheck && wind.NameCheck)
                        {
                            Random rand = new Random();
                            int code = rand.Next(100000, 999999);
                            await PutMessageEmail(Convert.ToString(code), wind.EmailText.Text);
                            VerifyEmailWindow windd = new VerifyEmailWindow(code);
                            if (windd.ShowDialog() == true)
                            {
                                if(string.IsNullOrWhiteSpace(wind.PasswordTextStars.Password))
                                {
                                    MessageBox.Show("Произошла ошибка! При регистрации не выходите со страницы регистрации. Попробуйте еще раз", "ErrorRegister", MessageBoxButton.OK, MessageBoxImage.Error);
                                    return;
                                }
                                DataWorkerUserApp.RegisterNewUser(wind.LoginText.Text, HashPassword.GetHashPassword(wind.PasswordTextStars.Password), wind.PNText.Text, wind.EmailText.Text);
                                MessageBox.Show("Вы успешно зарегистрированы!", "Registration type", MessageBoxButton.OK);
                                wind.LoginText.Text = string.Empty;
                                wind.PasswordTextStars.Password = string.Empty;
                                wind.PasswordTextStarsConf.Password = string.Empty;
                                wind.PNText.Text = string.Empty;
                                wind.EmailText.Text = string.Empty;
                            }
                            else
                            {
                                MessageBox.Show("Вы не подтвердили Email! Вы не зарегистрированы!", "ErrorRegister", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Вы заполнили не все поля!", "ErrorRegister", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ErrorRegisterUser", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
            }
        }
        public RelayCommand LogInUser
        {
            get
            {
                return logingUser ?? new RelayCommand(obj =>
                {
                    try
                    {
                        LogInPage wind = obj as LogInPage;
                        LogInMethod(wind);
                        wind.LoginText.Text = string.Empty;
                        wind.PasswordText.Text = string.Empty;
                        wind.PasswordTextStars.Password = string.Empty;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ErrorLoginUser", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
            }
        }
        public RelayCommand AddBusket
        {
            get
            {
                return addBusket ?? new RelayCommand(obj =>
                {
                    try
                    {
                        var list = obj as ObservableCollection<Books>;
                        AddBookToBusket(bookNow.First().ID_BOOK);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ErrorAdd", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
            }
        }

        #endregion  
        private MainPage pageMain = new MainPage();
        public MainPage PageMain
        {
            get
            {
                return pageMain;
            }
        }
        private CatalogPage pageCatalog = new CatalogPage();
        public CatalogPage PageCatalog
        {
            get
            {
                return pageCatalog;
            }
        }
        private ProfilePage pageProfile = new ProfilePage();
        public ProfilePage PageProfile
        {
            get
            {
                return pageProfile;
            }
        }
        private BasketPage pageBasket = new BasketPage();
        public BasketPage PageBasket
        {
            get
            {
                return pageBasket;
            }
        }
        private HelpPage pageHelp = new HelpPage();
        public HelpPage PageHelp
        {
            get
            {
                return pageHelp;
            }
        }
        private LogInPage pageLogIn = new LogInPage(contextData);
        public LogInPage PageLogIn
        {
            get
            {
                return pageLogIn;
            }
        }
        private LogUpPage pageLogUp = new LogUpPage(contextData);
        public LogUpPage PageLogUp
        {
            get
            {
                return pageLogUp;
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

        // вспомогательная функция для зануления неактивных кнопок
        private void SelectActiveButton(MainButtonEnum activeButton, MainWindow window)
        {
            // цвет фона активной кнопки
            SolidColorBrush activeColor = new SolidColorBrush(Color.FromRgb(25, 35, 45));
            // прозрачный цвет фона
            SolidColorBrush transparent = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            switch (activeButton)
            {
                case MainButtonEnum.HelpPageButton:
                    FindVisualChild<Image>(window.MainPageButt).Source = new BitmapImage(new Uri("D:\\2k2s\\COURSE_PROJECT\\SOURCE\\PHOTOES\\home.png", UriKind.RelativeOrAbsolute));
                    window.MainPageButt.Background = transparent;
                    FindVisualChild<Image>(window.MainPageButt).Opacity = 0.3d;
                    FindVisualChild<Image>(window.CatalogPageButt).Source = new BitmapImage(new Uri("D:\\2k2s\\COURSE_PROJECT\\SOURCE\\PHOTOES\\open-book.png", UriKind.RelativeOrAbsolute));
                    window.CatalogPageButt.Background = transparent;
                    FindVisualChild<Image>(window.CatalogPageButt).Opacity = 0.3d;
                    FindVisualChild<Image>(window.BasketPageButt).Source = new BitmapImage(new Uri("D:\\2k2s\\COURSE_PROJECT\\SOURCE\\PHOTOES\\basket.png", UriKind.RelativeOrAbsolute));
                    window.BasketPageButt.Background = transparent;
                    FindVisualChild<Image>(window.BasketPageButt).Opacity = 0.3d;
                    FindVisualChild<Image>(window.ProfilePageButt).Source = new BitmapImage(new Uri("D:\\2k2s\\COURSE_PROJECT\\SOURCE\\PHOTOES\\profile.png", UriKind.RelativeOrAbsolute));
                    window.ProfilePageButt.Background = transparent;
                    FindVisualChild<Image>(window.ProfilePageButt).Opacity = 0.3d;
                    FindVisualChild<Image>(window.HelpPageButt).Source = new BitmapImage(new Uri("D:\\2k2s\\COURSE_PROJECT\\SOURCE\\PHOTOES\\questionActive.png", UriKind.RelativeOrAbsolute));
                    window.HelpPageButt.Background = activeColor;
                    FindVisualChild<Image>(window.HelpPageButt).Opacity = 1.0d;
                    break;
                case MainButtonEnum.CatalogPageButton:
                    FindVisualChild<Image>(window.MainPageButt).Source = new BitmapImage(new Uri("D:\\2k2s\\COURSE_PROJECT\\SOURCE\\PHOTOES\\home.png", UriKind.RelativeOrAbsolute));
                    window.MainPageButt.Background = transparent;
                    FindVisualChild<Image>(window.MainPageButt).Opacity = 0.3d;
                    FindVisualChild<Image>(window.BasketPageButt).Source = new BitmapImage(new Uri("D:\\2k2s\\COURSE_PROJECT\\SOURCE\\PHOTOES\\basket.png", UriKind.RelativeOrAbsolute));
                    window.BasketPageButt.Background = transparent;
                    FindVisualChild<Image>(window.BasketPageButt).Opacity = 0.3d;
                    FindVisualChild<Image>(window.ProfilePageButt).Source = new BitmapImage(new Uri("D:\\2k2s\\COURSE_PROJECT\\SOURCE\\PHOTOES\\profile.png", UriKind.RelativeOrAbsolute));
                    window.ProfilePageButt.Background = transparent;
                    FindVisualChild<Image>(window.ProfilePageButt).Opacity = 0.3d;
                    FindVisualChild<Image>(window.HelpPageButt).Source = new BitmapImage(new Uri("D:\\2k2s\\COURSE_PROJECT\\SOURCE\\PHOTOES\\question.png", UriKind.RelativeOrAbsolute));
                    window.HelpPageButt.Background = transparent;
                    FindVisualChild<Image>(window.HelpPageButt).Opacity = 0.3d;
                    FindVisualChild<Image>(window.CatalogPageButt).Source = new BitmapImage(new Uri("D:\\2k2s\\COURSE_PROJECT\\SOURCE\\PHOTOES\\open-bookActive.png", UriKind.RelativeOrAbsolute));
                    window.CatalogPageButt.Background = activeColor;
                    FindVisualChild<Image>(window.CatalogPageButt).Opacity = 1.0d;
                    break;
                case MainButtonEnum.BasketPageButton:
                    FindVisualChild<Image>(window.MainPageButt).Source = new BitmapImage(new Uri("D:\\2k2s\\COURSE_PROJECT\\SOURCE\\PHOTOES\\home.png", UriKind.RelativeOrAbsolute));
                    window.MainPageButt.Background = transparent;
                    FindVisualChild<Image>(window.MainPageButt).Opacity = 0.3d;
                    FindVisualChild<Image>(window.CatalogPageButt).Source = new BitmapImage(new Uri("D:\\2k2s\\COURSE_PROJECT\\SOURCE\\PHOTOES\\open-book.png", UriKind.RelativeOrAbsolute));
                    window.CatalogPageButt.Background = transparent;
                    FindVisualChild<Image>(window.CatalogPageButt).Opacity = 0.3d;
                    FindVisualChild<Image>(window.ProfilePageButt).Source = new BitmapImage(new Uri("D:\\2k2s\\COURSE_PROJECT\\SOURCE\\PHOTOES\\profile.png", UriKind.RelativeOrAbsolute));
                    window.ProfilePageButt.Background = transparent;
                    FindVisualChild<Image>(window.ProfilePageButt).Opacity = 0.3d;
                    FindVisualChild<Image>(window.HelpPageButt).Source = new BitmapImage(new Uri("D:\\2k2s\\COURSE_PROJECT\\SOURCE\\PHOTOES\\question.png", UriKind.RelativeOrAbsolute));
                    window.HelpPageButt.Background = transparent;
                    FindVisualChild<Image>(window.HelpPageButt).Opacity = 0.3d;
                    FindVisualChild<Image>(window.BasketPageButt).Source = new BitmapImage(new Uri("D:\\2k2s\\COURSE_PROJECT\\SOURCE\\PHOTOES\\basketActive.png", UriKind.RelativeOrAbsolute));
                    window.BasketPageButt.Background = activeColor;
                    FindVisualChild<Image>(window.BasketPageButt).Opacity = 1.0d;
                    break;
                case MainButtonEnum.ProfilePageButton:
                    FindVisualChild<Image>(window.MainPageButt).Source = new BitmapImage(new Uri("D:\\2k2s\\COURSE_PROJECT\\SOURCE\\PHOTOES\\home.png", UriKind.RelativeOrAbsolute));
                    window.MainPageButt.Background = transparent;
                    FindVisualChild<Image>(window.MainPageButt).Opacity = 0.3d;
                    FindVisualChild<Image>(window.CatalogPageButt).Source = new BitmapImage(new Uri("D:\\2k2s\\COURSE_PROJECT\\SOURCE\\PHOTOES\\open-book.png", UriKind.RelativeOrAbsolute));
                    window.CatalogPageButt.Background = transparent;
                    FindVisualChild<Image>(window.CatalogPageButt).Opacity = 0.3d;
                    FindVisualChild<Image>(window.BasketPageButt).Source = new BitmapImage(new Uri("D:\\2k2s\\COURSE_PROJECT\\SOURCE\\PHOTOES\\basket.png", UriKind.RelativeOrAbsolute));
                    window.BasketPageButt.Background = transparent;
                    FindVisualChild<Image>(window.BasketPageButt).Opacity = 0.3d;
                    FindVisualChild<Image>(window.HelpPageButt).Source = new BitmapImage(new Uri("D:\\2k2s\\COURSE_PROJECT\\SOURCE\\PHOTOES\\question.png", UriKind.RelativeOrAbsolute));
                    window.HelpPageButt.Background = transparent;
                    FindVisualChild<Image>(window.HelpPageButt).Opacity = 0.3d;
                    FindVisualChild<Image>(window.ProfilePageButt).Source = new BitmapImage(new Uri("D:\\2k2s\\COURSE_PROJECT\\SOURCE\\PHOTOES\\profileActive.png", UriKind.RelativeOrAbsolute));
                    window.ProfilePageButt.Background = activeColor;
                    FindVisualChild<Image>(window.ProfilePageButt).Opacity = 1.0d;
                    break;
                case MainButtonEnum.MainPageButton:
                    FindVisualChild<Image>(window.CatalogPageButt).Source = new BitmapImage(new Uri("D:\\2k2s\\COURSE_PROJECT\\SOURCE\\PHOTOES\\open-book.png", UriKind.RelativeOrAbsolute));
                    window.CatalogPageButt.Background = transparent;
                    FindVisualChild<Image>(window.CatalogPageButt).Opacity = 0.3d;
                    FindVisualChild<Image>(window.BasketPageButt).Source = new BitmapImage(new Uri("D:\\2k2s\\COURSE_PROJECT\\SOURCE\\PHOTOES\\basket.png", UriKind.RelativeOrAbsolute));
                    window.BasketPageButt.Background = transparent;
                    FindVisualChild<Image>(window.BasketPageButt).Opacity = 0.3d;
                    FindVisualChild<Image>(window.ProfilePageButt).Source = new BitmapImage(new Uri("D:\\2k2s\\COURSE_PROJECT\\SOURCE\\PHOTOES\\profile.png", UriKind.RelativeOrAbsolute));
                    window.ProfilePageButt.Background = transparent;
                    FindVisualChild<Image>(window.ProfilePageButt).Opacity = 0.3d;
                    FindVisualChild<Image>(window.HelpPageButt).Source = new BitmapImage(new Uri("D:\\2k2s\\COURSE_PROJECT\\SOURCE\\PHOTOES\\question.png", UriKind.RelativeOrAbsolute));
                    window.HelpPageButt.Background = transparent;
                    FindVisualChild<Image>(window.HelpPageButt).Opacity = 0.3d;
                    FindVisualChild<Image>(window.MainPageButt).Source = new BitmapImage(new Uri("D:\\2k2s\\COURSE_PROJECT\\SOURCE\\PHOTOES\\homeActive.png", UriKind.RelativeOrAbsolute));
                    window.MainPageButt.Background = activeColor;
                    FindVisualChild<Image>(window.MainPageButt).Opacity = 1.0d;
                    break;
            }
        }
        public void OpenMainPageMethod(MainWindow window)
        {
            if (window != null)
            {
                window.PageNow.Content = pageMain;
                SelectActiveButton(MainButtonEnum.MainPageButton, window);
            }
        }
        public void OpenCatalogPageMethod(MainWindow window)
        {
            if (window != null)
            {
                window.PageNow.Content = pageCatalog;
                SelectActiveButton(MainButtonEnum.CatalogPageButton, window);
            }
        }
        public void OpenBasketPageMethod(MainWindow window)
        {
            if (window != null)
            {
                PageBasket.context.UpdateBusket.Execute(null);
                window.PageNow.Content = pageBasket;
                SelectActiveButton(MainButtonEnum.BasketPageButton, window);
            }
        }
        public void OpenProfilePageMethod(MainWindow window)
        {
            if (window != null)
            {
                window.PageNow.Content = pageProfile;
                SelectActiveButton(MainButtonEnum.ProfilePageButton, window);
            }
        }
        public void OpenHelpPageMethod(MainWindow window)
        {
            if (window != null)
            {
                window.PageNow.Content = pageHelp;
                SelectActiveButton(MainButtonEnum.HelpPageButton, window);
            }
        }
        public void OpenLogInPageMethod(WindowInputUser window)
        {
            if (window != null)
            {
                window.PageNow.Content = pageLogIn;
            }
        }
        public void OpenLogUpPageMethod(WindowInputUser window)
        {
            if (window != null)
            {
                window.PageNow.Content = pageLogUp;
            }
        }
        public void ClickOnBook(Books book)
        {
            if (book != null)
            {
                if (bookNow.Count != 0)
                {
                    bookNow.Clear();
                }
                bookNow.Add(book);
            }
        }
        public void LogInMethod(LogInPage page)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(page.LoginText.Text) ||
                    string.IsNullOrWhiteSpace(page.PasswordText.Text))
                {
                    page.ErrorBlockBorder.Visibility = Visibility.Visible;
                    var animation = new DoubleAnimation(1, TimeSpan.FromMilliseconds(400));
                    animation.Completed += (send, args) =>
                    {
                        page.ErrorBlockBorder.Visibility = Visibility.Hidden;
                    };
                    page.ErrorBlockBorder.BeginAnimation(UIElement.OpacityProperty, animation);
                    page.LoginText.Text = string.Empty;
                    page.PasswordText.Text = string.Empty;
                    page.PasswordTextStars.Password = string.Empty;
                    return;
                }
                DataWorkerUserApp.LogInUserGet(page.LoginText.Text, HashPassword.GetHashPassword(page.PasswordText.Text));
                Application.Current.Windows.OfType<WindowInputUser>().FirstOrDefault().Close();

                page.LoginText.Text = string.Empty;
                page.PasswordText.Text = string.Empty;
                page.PasswordTextStars.Password = string.Empty;

            }
            catch (Exception ez)
            {
                page.ErrorBlockBorder.Visibility = Visibility.Visible;
                var animation = new DoubleAnimation(1, TimeSpan.FromMilliseconds(400));
                animation.Completed += (send, args) =>
                {
                    page.ErrorBlockBorder.Visibility = Visibility.Hidden;
                };
                page.ErrorBlockBorder.BeginAnimation(UIElement.OpacityProperty, animation);
            }
        }
        public void AddBookToBusket(int id_book)
        {
            DataWorkerUserApp.AddBookOnBusket(id_book);
        }
        public async Task PutMessageEmail(string code, string email)
        {
            await Task.Run(() =>
            {
                try
                {
                    // Настройки SMTP-сервера Gmail
                    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                    smtpClient.EnableSsl = true;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential("paperrcityy@gmail.com", "rkyymlkydinddnsz");

                    // Создаем сообщение
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress("paperrcityy@gmail.com");
                    mailMessage.To.Add(email);
                    mailMessage.Subject = $"Подтверждение электронной почты";
                    var htmlBody = $"<html><body><p style='font-size: 18pt;'>Ваш проверочнй код: {code}.</p>" +
                        $"<p style='font-size: 18pt;'>Введите данный код в приложении</p></body></html>";
                    AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);
                    // Добавляем тело письма в сообщение
                    mailMessage.AlternateViews.Add(alternateView);
                    //mailMessage.Body = "This is a test email.";

                    // Отправляем сообщение
                    smtpClient.Send(mailMessage);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "ErrorEmailMessage", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
            });
        }
    }
}
