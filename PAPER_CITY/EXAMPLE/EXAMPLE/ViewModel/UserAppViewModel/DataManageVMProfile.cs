using EXAMPLE.Model;
using EXAMPLE.View;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace EXAMPLE.ViewModel.UserAppViewModel
{
    public class DataManageVMProfile : INotifyPropertyChanged
    {
        private User localUserNow = SettingOfApp.LocalUser;
        public User LocalUserNow
        {
            get
            {
                return localUserNow;
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
        private RelayCommand changeProfileImage;
        private RelayCommand changeProfilePhoneNumber;
        public RelayCommand ChangeProfileImage
        {
            get
            {
                return changeProfileImage ?? new RelayCommand(obj =>
                {
                    try
                    {
                        string path = ChangePhoto();
                        if (!string.IsNullOrEmpty(path) && !string.IsNullOrEmpty(path))
                        {
                            DataWorkerUserApp.ChangePhotoProfile(path);
                            LocalUserNow.IMAGE_PROFILE = path;
                            NotifyPropertyChange("LocalUserNow");
                            MessageBox.Show("Фото изменено!", "PhotoChange", MessageBoxButton.OK);
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ErrorChange", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
            }
        }
        public RelayCommand ChangeProfilePhoneNumber
        {
            get
            {
                return changeProfileImage ?? new RelayCommand(obj =>
                {
                    try
                    {
                        string phone = ChangePhoneNumber();
                        if (!string.IsNullOrEmpty(phone))
                        {
                            DataWorkerUserApp.ChangePhoneProfile(phone);
                            LocalUserNow.PHONE_NUMBER = phone;
                            NotifyPropertyChange("LocalUserNow");
                            MessageBox.Show("Телефон изменен!", "NumberPhoneChange", MessageBoxButton.OK);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ErrorChange", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
            }
        }
        public string ChangePhoto()
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp|All files (*.*)|*.*";
            string pathFile = "";
            if (file.ShowDialog() == true)
            {
                pathFile = file.FileName;
            }
            return pathFile;
        }
        public string ChangePhoneNumber()
        {
            InputPhoneNumber input = new InputPhoneNumber();
            string phone = "";
            if (input.ShowDialog() == true)
            {
                phone = input.PhoneNumberChange.Text;
            }
            return phone;
        }
    }

}