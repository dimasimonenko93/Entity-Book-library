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
            using (var bookLibraryDb = new LibraryContext())
            {
                return bookLibraryDb.Books.Local.ToBindingList();
            }
        }

        public object GetReadersToBindingList()
        {
            using (var bookLibraryDb = new LibraryContext())
            {
                return bookLibraryDb.Readers.Local.ToBindingList();
            }
        }

        public List<Book> GetAllBooks()
        {
            using (var bookLibraryDb = new LibraryContext())
            {
                return bookLibraryDb.Books.ToList();
            }
        }

        public List<Reader> GetAllReaders()
        {
            using (var bookLibraryDb = new LibraryContext())
            {
                return bookLibraryDb.Readers.ToList();
            }
        }
    }
}
