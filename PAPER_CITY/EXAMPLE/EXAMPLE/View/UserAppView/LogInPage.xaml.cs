using EXAMPLE.Model;
using EXAMPLE.Model.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
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

namespace EXAMPLE.View
{
    /// <summary>
    /// Логика взаимодействия для LogInPage.xaml
    /// </summary>
    public partial class LogInPage : Page
    {
        public LogInPage()
        {
            InitializeComponent();
        }
        public LogInPage(Object context)
        {
            InitializeComponent();
            this.DataContext = context;
        }
        // нажать на кнопку показа настроек
        private void ButtonSetting_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.menuCountry.Visibility = Visibility.Hidden;
                this.SettingMenu.Visibility = this.SettingMenu.Visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;
                this.menuLanguage.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error ButtonSettingClick", MessageBoxButton.OKCancel, MessageBoxImage.Error);
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
                MessageBox.Show(ex.Message, "Error ChangeThemeClick", MessageBoxButton.OKCancel, MessageBoxImage.Error);
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
                MessageBox.Show(ex.Message, "Error ChangeLanguageClick", MessageBoxButton.OKCancel, MessageBoxImage.Error);
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
                Application.Current.Resources.MergedDictionaries[1].Source = new Uri("Languages\\RussianVersion.xaml", UriKind.RelativeOrAbsolute);
                SettingOfApp.LanguageOfApplication = LanguageOfApplicationEnum.Russian;
                switch (SettingOfApp.CountryOfApp)
                {
                    case CountryOfAppEnum.America:
                        this.CountyTextNow.Text = (string)FindResource("CountryAmerica");
                        break;
                    case CountryOfAppEnum.Ukraine:
                        this.CountyTextNow.Text = (string)FindResource("CountryUkraine");
                        break;
                    case CountryOfAppEnum.Belarus:
                        this.CountyTextNow.Text = (string)FindResource("CountryBelarus");
                        break;
                    case CountryOfAppEnum.Russia:
                        this.CountyTextNow.Text = (string)FindResource("CountryRussia");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error ChoiseRussianClick", MessageBoxButton.OKCancel, MessageBoxImage.Error);
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
                switch (SettingOfApp.CountryOfApp)
                {
                    case CountryOfAppEnum.America:
                        this.CountyTextNow.Text = (string)FindResource("CountryAmerica");
                        break;
                    case CountryOfAppEnum.Ukraine:
                        this.CountyTextNow.Text = (string)FindResource("CountryUkraine");
                        break;
                    case CountryOfAppEnum.Belarus:
                        this.CountyTextNow.Text = (string)FindResource("CountryBelarus");
                        break;
                    case CountryOfAppEnum.Russia:
                        this.CountyTextNow.Text = (string)FindResource("CountryRussia");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error ChoiseEnglishClick", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }

        }
        // клик по форме
        private void MainWindowProject_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.SettingMenu.Visibility = Visibility.Hidden;
                this.menuLanguage.Visibility = Visibility.Hidden;
                this.menuCountry.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error MainWindowDown", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
        // переход к списку стран
        private void ButtonCountry_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.menuCountry.Visibility = this.menuCountry.Visibility == Visibility.Hidden ? Visibility.Visible : Visibility.Hidden;
                this.SettingMenu.Visibility = Visibility.Hidden;
                this.menuLanguage.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error ButtonCountryClick", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
        // кнопка выбора Беларуси
        private void ChoiseBelarus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.menuCountry.Visibility = Visibility.Hidden;
                this.CountryNowMetka.Margin = new Thickness(18, 10, 0, 0);
                this.CountyTextNow.Text = this.CountryBelarus.Text;
                SettingOfApp.CountryOfApp = CountryOfAppEnum.Belarus;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error ChoiseBelarusClick", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
        // кнопка выбора России
        private void ChoiseRussia_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.menuCountry.Visibility = Visibility.Hidden;
                this.CountryNowMetka.Margin = new Thickness(18, 36, 0, 0);
                this.CountyTextNow.Text = this.CountryRussia.Text;
                SettingOfApp.CountryOfApp = CountryOfAppEnum.Russia;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error ChoiseRussiaClick", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
        // кнопка выбора Украины
        private void ChoiseUkraine_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.menuCountry.Visibility = Visibility.Hidden;
                this.CountryNowMetka.Margin = new Thickness(18, 60, 0, 0);
                this.CountyTextNow.Text = this.CountryUkraine.Text;
                SettingOfApp.CountryOfApp = CountryOfAppEnum.Ukraine;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ErrorBlock ChoiseUkraineClick", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
        // кнопка выбора Америки
        private void ChoiseAmerica_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.menuCountry.Visibility = Visibility.Hidden;
                this.CountryNowMetka.Margin = new Thickness(18, 86, 0, 0);
                this.CountyTextNow.Text = this.CountryAmerika.Text;
                SettingOfApp.CountryOfApp = CountryOfAppEnum.America;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error ChoiseAmericaClick", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
        // кнопка мне нужна помощь
        private void NeedHelp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.menuCountry.Visibility = Visibility.Hidden;
                string url = "https://ttrknvv.github.io/";
                Process.Start(new ProcessStartInfo(url)
                {
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error NeedHelpClick", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }

        private void ShowPassword_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HideMenu();
                if (this.ShowPassword.IsChecked == true)
                {
                    this.PasswordText.Text = this.PasswordTextStars.Password;
                    this.PasswordText.Visibility = Visibility.Visible;
                    this.PasswordTextStars.Visibility = Visibility.Hidden;
                }
                else
                {
                    this.PasswordTextStars.Password = this.PasswordText.Text;
                    this.PasswordText.Visibility = Visibility.Hidden;
                    this.PasswordTextStars.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error ShowPasswordClick", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
        // изменение текста в пароле
        private void PasswordText_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (this.PasswordText.Text.Length > 0)
                {
                    this.PlugPassword.Visibility = Visibility.Collapsed;
                }
                else
                {
                    this.PlugPassword.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error PasswordTextChaned", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
        // изменение пароля
        private void PasswordTextStars_PasswordChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                this.PasswordText.Text = this.PasswordTextStars.Password;
                if (this.PasswordTextStars.Password.Length > 0)
                {
                    this.PlugPassword.Visibility = Visibility.Collapsed;
                }
                else
                {
                    this.PlugPassword.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error PasswordStarsChanged", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
        // скрытие меню
        private void HideMenu()
        {
            this.menuCountry.Visibility = Visibility.Hidden;
            this.menuLanguage.Visibility = Visibility.Hidden;
            this.SettingMenu.Visibility = Visibility.Hidden;
        }
        // потерял фокус с меню стран
        private void MenuCountry_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                HideMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error CountryMenuLeave", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
        // потерял фокус с меню настроек
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
                MessageBox.Show(ex.Message, "Error LanguageMenuLeave", MessageBoxButton.OKCancel, MessageBoxImage.Error);
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
                MessageBox.Show(ex.Message, "Error SettingMenuEnter", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
        // навелся на форму
        private void MainWindowProject_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {
                HideMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error MainWinEnter", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
        // потеря фокуса с языков
        private void MenuLanguage_MouseLeave(object sender, MouseEventArgs e)
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
        // фокус на кнопку авторизоваться
        private void Auther_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {
                HideMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error RegEnter", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
        // фокус на показать пароль
        private void ShowPassword_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {
                HideMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error ShowPasswordEnter", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
        // клик по у вас проблемы со входом
        private void Problems_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                string url = "https://ttrknvv.github.io/";
                Process.Start(new ProcessStartInfo(url)
                {
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error ProblemsDown", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
        // потеря фокуса у меню
        private void Page_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                HideMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error PageLeave", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }

        private void Page_MouseDown(object sender, MouseButtonEventArgs e)
        {

            try
            {
                HideMenu();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error PageDown", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }

        private void Page_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {
                HideMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error PageEnter", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }

        private void LogupNew_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                string uri = "https://ttrknvv.github.io/";
                Process.Start(new ProcessStartInfo(uri)
                {
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error RegNew", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }

        private void GoogleButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string uri = "https://ttrknvv.github.io/";
                Process.Start(new ProcessStartInfo(uri)
                {
                    UseShellExecute = true
                }) ;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error GoogleButton", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }

    }
}
