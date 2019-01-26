using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibrary;
using BookLibrary.DAL;

namespace BusinessLogic
{
    public class Management
    {
        DatabaseManagement databaseManagement;

        public Management()
        {
            databaseManagement = new DatabaseManagement();
        }

        public IBindingList LoadDataGridViewBooks()
        {
            return databaseManagement.GetBooksToBindingList();
        }

        public IBindingList LoadDataGridViewReaders()
        {
            return databaseManagement.GetReadersToBindingList();
        }

        public void CreateBook()
        {
            var book = new BookDb();
            databaseManagement.Add(book);
        }

        public void GetBook(Book b)
        {
            databaseManagement.GetBook(b);
        }

        public void EditBook(Book b)
        {
            databaseManagement.EditBook(b);
        }

        public void RemoveBook(Book b)
        {
            databaseManagement.RemoveBook(b);
        }
    }
}
