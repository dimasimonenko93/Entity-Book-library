using BookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.DAL
{
    public class Reader : IMethods<ReaderProperties>
    {
        public void Create(ReaderProperties reader)
        {
            using (var db = new LibraryContext())
            {
                db.Readers.Add(reader);
            }
        }

        public void Delete(int id)
        {
            using (var db = new LibraryContext())
            {
                ReaderProperties reader = db.Readers.Find(id);
                if (reader != null)
                    db.Readers.Remove(reader);
            }
        }

        public IEnumerable<ReaderProperties> Find(Func<ReaderProperties, bool> predicate)
        {
            using (var db = new LibraryContext())
            {
                return db.Readers.Where(predicate).ToList();
            }
        }

        public ReaderProperties Get(int id)
        {
            using (var db = new LibraryContext())
            {
                return db.Readers.Find(id);
            }
        }

        public IEnumerable<ReaderProperties> GetAll()
        {
            using (var db = new LibraryContext())
            {
                return db.Readers;
            }
        }

        public void Update(ReaderProperties reader)
        {
            using (var db = new LibraryContext())
            {
                db.Entry(reader).State = System.Data.Entity.EntityState.Modified;
            }
        }
    }
}
