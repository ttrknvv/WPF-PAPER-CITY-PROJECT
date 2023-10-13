using EXAMPLE.Model;
using EXAMPLE.View.AdminAppView;
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

namespace EXAMPLE.ViewModel.AdminAppViewModel
{
    public class DataManageVMAcceptPaying : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private ObservableCollection<Payment> payments = DataWorkerAdminApp.GetPayments();
        public ObservableCollection<Payment> Payments
        {
            get
            {
                return payments;
            }
        }
        private RelayCommand verifyPay;
        private RelayCommand refreshPayment;
        public RelayCommand VerifyPay
        {
            get
            {
                return verifyPay ?? new RelayCommand(obj =>
                {
                    try
                    {
                        if ((obj as Payment) != null)
                        {
                            VerifyPaymentMethod(obj as Payment);
                            payments = DataWorkerAdminApp.GetPayments();
                            NotifyPropertyChange("Payments");
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ErrorVerifyPay", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
            }
        }
        public RelayCommand RefreshPayment
        {
            get
            {
                return refreshPayment ?? new RelayCommand(obj =>
                {
                    try
                    {
                        payments = DataWorkerAdminApp.GetPayments();
                        NotifyPropertyChange("Payments");
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ErrorRefresh", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
            }
        }
        public async void VerifyPaymentMethod(Payment paying)
        {
            VerifyPaymentWindow wind = new VerifyPaymentWindow();
            if(wind.ShowDialog() == true)
            {
                if(wind.ok)
                {
                    DataWorkerAdminApp.SetPayments(paying.ID_PAY, true);
                    MessageBox.Show("Покупка книги подтверждена!", "VerifyBookPay", MessageBoxButton.OK, MessageBoxImage.Information);
                    await PutMessageOfGoodPaying(paying);
                }
                if (wind.notOk)
                {
                    DataWorkerAdminApp.SetPayments(paying.ID_PAY, false);
                    MessageBox.Show("Покупка книги отказана!", "VerifyBookPay", MessageBoxButton.OK, MessageBoxImage.Information);
                    await PutMessageOfBadPaying(paying);
                }
                payments = DataWorkerAdminApp.GetPayments();
            }
        }
        public async Task PutMessageOfGoodPaying(Payment paying)
        {
            await Task.Run(() =>
            {
                Books bookNow = DataWorkerAdminApp.GetBookById(paying.ID_BOOK);
                User user = DataWorkerAdminApp.GetUserById(paying.ID_USER);
                // Настройки SMTP-сервера Gmail
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("paperrcityy@gmail.com", "rkyymlkydinddnsz");

                // Создаем сообщение
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("paperrcityy@gmail.com");
                mailMessage.To.Add(user.EMAIL);
                mailMessage.Subject = $"Покупка книги \"{bookNow.NAME}\"";
                var htmlBody = $"<html><body><p style='font-size: 18pt;'>Покупка книги {bookNow.NAME}.</p>" +
                    $"<br><img src=\"cid:bookImage\" style='width: 300px; height: 500px;'>" +
                    $"<p style='font-size: 18pt;'>Здравствуйте, {user.NAME}! Благодарим вас за покупку нашей книги! Покупка вашей книги подтверждена! Можете уверенно скачивать ее в нашем приложении!</p></body></html>";
                AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);
                // Создаем объект LinkedResource с изображением
                LinkedResource bookImage = new LinkedResource(bookNow.IMAGE_BOOK, MediaTypeNames.Image.Jpeg);
                bookImage.ContentId = "bookImage";
                alternateView.LinkedResources.Add(bookImage);

                // Добавляем тело письма в сообщение
                mailMessage.AlternateViews.Add(alternateView);
                //mailMessage.Body = "This is a test email.";

                // Отправляем сообщение
                try
                {
                    smtpClient.Send(mailMessage);
                }
                catch (Exception ex)
                {
                }
            });
        }
        public async Task PutMessageOfBadPaying(Payment paying)
        {
            await Task.Run(() =>
            {
                Books bookNow = DataWorkerAdminApp.GetBookById(paying.ID_BOOK);
                User user = DataWorkerAdminApp.GetUserById(paying.ID_USER);
                // Настройки SMTP-сервера Gmail
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("paperrcityy@gmail.com", "rkyymlkydinddnsz");

                // Создаем сообщение
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("paperrcityy@gmail.com");
                mailMessage.To.Add(user.EMAIL);
                mailMessage.Subject = $"Покупка книги \"{bookNow.NAME}\"";
                var htmlBody = $"<html><body><p style='font-size: 18pt;'>Покупка книги {bookNow.NAME}.</p>" +
                    $"<br><img src=\"cid:bookImage\" style='width: 300px; height: 500px;'>" +
                    $"<p style='font-size: 18pt;'>Здравствуйте, {user.NAME}! Благодарим вас за покупку нашей книги! Покупка вашей книги отклонена! Можете попробовать еще раз произвести оплату этой книги!</p></body></html>";
                AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);
                // Создаем объект LinkedResource с изображением
                LinkedResource bookImage = new LinkedResource(bookNow.IMAGE_BOOK, MediaTypeNames.Image.Jpeg);
                bookImage.ContentId = "bookImage";
                alternateView.LinkedResources.Add(bookImage);

                // Добавляем тело письма в сообщение
                mailMessage.AlternateViews.Add(alternateView);
                //mailMessage.Body = "This is a test email.";

                // Отправляем сообщение
                try
                {
                    smtpClient.Send(mailMessage);
                }
                catch (Exception ex)
                {
                }
            });
        }
    }
}
