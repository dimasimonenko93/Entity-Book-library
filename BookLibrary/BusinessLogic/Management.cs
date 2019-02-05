using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibrary;
using BookLibrary.DAL;
using BookLibrary.Models;

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

        public void CreateBook(BookProperties book)
        {
            databaseManagement.book.Create(book);
        }

        public void DeleteBook(int id)
        {
            databaseManagement.book.Delete(id);
        }

        public IEnumerable<BookProperties> FindBook(Func<BookProperties, bool> predicate)
        {
            return databaseManagement.book.Find(predicate);
        }

        public BookProperties GetBook(int id)
        {
            return databaseManagement.book.Get(id);
        }

        public IEnumerable<BookProperties> GetAllBooks()
        {
            return databaseManagement.book.GetAll();
        }

        public void Update(BookProperties book)
        {
            databaseManagement.book.Update(book);
        }

    }
}
