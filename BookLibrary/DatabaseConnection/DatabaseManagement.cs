using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibrary;

namespace BusinessLogic
{
    public class DatabaseManagement
    {
        public object GetBooksToBindingList()
        {
            using (var db = new LibraryContext())
            {
                return db.Books.Local.ToBindingList();
            }
        }

        public object GetReadersToBindingList()
        {
            using (var db = new LibraryContext())
            {
                return db.Readers.Local.ToBindingList();
            }
        }

        public List<Book> GetAllBooks()
        {
            using (var db = new LibraryContext())
            {
                return db.Books.ToList();
            }
        }

        public List<Reader> GetAllReaders()
        {
            using (var db = new LibraryContext())
            {
                return db.Readers.ToList();
            }
        }

        public void AddBook(Book b)
        {
            using (var db = new LibraryContext())
            {
                db.Books.Add(b);
                db.SaveChanges();
            }
        }

        public Book GetBook(Book b)
        {
            using(var db = new LibraryContext())
            {
                var book = db.Books.Find(b.Id);
                return book;
            }
        }

        public void EditBook(Book b)
        {
            using (var db = new LibraryContext())
            {
                var book = db.Books.Find(b.Id);
                book = b;
                db.SaveChanges();
            }
        }

        public void DeleteBook(Book b)
        {
            using(var db = new LibraryContext())
            {
                db.Books.Remove(db.Books.Find(b.Id));
                db.SaveChanges();
            }
        }
    }
}
