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
    /// Логика взаимодействия для InputPhoneNumber.xaml
    /// </summary>
    public partial class InputPhoneNumber : Window
    {
        public InputPhoneNumber()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string pattern = @"^\+375(25|29|33|44)\d{3}\d{2}\d{2}$";
                if (Regex.IsMatch(this.PhoneNumberChange.Text, pattern))
                {
                    this.DialogResult = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Приложение поддерживает только белорусские номера телефонов!", "ErrorPhoneChange", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ErrorClick", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
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
