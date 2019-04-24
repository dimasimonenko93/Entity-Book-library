using BookLibrary.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;

namespace BookLibrary.DAL
{
    public class BookRepository
    {
        public Book Get(int id)
        {
            using (var db = new LibraryContext())
            {
                return db.Books.Find(id);
            }
        }

        public List<Book> GetAll()
        {
            using (var db = new LibraryContext())
            {
                return db.Books.ToList();
            }
        }

        public void Create(Book book)
        {
            using (var db = new LibraryContext())
            {
                db.Books.Add(book);
                db.SaveChanges();
            }
        }

        public void Update(Book book)
        {
            using (var db = new LibraryContext())
            {
                db.Entry(book).State = EntityState.Modified; // Update all properties
                //db.Books.Attach(book);                     // Update only changed properties // Dont work !!
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new LibraryContext())
            {
                Book book = db.Books.Find(id);
                if (book != null)
                    db.Books.Remove(book);
                db.SaveChanges();
            }
        }
    }
}
