using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.DAL
{
    public class BookDb : Book, IDatabaseItem
    {
        public void AddToDatabase(IDatabaseItem b)
        {
            using(LibraryContext db = new LibraryContext())
            {
                db.Books.Add((Book)b);
            }
        }
    }
}
