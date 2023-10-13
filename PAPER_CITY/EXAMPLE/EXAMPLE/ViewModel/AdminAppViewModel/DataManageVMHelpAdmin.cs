using EXAMPLE.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using EXAMPLE.View.AdminAppView;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Windows.Media;

namespace EXAMPLE.ViewModel.AdminAppViewModel
{
    public class DataManageVMHelpAdmin : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private ObservableCollection<ReviewProblem> reviewPr = DataWorkerAdminApp.GetReviewsProblem();
        public ObservableCollection<ReviewProblem> ReviewPr
        {
            get
            {
                return reviewPr;
            }
        }
        private RelayCommand refreshReview;
        private RelayCommand filterReview;
        private RelayCommand clickReview;
        public RelayCommand RefreshReview
        {
            get
            {
                return refreshReview ?? new RelayCommand(obj =>
                {
                    try
                    {
                        RefreshReviewMethod();
                        NotifyPropertyChange("ReviewPr");
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ErrorRefresh", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
            }
        }
        public RelayCommand FilterReview
        {
            get
            {
                return filterReview ?? new RelayCommand(obj =>
                {
                    try
                    {
                        FilterReviewMethod(obj as string);
                        NotifyPropertyChange("ReviewPr");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ErrorFilter", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
            }
        }
        public RelayCommand ClickReview
        {
            get
            {
                return clickReview ?? new RelayCommand(obj =>
                {
                    try
                    {
                        ClickReviewMethod(obj as ReviewProblem);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ErrorClickReview", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
            }
        }
        public void RefreshReviewMethod()
        {
            reviewPr = DataWorkerAdminApp.GetReviewsProblem();
        }
        public void FilterReviewMethod(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                RefreshReviewMethod();
            }
            else
            {
                reviewPr = new ObservableCollection<ReviewProblem>(DataWorkerAdminApp.GetReviewsProblem().Where(el => el.LOGIN.ToLower().Contains(text) ||
                                                                              Convert.ToString(el.ID_REVIEW).Contains(text) ||
                                                                              el.REVIEW_TEXT.ToLower().Contains(text)));
            }
        }
        public async void ClickReviewMethod(ReviewProblem review)
        {
            if (review != null)
            {
                SendMessageToUser wind = new SendMessageToUser();
                User userNow = DataWorkerAdminApp.GetUserByLogin(review.LOGIN);
                if (wind.ShowDialog() == true)
                {
                    await PutMessage(wind.Subject.Text, wind.Message.Text, userNow.EMAIL);
                    DataWorkerAdminApp.SendReview(review);
                    RefreshReviewMethod();
                    NotifyPropertyChange("reviewPr");
                }
            }

        }
        private async Task PutMessage(string subject, string text, string email)
        {
            await Task.Run(() =>
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
                mailMessage.Subject = $"{subject}";
                var htmlBody = $"<html><body><p style='font-size: 18pt;'>{text}.</p></body></html>";
                AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);
                // Создаем объект LinkedResource с изображением

                // Добавляем тело письма в сообщение
                mailMessage.AlternateViews.Add(alternateView);

                // Отправляем сообщение
                try
                {
                    smtpClient.Send(mailMessage);
                    MessageBox.Show("Сообщение успешно отправлено!", "SendMessage", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "SendMessage", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
        }
    }
}
