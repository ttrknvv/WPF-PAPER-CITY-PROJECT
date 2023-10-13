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

namespace EXAMPLE.View.UserAppView
{
    /// <summary>
    /// Логика взаимодействия для VerifyEmailWindow.xaml
    /// </summary>
    public partial class VerifyEmailWindow : Window
    {
        int codeVer;
        public VerifyEmailWindow()
        {
            InitializeComponent();
        }
        public VerifyEmailWindow(int code)
        {
            InitializeComponent();
            codeVer = code;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(Convert.ToString(codeVer) == this.CodeText.Text)
            {
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Вы ввели неправильный проверочный код!", "ErrorVerifyEmail", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
