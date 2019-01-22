using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibrary;

namespace BusinessLogic
{
    public class Management
    {
        DatabaseManagement databaseManagement;

        public Management()
        {
            databaseManagement = new DatabaseManagement();
        }

        public object LoadDataGridViewBooks()
        {
            return databaseManagement.GetBooksToBindingList();
        }

        public object LoadDataGridViewReaders()
        {
            return databaseManagement.GetReadersToBindingList();
        }

        public void CreateBook()
        {
            var book = new Book();
            databaseManagement.AddBook(book);
        }
    }
}
