using BookLibrary.Models;
using System.Collections.Generic;
using System.Data.Entity;
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

        public void Create(ReaderProperties reader)
        {
            using (var db = new LibraryContext())
            {
                db.Readers.Add(reader);
                db.SaveChanges();
            }
        }

        public void Update(ReaderProperties reader)
        {
            using (var db = new LibraryContext())
            {
                db.Entry(reader).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new LibraryContext())
            {
                ReaderProperties reader = db.Readers.Find(id);
                if (reader != null)
                    db.Readers.Remove(reader);
                db.SaveChanges();
            }
        }
    }
}
