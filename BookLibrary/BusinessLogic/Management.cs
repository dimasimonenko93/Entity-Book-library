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
    }
}
