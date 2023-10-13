using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Shapes;

namespace EXAMPLE.View
{
    /// <summary>
    /// Логика взаимодействия для FormForBuyBook.xaml
    /// </summary>
    public partial class FormForBuyBook : Window
    {
        public FormForBuyBook()
        {
            InitializeComponent();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.NameOwner.Text) || string.IsNullOrEmpty(this.NumberCard.Text) || string.IsNullOrEmpty(this.Date.Text))
                {
                    MessageBox.Show("Не все поля указаны!", "PayError", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                string putt = "^(?:4[0-9]{12}(?:[0-9]{3})?|5[1-5][0-9]{14}|2(?:2(?:2[1-9]|[3-9][0-9])|[3-6]\\d{2}|7(?:[01]\\d|20))[0-9]{12}|(?:5[0678]\\d\\d|6304|6390|67\\d\\d)\\d{8,15})$";
                if (!Regex.IsMatch(this.NumberCard.Text, putt))
                {
                    MessageBox.Show("Неправильно указан номер карты! Принимаются карты Visa, MasterCard, Maestro, Mir", "ErrorPay", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                string putt2 = "^(0[1-9]|1[0-2])\\/[0-9]{2}$";
                if (!Regex.IsMatch(this.Date.Text, putt2))
                {
                    MessageBox.Show("Неправильно указана дата срока действия карты! Формат ММ/ГГ.", "ErrorPay", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                string putt3 = "^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$";
                if (!Regex.IsMatch(this.NameOwner.Text, putt3))
                {
                    MessageBox.Show("Неправильно указано имя владельца", "ErrorPay", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                this.DialogResult = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ErrorClick", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void NotOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.DialogResult = false;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ErrorClick", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
