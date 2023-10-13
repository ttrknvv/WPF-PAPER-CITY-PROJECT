using EXAMPLE.Model.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAMPLE.Model
{
    public class DataWorkerAdminApp
    {
        // получить каталог книг
        public static ObservableCollection<Books> GetCatalog()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var catalog = db.BOOKS.ToList();
                return new ObservableCollection<Books>( catalog);
            }
        }

        // получить отзывы книг
        public static ObservableCollection<Reviews> GetReviews(int id_book)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return new ObservableCollection<Reviews>(db.REVIEWS.Where(el => el.ID_BOOK == id_book).OrderByDescending(el => el.ID_REVIEW));
            }
        }
        // добавить книгу
        public static void AddBook(Books book)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.BOOKS.Add(book);
                db.SaveChanges();
            }
        }
        // удалить книгу
        public static void DeleteBook(Books book)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.BUSKET_BOOKS.RemoveRange(db.BUSKET_BOOKS.Where(el => el.ID_BOOK == book.ID_BOOK));
                db.REVIEWS.RemoveRange(db.REVIEWS.Where(el => el.ID_BOOK == book.ID_BOOK));
                db.PAYMENT.RemoveRange(db.PAYMENT.Where(el => el.ID_BOOK == book.ID_BOOK));
                db.SaveChanges();
                db.BOOKS.Remove(book);
                db.SaveChanges();
            }
        }
        // заменить книгу
        public static void RefreshBook(int id_book, Books book)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Books bookk = db.BOOKS.FirstOrDefault(el => el.ID_BOOK == id_book);
                bookk.GENRE = book.GENRE;
                bookk.NAME = book.NAME;
                bookk.COST = book.COST;
                bookk.IMAGE_BOOK = book.IMAGE_BOOK;
                bookk.TYPE_PRICE = book.TYPE_PRICE;
                bookk.AUTHOR = book.AUTHOR;
                bookk.DESCRIPTION = book.DESCRIPTION;
                db.SaveChanges();
            }
        }
        // удалить отзыв
        public static void DeleteReview(Reviews review)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.REVIEWS.Remove(review);
                db.SaveChanges();
            }
        }
        // получить список всезх пользователей
        public static ObservableCollection<User> GetAllUsers()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return new ObservableCollection<User>(db.USERS.Where(el => el.ROLE == "common").ToList<User>());
            }
        }
        // получить список платежей ожидаюших подтверждения
        public static ObservableCollection<Payment> GetPayments()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return new ObservableCollection<Payment>(db.PAYMENT.Where(el => el.STATE == "waiting").ToList<Payment>());
            }
        }
        // подтвердить или отменить платежь
        public static void SetPayments(int id_payment, bool result)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Payment payment = db.PAYMENT.FirstOrDefault(el => el.ID_PAY == id_payment);
                payment.STATE = result ? "confirmed" : "rejected";
                db.SaveChanges();
            }
        }
        // получить книгу по id
        public static Books GetBookById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.BOOKS.FirstOrDefault(el => el.ID_BOOK == id);
            }
        }
        // получить пользователя по id
        public static User GetUserById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.USERS.FirstOrDefault(el => el.ID_USER == id);
            }
        }
        // получить сообщения в тех. поддержку
        public static ObservableCollection<ReviewProblem> GetReviewsProblem()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var review = db.REVIEW_PROBLEM.ToList();
                return new ObservableCollection<ReviewProblem>(review.Where(el => el.STATE == "waiting"));
            }
        }
        // получить пользователя по логину
        public static User GetUserByLogin(string login)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.USERS.FirstOrDefault(el => el.LOGIN == login);
            }
        }
        // ответить на отзыв
        public static void SendReview(ReviewProblem review)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                ReviewProblem rev = db.REVIEW_PROBLEM.FirstOrDefault(el => el.ID_REVIEW == review.ID_REVIEW);
                rev.STATE = "confirmed";
                db.SaveChanges();
            }
        }
    }
}
