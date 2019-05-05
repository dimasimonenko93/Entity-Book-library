using BookLibrary.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;

namespace BookLibrary.DAL
{
    public class BookDAL : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public Book Get(int id)
        {
            return Books.Find(id);
        }

        public List<Book> GetAll()
        {
            return Books.ToList();
        }

        public void Create(Book book)
        {
            Books.Add(book);
            SaveChanges();
        }

        public void Update(Book book)
        {
            Entry(book).State = EntityState.Modified; // Update all properties
            //db.Books.Attach(book);                  // Update only changed properties // Dont work !!
            SaveChanges();
        }

        public void Delete(int id)
        {
            Book book = Books.Find(id);
            if (book != null)
                Books.Remove(book);
            SaveChanges();
        }
    }
}
