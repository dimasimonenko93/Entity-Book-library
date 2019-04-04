using System.Collections.Generic;

namespace BookLibrary.Models
{
    public class ReaderProperties : IItemProperties
    {
        public int    Id          { get; set; }
        public string Name        { get; set; }
        public int    Age         { get; set; }
        public string Sex         { get; set; }
        public string Certificate { get; set; }
        public int    PhoneNumber { get; set; }
        public string Mail        { get; set; }

        public List<BookProperties> BooksOnHand  = new List<BookProperties>();
        public List<BookProperties> BooksHistory = new List<BookProperties>();
    }
}
