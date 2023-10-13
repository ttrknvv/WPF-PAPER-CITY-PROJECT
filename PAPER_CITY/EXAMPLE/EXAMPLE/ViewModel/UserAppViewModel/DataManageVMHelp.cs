using EXAMPLE.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EXAMPLE.ViewModel.UserAppViewModel
{
    public class DataManageVMHelp : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private RelayCommand sendReview;
        public RelayCommand SendReview
        {
            get
            {
                return sendReview ?? new RelayCommand(obj =>
                {
                    try
                    {
                        SendReviewMethod((obj as TextBox).Text);
                        (obj as TextBox).Text = string.Empty;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ErrorSend", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
            }
        }
        public void SendReviewMethod(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                MessageBox.Show("Вы ничего не написали в отзыве!", "ErrorReview", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            ReviewProblem review = new ReviewProblem()
            {
                DATE = DateTime.Now,
                LOGIN = SettingOfApp.LocalUser.LOGIN,
                REVIEW_TEXT = text,
                STATE = "waiting"
            };
            DataWorkerUserApp.AddReviewOrProblem(review);
            MessageBox.Show("Успешно отправлено!", "SendReview", MessageBoxButton.OK, MessageBoxImage.Information);
        }

    }
}
