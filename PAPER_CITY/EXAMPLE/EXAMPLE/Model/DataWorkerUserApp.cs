using EXAMPLE.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EXAMPLE.View;
using System.Windows;
using System.Collections.ObjectModel;
using EXAMPLE.View.AdminAppView;

namespace EXAMPLE.Model
{
    public class DataWorkerUserApp
    {
        // получить каталог книг
        public static List<Books> GetCatalog()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var catalog = db.BOOKS.ToList();
                return catalog;
            }
        }

        // добавить пользователя
        public static void RegisterNewUser(string Login, string Password, string Name, string Email)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User user = new User()
                {
                    DATE_REGISTRATION = DateTime.Now,
                    EMAIL = Email,
                    IMAGE_PROFILE = "D:\\2k2s\\COURSE_PROJECT\\SOURCE\\PHOTOES\\defaultUserIcon.png",
                    PASSWORD = Password,
                    LOGIN = Login,
                    NAME = Name,
                    PHONE_NUMBER = "",
                    ROLE = "common"
                };
                db.USERS.Add(user);
                db.SaveChanges();
                Busket busket = new Busket()
                {
                    ID_USER = db.USERS.FirstOrDefault(d => d.LOGIN == user.LOGIN).ID_USER
                };
                db.BUSKET.Add(busket);
                db.SaveChanges();
            }
        }
        // получить пользователя
        public static void LogInUserGet(string login, string pasword)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User user = db.USERS.First<User>(el => el.LOGIN == login && el.PASSWORD == pasword);
                int id_busket = 0;
                if (user != null)
                {
                    SettingOfApp.LocalUser = user;
                    switch (user.ROLE)
                    {
                        case "common":  id_busket = db.BUSKET.First(el => el.ID_USER == user.ID_USER).ID_BUSKET;
                                        SettingOfApp.busket = id_busket;
                                        MainWindow window = new MainWindow();
                                        window.Show();
                                        break;
                        case "admin": AdminMainWindow wind = new AdminMainWindow();
                                      wind.Show();
                                      break;
                    }
                    
                    
                }
            }
        }
        // получить корзину
        public static List<Books> GetBasket()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                int numberBasket = db.BUSKET.FirstOrDefault(x => x.ID_USER == SettingOfApp.LocalUser.ID_USER).ID_BUSKET;
                var basket = db.BUSKET_BOOKS.Where(x => x.ID_BUSKET == numberBasket).Select(y => y.ID_BOOK).ToList();
                var resBusket = db.BOOKS.Where(x => basket.Contains(x.ID_BOOK)).ToList();
                return resBusket;
            }
        }

        // изменить фото профиля
        public static void ChangePhotoProfile(string path)
        {
            if(!string.IsNullOrEmpty(path))
            {
                using(ApplicationContext db = new ApplicationContext())
                {
                    User user = db.USERS.FirstOrDefault(d => d.ID_USER == SettingOfApp.LocalUser.ID_USER);
                    user.IMAGE_PROFILE = path;
                    db.SaveChanges();
                }
            }
        }
        // изменить телефон профиля
        public static void ChangePhoneProfile(string phone)
        {
            if(!string.IsNullOrEmpty(phone))
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    User user = db.USERS.FirstOrDefault(d => d.ID_USER == SettingOfApp.LocalUser.ID_USER);
                    user.PHONE_NUMBER = phone;
                    db.SaveChanges();
                }
            }
        }
        // добавить попудярность книге
        public static void AddPopularity(int id_book, int popularity)
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                Books book = db.BOOKS.FirstOrDefault(d => d.ID_BOOK == id_book);
                book.POPULARITY += popularity;
                db.SaveChanges();
            }
        }
        // добавить книгу в корзину
        public static void AddBookOnBusket(int id_book)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    BusketBooks busket = new BusketBooks()
                    {
                        ID_BOOK = id_book,
                        ID_BUSKET = SettingOfApp.busket
                    };
                    if (db.BUSKET_BOOKS.Where(el => el.ID_BUSKET == SettingOfApp.busket && el.ID_BOOK == id_book).Count() == 0)
                    {
                        db.BUSKET_BOOKS.Add(busket);
                        db.SaveChanges();
                        MessageBox.Show("Книга успешно добавлена!", "AddBookInBusket", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Книга уже есть в корзине!", "AddBookInBusket", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch 
            { 
            }
            
        }
        // получить книги в корзине
        public static ObservableCollection<Books> GetBusketBooks()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var list = db.BUSKET_BOOKS.Where(el => el.ID_BUSKET == SettingOfApp.busket).Select(el => el.ID_BOOK).ToList<int>();
                ObservableCollection<Books> listBooks = new ObservableCollection<Books>(db.BOOKS.Where(el => list.Contains(el.ID_BOOK)));
                return listBooks;
            }
        }
        // удалить книгу из корзины
        public static void DeleteBookFromBusket(int id_book)
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                BusketBooks book = db.BUSKET_BOOKS.FirstOrDefault(el => el.ID_BUSKET == SettingOfApp.busket && el.ID_BOOK == id_book);
                if(book != null)
                {
                    db.BUSKET_BOOKS.Remove(book);
                    db.SaveChanges();
                    MessageBox.Show("Книга успешно удалена из корзины!", "RemoveBook", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("У вас нет такой книги!", "RemoveBook", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        // получить все оплаты
        public static List<Payment> GetAllPayment()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var payments = db.PAYMENT.Where(el => el.ID_USER == SettingOfApp.LocalUser.ID_USER).ToList();
                return payments;
            }
        }
        // добавить оплату книги
        public static void AddPayment(string date, int id_book, string name, string number)
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                Payment newPay = new Payment()
                {
                    DATE = date,
                    ID_BOOK = id_book,
                    ID_USER = SettingOfApp.LocalUser.ID_USER,
                    STATE = "waiting",
                    NAME_OWNER = name,
                    NUMBER_CARD = number

                };
                db.PAYMENT.Add(newPay);
                db.SaveChanges();
            }
        }
        // получить отзывы данной книги
        public static ObservableCollection<Reviews> GetReviews(int id_book)
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                return new ObservableCollection<Reviews>(db.REVIEWS.Where(el => el.ID_BOOK == id_book).OrderByDescending(el => el.ID_REVIEW));
            }
        }
        // добавить отзыв
        public static void AddReview(Reviews review)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.REVIEWS.Add(review);
                db.SaveChanges();
            }
        }
        // добавить сообщение об ошибке, отзыв
        public static void AddReviewOrProblem(ReviewProblem review)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.REVIEW_PROBLEM.Add(review);
                db.SaveChanges();
            }
        }
    }
}
