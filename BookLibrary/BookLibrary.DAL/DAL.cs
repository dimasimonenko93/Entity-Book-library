using BookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.DAL
{
    public class DAL<T> : DbContext where T : class, new()
    {
        public DbSet<T> Items { get; set; }

        public T Get(int id)
        {
            return Items.Find(id);
        }

        public List<T> GetAll()
        {
            return Items.ToList();
        }

        public void Create(T item)
        {
            Items.Add(item);
            SaveChanges();
        }

        public void Update(T item)
        {
            Entry(item).State = EntityState.Modified;
            SaveChanges();
        }

        public void Delete(int id)
        {
            T item = Items.Find(id);
            if (item != null)
                Items.Remove(item);
            SaveChanges();
        }
    }
}
