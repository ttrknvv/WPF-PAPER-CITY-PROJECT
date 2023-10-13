using EXAMPLE.Model;
using EXAMPLE.View;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EXAMPLE.ViewModel.UserAppViewModel
{
    public class DataManageVMBasket : INotifyPropertyChanged
    {
        private ObservableCollection<Books> busketBooks = DataWorkerUserApp.GetBusketBooks();
        private ObservableCollection<Books> bookNow = new ObservableCollection<Books>();
        public ObservableCollection<Reviews> allReviews = new ObservableCollection<Reviews>();
        public ObservableCollection<Reviews> AllReviews
        {
            get
            {
                return allReviews;
            }
        }
        public ObservableCollection<Books> BusketBooks
        {
            get
            {
                return busketBooks;
            }
        }
        public ObservableCollection<Books> BookNow
        {
            get
            {
                return bookNow;
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
        private RelayCommand updateBusket;
        private RelayCommand clickBook;
        private RelayCommand filterBusket;
        private RelayCommand downloadBook;
        private RelayCommand deleteBookFromBusket;
        private RelayCommand addReview;
        public RelayCommand ClickBook
        {
            get
            {
                return clickBook ?? new RelayCommand(obj =>
                {
                    try
                    {
                        ClickOnBook(obj as Books);
                        allReviews = DataWorkerUserApp.GetReviews(bookNow.First().ID_BOOK);
                        DataWorkerUserApp.AddPopularity((obj as Books).ID_BOOK, 1);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ErrorClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                });
            }
        }
        public RelayCommand UpdateBusket
        {
            get
            {
                return updateBusket ?? new RelayCommand(obj =>
                {
                    try
                    {
                        UpdateBusketMethod();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ErrorUpdate", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                });
            }
        }
        public RelayCommand FilterBusket
        {
            get
            {
                return filterBusket ?? new RelayCommand(obj =>
                {
                    try
                    {
                        FilterBuksetMethod(obj as BasketPage);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ErrorFilter", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                });
            }
        }
        public RelayCommand DownloadBook
        {
            get
            {
                return downloadBook ?? new RelayCommand(obj =>
                {
                    try
                    {
                        DownloadBookMethodMain();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ErrorDownloadBook", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                });
            }
        }
        public RelayCommand DeleteBookFromBusket
        {
            get
            {
                return deleteBookFromBusket ?? new RelayCommand(obj =>
                {
                    try
                    {
                        DeleteBookMethod();
                        NotifyPropertyChange("BusketBooks");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ErrorDeleteBook", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                });
            }
        }
        public RelayCommand AddReview
        {
            get
            {
                return addReview ?? new RelayCommand(obj =>
                {
                    try
                    {
                        AddReviewMethod(obj as System.Windows.Controls.TextBox);
                        NotifyPropertyChange("AllReviews");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ErrorAddReview", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                });
            }
        }
        private void UpdateBusketMethod()
        {
            busketBooks = DataWorkerUserApp.GetBusketBooks();
            NotifyPropertyChange("BusketBooks");
        }
        private void FilterBuksetMethod(BasketPage page)
        {
            string text = page.FilterText.Text.ToLower();
            if (!string.IsNullOrEmpty(text))
            {
                busketBooks = new ObservableCollection<Books>(busketBooks.Where(el => el.GENRE.ToLower().Contains(text) ||
                                                                                                  el.NAME.ToLower().Contains(text) ||
                                                                                                  el.AUTHOR.ToLower().Contains(text)))
                                                                                                  ;
            }
            else
            {
                busketBooks = DataWorkerUserApp.GetBusketBooks();
            }
            NotifyPropertyChange("BusketBooks");
        }
        public void ClickOnBook(Books book)
        {
            if (book != null)
            {
                if (bookNow.Count != 0)
                {
                    bookNow.Clear();
                }
                bookNow.Add(book);
            }
        }
        public async void DownloadBookMethodMain()
        {
            if (bookNow.First().TYPE_PRICE == "paying")
            {
                if (DataWorkerUserApp.GetAllPayment().Where(el => el.ID_BOOK == BookNow.First().ID_BOOK).Select(el => el.STATE).Contains("waiting"))
                {
                    MessageBox.Show("Ожидайте оповещения от администратора!", "DownloadBook", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (DataWorkerUserApp.GetAllPayment().Where(el => el.ID_BOOK == bookNow.First().ID_BOOK).Select(el => el.STATE).Contains("confirmed"))
                {
                    DownloadBookMethod();
                    return;
                }
                var form = new FormForBuyBook();
                if (form.ShowDialog() == true)
                {
                    DataWorkerUserApp.AddPayment(form.Date.Text, bookNow.First().ID_BOOK, form.NameOwner.Text, form.NumberCard.Text);
                    MessageBox.Show("Книга успешно приобретена! Ждите подтверждения оплаты администратора!", "GoodPay", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await PutMessageEmail();
                }
                else
                {
                    MessageBox.Show("Книга не куплена!", "ErrorPay", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (busketBooks.Contains(bookNow.First()))
                {
                    DownloadBookMethod();
                }
                else
                {
                    MessageBox.Show("Книги нет в корзине!", "ErrorDownloadBook", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void DownloadBookMethod()
        {
            string filePath = BookNow.First().PATH_DOWNLOAD;
            FolderBrowserDialog openFold = new FolderBrowserDialog();
            if (openFold.ShowDialog() == DialogResult.OK)
            {
                string foldPath = openFold.SelectedPath + '\\';
                string pathFull = Path.Combine(foldPath, Path.GetFileName(filePath));
                File.Copy(filePath, pathFull, true);
                MessageBox.Show($"Книга успешно скачана по пути {pathFull}! Можете открыть ее", "DowloadBook", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void DeleteBookMethod()
        {
            DataWorkerUserApp.DeleteBookFromBusket(bookNow.First().ID_BOOK);
            busketBooks = DataWorkerUserApp.GetBusketBooks();
        }
        public async Task PutMessageEmail()
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
                mailMessage.To.Add(SettingOfApp.LocalUser.EMAIL);
                mailMessage.Subject = $"Покупка книги \"{bookNow.First().NAME}\"";
                var htmlBody = $"<html><body><p style='font-size: 18pt;'>Покупка книги {bookNow.First().NAME}.</p>" +
                    $"<br><img src=\"cid:bookImage\" style='width: 300px; height: 500px;'>" +
                    $"<p style='font-size: 18pt;'>Здравствуйте, {SettingOfApp.LocalUser.NAME}! Благодарим вас за покупку нашей книги! Ждите подтверждения администратора в течение 24 часов!</p></body></html>";
                AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);
                // Создаем объект LinkedResource с изображением
                LinkedResource bookImage = new LinkedResource(bookNow.First().IMAGE_BOOK, MediaTypeNames.Image.Jpeg);
                bookImage.ContentId = "bookImage";
                alternateView.LinkedResources.Add(bookImage);

                // Добавляем тело письма в сообщение
                mailMessage.AlternateViews.Add(alternateView);
                //mailMessage.Body = "This is a test email.";

                // Отправляем сообщение
                smtpClient.Send(mailMessage);
            });
        }
        public void AddReviewMethod(System.Windows.Controls.TextBox text)
        {
            if (string.IsNullOrWhiteSpace(text.Text))
            {
                MessageBox.Show("Отзыв пустой!", "ErrorReview", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Reviews review = new Reviews()
            {
                DATE = DateTime.Now,
                ID_BOOK = bookNow.First().ID_BOOK,
                LOGIN = SettingOfApp.LocalUser.LOGIN,
                REVIEW_TEXT = text.Text
            };
            DataWorkerUserApp.AddReview(review);
            allReviews = DataWorkerUserApp.GetReviews(bookNow.First().ID_BOOK);
            text.Text = String.Empty;
        }
    }
}
