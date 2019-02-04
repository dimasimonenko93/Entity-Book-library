using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibrary;
using BookLibrary.Models;

namespace BookLibrary.DAL
{
    public class DatabaseManagement
    {
        public IBindingList GetBooksToBindingList()
        {
            using (var db = new LibraryContext())
            {
                return db.Books.Local.ToBindingList();
            }
        }

        public IBindingList GetReadersToBindingList()
        {
            using (var db = new LibraryContext())
            {
                return db.Readers.Local.ToBindingList();
            }
        }
    }
}
