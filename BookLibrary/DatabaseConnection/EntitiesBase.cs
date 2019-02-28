using BookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.DAL
{
    public class EntitiesBase
    {
        public BookRepository books; 

        public EntitiesBase()
        {
            books = new BookRepository();
        }
    }
}
