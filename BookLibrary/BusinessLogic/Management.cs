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
            return databaseManagement.GetBooks();
        }

        public object LoadDataGridViewReaders()
        {
            return databaseManagement.GetReaders();
        }
    }
}
