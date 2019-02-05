using BookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.DAL
{
    public class Book : IModels<BookProperties>
    {
        public void Create(BookProperties book)
        {
            using (var db = new LibraryContext())
            {
                db.Books.Add(book);
            }
        }

        public void Delete(int id)
        {
            using (var db = new LibraryContext())
            {
                BookProperties book = db.Books.Find(id);
                if (book != null)
                    db.Books.Remove(book);
            }
        }

        public IEnumerable<BookProperties> Find(Func<BookProperties, bool> predicate)
        {
            using (var db = new LibraryContext())
            {
                return db.Books.Where(predicate).ToList();
            }
        }

        public BookProperties Get(int id)
        {
            using (var db = new LibraryContext())
            {
                return db.Books.Find(id);
            }
        }

        public IEnumerable<BookProperties> GetAll()
        {
            using (var db = new LibraryContext())
            {
                return db.Books;
            }
        }

        public void Update(BookProperties book)
        {
            using (var db = new LibraryContext())
            {
                db.Entry(book).State = System.Data.Entity.EntityState.Modified;
            }
        }
    }
}
