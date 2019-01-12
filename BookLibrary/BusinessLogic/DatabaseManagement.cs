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
        LibraryContext BookLIbraryDb = new LibraryContext();

        public object DataGridViewBooks()
        {
           return BookLIbraryDb.Books.Local.ToBindingList();
        }

        public object DataGridViewReaders()
        {
            return BookLIbraryDb.Readers.Local.ToBindingList();
        }
    }
}
