using BookLibrary.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BookLibrary.DAL
{
    public class ReaderRepository
    {
        public Reader Get(int id)
        {
            using (var db = new LibraryContext())
            {
                return db.Readers.Find(id);
            }
        }

        public List<Reader> GetAll()
        {
            using (var db = new LibraryContext())
            {
                return db.Readers.ToList();
            }
        }

        public void Create(Reader reader)
        {
            using (var db = new LibraryContext())
            {
                db.Readers.Add(reader);
                db.SaveChanges();
            }
        }

        public void Update(Reader reader)
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
                Reader reader = db.Readers.Find(id);
                if (reader != null)
                    db.Readers.Remove(reader);
                db.SaveChanges();
            }
        }
    }
}
