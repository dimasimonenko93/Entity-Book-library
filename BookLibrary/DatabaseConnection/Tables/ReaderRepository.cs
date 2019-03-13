using BookLibrary.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookLibrary.DAL
{
    public class ReaderRepository
    {
        public ReaderProperties Get(int id)
        {
            using (var db = new LibraryContext())
            {
                return db.Readers.Find(id);
            }
        }

        public List<ReaderProperties> GetAll()
        {
            using (var db = new LibraryContext())
            {
                return db.Readers.ToList();
            }
        }
    }
}
