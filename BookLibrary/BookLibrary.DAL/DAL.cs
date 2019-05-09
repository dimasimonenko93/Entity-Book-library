using BookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.DAL
{
    public class DAL<T> where T : class, new()
    {
        private LibraryContext<T> dataBase;
        private DbSet<T> Items { get; set; }

        public DAL()
        {
            dataBase = new LibraryContext<T>();
            Items = dataBase.Set<T>();
        }

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
            dataBase.SaveChanges();
        }

        public void Update(T item)
        {
            dataBase.Entry(item).State = EntityState.Modified;
            dataBase.SaveChanges();
        }

        public void Delete(int id)
        {
            T item = Items.Find(id);
            if (item != null)
                Items.Remove(item);
            dataBase.SaveChanges();
        }
    }
}
