using BookLibrary.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BookLibrary.DAL
{
    public class ReaderDAL : DbContext
    {
        public DbSet<Reader> Readers { get; set; }

        public Reader Get(int id)
        {
            return Readers.Find(id);
        }

        public List<Reader> GetAll()
        {
            return Readers.ToList();
        }

        public void Create(Reader reader)
        {
            Readers.Add(reader);
            SaveChanges();
        }

        public void Update(Reader reader)
        {
            Entry(reader).State = EntityState.Modified;
            SaveChanges();
        }

        public void Delete(int id)
        {
            Reader reader = Readers.Find(id);
            if (reader != null)
                Readers.Remove(reader);
            SaveChanges();
        }
    }
}
