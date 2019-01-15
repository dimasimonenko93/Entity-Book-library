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
        public object GetBooks()
        {
            using (var bookLibraryDb = new LibraryContext())
            {
                return bookLibraryDb.Books.Local.ToBindingList();
            }
        }

        public object GetReaders()
        {
            using (var bookLibraryDb = new LibraryContext())
            {
                return bookLibraryDb.Readers.Local.ToBindingList();
            }
        }
    }
}
