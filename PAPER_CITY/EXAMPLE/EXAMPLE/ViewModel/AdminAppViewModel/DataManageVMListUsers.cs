using EXAMPLE.Model;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using User = EXAMPLE.Model.User;
using EXAMPLE.View.AdminAppView;
using System.Windows;

namespace EXAMPLE.ViewModel.AdminAppViewModel
{
    public class DataManageVMListUsers : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private ObservableCollection<User> users = DataWorkerAdminApp.GetAllUsers();
        private ObservableCollection<User> userNow = new ObservableCollection<User>();
        public ObservableCollection<User> AllUsers
        {
            get
            {
                return users;
            }
        }
        public ObservableCollection<User> UserNow
        {
            get
            {
                return userNow;
            }
        }
        private RelayCommand refreshUsers;
        private RelayCommand clickUser;
        private RelayCommand filterUsers;
        private RelayCommand sendMessage;
        public RelayCommand RefreshUsers
        {
            get
            {
                return refreshUsers ?? new RelayCommand(obj =>
                {
                    RefreshUsersMethod();
                    NotifyPropertyChange("AllUsers");
                });
            }
        }
        public RelayCommand ClickUser
        {
            get
            {
                return clickUser ?? new RelayCommand(obj =>
                {
                    try
                    {
                        if ((obj as User) != null)
                        {
                            ClickUserMethod((obj as User));
                            NotifyPropertyChange("UserNow");
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ErrorClick", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
            }
        }
        public RelayCommand FilterUsers
        {
            get
            {
                return filterUsers ?? new RelayCommand(obj =>
                {
                    try
                    {
                        FilterUserMethod((obj as string));
                        NotifyPropertyChange("AllUsers");
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ErrorFilter", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
            }
        }
        public RelayCommand SendMessage
        {
            get
            {
                return sendMessage ?? new RelayCommand(obj =>
                {
                    try
                    {
                        PutMessageMethod();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ErrorSend", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
            }
        }
        private void RefreshUsersMethod()
        {
            users = DataWorkerAdminApp.GetAllUsers();
        }
        private void ClickUserMethod(User userNowL)
        {
            if(userNow.Count > 0)
            {
                userNow.Clear();
            }
            userNow.Add(userNowL);
        }
        private void FilterUserMethod(string filt)
        {
            if(string.IsNullOrWhiteSpace(filt))
            {
                users = DataWorkerAdminApp.GetAllUsers();
            }
            else
            {
                users = new ObservableCollection<User>(DataWorkerAdminApp.GetAllUsers().Where(el => el.LOGIN.ToLower().Contains(filt.ToLower()) ||
                                                                 el.EMAIL.ToLower().Contains(filt.ToLower()) ||
                                                                 el.NAME.ToLower().Contains(filt.ToLower()) ||
                                                                 el.PHONE_NUMBER.ToLower().Contains(filt.ToLower()) ||
                                                                 Convert.ToString(el.ID_USER).Contains(filt)));
            }
        }
        private async void PutMessageMethod()
        {
            SendMessageToUser wind = new SendMessageToUser();
            if (wind.ShowDialog() == true)
            {
                await SendMessageMethod(wind.Subject.Text, wind.Message.Text);
            }
            }
        private async Task SendMessageMethod(string subject, string text)
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
                    mailMessage.To.Add(userNow.First().EMAIL);
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
