using EXAMPLE.Model.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
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

namespace EXAMPLE.View
{
    /// <summary>
    /// Логика взаимодействия для LogUpPage.xaml
    /// </summary>
    public partial class LogUpPage : Page
    {
        public bool LoginCheck = false;
        public bool EmailCheck = false;
        public bool PasswordCheck = false;
        public bool PasswordConfCheck = false;
        public bool NameCheck = false;
        public LogUpPage()
        {
            InitializeComponent();
        }
        public LogUpPage(Object context)
        {
            InitializeComponent();
            this.DataContext = context;
        }
        private void SettingMenu_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.menuLanguage.Visibility == Visibility.Hidden)
                {
                    HideMenu();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error SettingMenuLeave", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }

        // скрытие меню
        private void HideMenu()
        {
            this.menuLanguage.Visibility = Visibility.Hidden;
            this.SettingMenu.Visibility = Visibility.Hidden;
        }
        // потеря фокуса с языков
        private void menuLanguage_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                this.menuLanguage.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error LanguageMenuLeave", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
        // кнопка выбора английского языка
        private void ChoiseEnglish_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.LanguageNow.Margin = new Thickness(14, 49, 0, 0);
                this.SettingMenu.Visibility = Visibility.Hidden;
                this.menuLanguage.Visibility = Visibility.Hidden;
                Application.Current.Resources.MergedDictionaries[1].Source = new Uri("Languages\\EnglishVersion.xaml", UriKind.RelativeOrAbsolute);
                SettingOfApp.LanguageOfApplication = LanguageOfApplicationEnum.English;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error ChoiseEnglish", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
        // кнопка выбора русского языка
        private void ChoiseRussian_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.LanguageNow.Margin = new Thickness(14, 24, 0, 0);
                this.SettingMenu.Visibility = Visibility.Hidden;
                this.menuLanguage.Visibility = Visibility.Hidden;
                Application.Current.Resources.MergedDictionaries[3].Source = new Uri("Languages\\RussianVersion.xaml", UriKind.RelativeOrAbsolute);
                SettingOfApp.LanguageOfApplication = LanguageOfApplicationEnum.Russian;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error choise Russian", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
        // кнопка смены языка
        private void ChangeLanguage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.menuLanguage.Visibility = this.menuLanguage.Visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error ChangeLanguage", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
        // кнопка смены темы
        private void ChangeTheme_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.menuLanguage.Visibility = Visibility.Hidden;
                this.SettingMenu.Visibility = Visibility.Hidden;
                if (SettingOfApp.ThemeOfApplication == ThemeOfApplicationEnum.Dark)
                {
                    SettingOfApp.ThemeOfApplication = ThemeOfApplicationEnum.Light;
                    Application.Current.Resources.MergedDictionaries[0].Source = new Uri("Styles\\LightThemeLog.xaml", UriKind.RelativeOrAbsolute);
                }
                else
                {
                    SettingOfApp.ThemeOfApplication = ThemeOfApplicationEnum.Dark;
                    Application.Current.Resources.MergedDictionaries[0].Source = new Uri("Styles\\DarkThemeLog.xaml", UriKind.RelativeOrAbsolute);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error ChangeTheme", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
        // нажать на кнопку показа настроек
        private void ButtonSetting_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.SettingMenu.Visibility = this.SettingMenu.Visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;
                this.menuLanguage.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error ButtonSetting", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
        // навелся на меню настроек
        private void SettingMenu_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {
                this.menuLanguage.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error SettingMenu", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
      
        // проверка email
        private void EmailText_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (this.EmailText.Text.Length > 0)
                {
                    this.PlugOfEmail.Visibility = Visibility.Hidden;
                }
                else
                {
                    this.PlugOfEmail.Visibility = Visibility.Visible;
                }
                if (String.IsNullOrWhiteSpace(this.EmailText.Text))
                {
                    this.ErrorEmail.Text = (string)this.FindResource("Error1");
                    this.ErrorEmail.Visibility = Visibility.Visible;
                    EmailCheck = false;
                    return;
                }
                if (!Regex.IsMatch(this.EmailText.Text, "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$"))
                {
                    this.ErrorEmail.Text = (string)this.FindResource("ErrorEmail2");
                    this.ErrorEmail.Visibility = Visibility.Visible;
                    EmailCheck = false;
                    return;
                }
                try
                {
                    string domain = this.EmailText.Text.Split('@')[1];
                    IPHostEntry entry = Dns.GetHostEntry(domain);
                }
                catch(SocketException)
                {
                    this.ErrorEmail.Text = (string)this.FindResource("ErrorEmail2");
                    this.ErrorEmail.Visibility = Visibility.Visible;
                    EmailCheck = false;
                    return;
                }
                using (ApplicationContext db = new ApplicationContext())
                {
                    if(db.USERS.Any(el => el.EMAIL == this.EmailText.Text))
                    {
                        this.ErrorEmail.Text = (string)this.FindResource("ErrorEmail1");
                        this.ErrorEmail.Visibility = Visibility.Visible;
                        EmailCheck = false;
                        return;
                    }
                }

                this.ErrorEmail.Visibility = Visibility.Hidden;
                EmailCheck = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error EmailText", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
        // проверка имени
        private void PNText_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (this.PNText.Text.Length > 0)
                {
                    this.PlugOfPN.Visibility = Visibility.Hidden;
                }
                else
                {
                    this.PlugOfPN.Visibility = Visibility.Visible;
                }
                if (String.IsNullOrWhiteSpace(this.PNText.Text))
                {
                    this.ErrorPN.Text = (string)this.FindResource("Error1");
                    this.ErrorPN.Visibility = Visibility.Visible;
                    NameCheck = false;
                    return;
                }

                if (!Regex.IsMatch(this.PNText.Text, "^[a-zа-яA-ZА-Я]+$"))
                {
                    this.ErrorPN.Text = (string)this.FindResource("ErrorPN1");
                    this.ErrorPN.Visibility = Visibility.Visible;
                    LoginCheck = false;
                    return;
                }
                this.ErrorPN.Visibility = Visibility.Hidden;
                NameCheck = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error PersonalNameText", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
        // проверка пароля
        private void PasswordTextStars_PasswordChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.PasswordTextStars.Password.Length > 0)
                {
                    this.PlugOfPassword.Visibility = Visibility.Hidden;
                }
                else
                {
                    this.PlugOfPassword.Visibility = Visibility.Visible;
                }
                if (this.PasswordTextStars.Password.Length < 8)
                {
                    this.ErrorPassword.Text = (string)this.FindResource("ErrorPassword2");
                    this.ErrorPassword.Visibility = Visibility.Visible;
                    PasswordCheck = false;
                    return;
                }
                if (!Regex.IsMatch(this.PasswordTextStars.Password, "^(?=.*\\d)(?=.*[a-zа-я])(?=.*[A-ZА-Я])[a-zA-Zа-яА-Я\\d]{6,}$"))
                {
                    this.ErrorPassword.Text = (string)this.FindResource("ErrorPassword1");
                    this.ErrorPassword.Visibility = Visibility.Visible;
                    PasswordCheck = false;
                    return;
                }
                this.ErrorPassword.Visibility = Visibility.Hidden;
                PasswordCheck = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error PasswordText", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
        // проверка подтверждения пароля
        private void PasswordTextStarsConf_PasswordChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.PasswordTextStarsConf.Password.Length > 0)
                {
                    this.PlugOfPasswordConfirm.Visibility = Visibility.Hidden;
                }
                else
                {
                    this.PlugOfPasswordConfirm.Visibility = Visibility.Visible;
                }
                if (String.IsNullOrWhiteSpace(this.PasswordTextStarsConf.Password))
                {
                    this.ErrorPasswordConfirm.Text = (string)this.FindResource("Error1");
                    this.ErrorPasswordConfirm.Visibility = Visibility.Visible;
                    PasswordConfCheck = false;
                    return;
                }
                if (!String.Equals(this.PasswordTextStars.Password, this.PasswordTextStarsConf.Password))
                {
                    this.ErrorPasswordConfirm.Text = (string)this.FindResource("ErrorPasswordConfirm1");
                    this.ErrorPasswordConfirm.Visibility = Visibility.Visible;
                    PasswordConfCheck = false;
                    return;
                }
                this.ErrorPasswordConfirm.Visibility = Visibility.Hidden;
                PasswordConfCheck = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error PasswordTextConfirm", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
        // проверка логина
        private void LoginText_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(this.LoginText.Text))
                {
                    this.ErrorLogin.Text = (string)this.FindResource("Error1");
                    this.ErrorLogin.Visibility = Visibility.Visible;
                    LoginCheck = false;
                    return;
                }

                if (!Regex.IsMatch(this.LoginText.Text, "^[a-zа-яA-ZА-Я0-9]+$"))
                {
                    this.ErrorLogin.Text = (string)this.FindResource("ErrorLogin2");
                    this.ErrorLogin.Visibility = Visibility.Visible;
                    LoginCheck = false;
                    return;
                }
                if (this.LoginText.Text.Length < 5)
                {
                    this.ErrorLogin.Text = (string)this.FindResource("ErrorLogin3");
                    this.ErrorLogin.Visibility = Visibility.Visible;
                    LoginCheck = false;
                    return;
                }
                using (ApplicationContext db = new ApplicationContext())
                {
                    if (db.USERS.Any(el => el.LOGIN == this.LoginText.Text))
                    {
                        this.ErrorLogin.Text = (string)this.FindResource("ErrorLogin1");
                        this.ErrorLogin.Visibility = Visibility.Visible;
                        LoginCheck = false;
                        return;
                    }
                }
                this.ErrorLogin.Visibility = Visibility.Hidden;
                LoginCheck = true;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error LoginText", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
    }
}
