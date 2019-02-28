using BookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.DAL
{
    public class BookRepository
    {
        public BookProperties Get(int id)
        {
            using (var db = new LibraryContext())
            {
                return db.Books.Find(id);
            }
        }

        public List<BookProperties> GetAll()
        {
            using (var db = new LibraryContext())
            {
                return db.Books.ToList();
            }
        }
    }
}
