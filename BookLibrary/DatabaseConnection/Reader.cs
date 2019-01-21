using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class Reader
    {
        public int    Id          { get; set; }
        public string Name        { get; set; }
        public int    Age         { get; set; }
        public string Sex         { get; set; }
        public string Certificate { get; set; }
        public int    PhoneNumber { get; set; }
        public string Mail        { get; set; }

        public List<Book> BooksOnHand  = new List<Book>();
        public List<Book> BooksHistory = new List<Book>();
    }
}
