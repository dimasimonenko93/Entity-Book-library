using BookLibrary.DAL;
using BookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.BL
{
    public class Repositoty<T> where T : class, new()
    {
        public PropertyInfo[] EntityProperties { get; set; }

        private DAL<T> items;

        public Repositoty()
        {
            items = new DAL<T>();
            EntityProperties = typeof(T).GetProperties();
        }

        public T CreateItem()
        {
            T item = new T();
            items.Create(item);
            return item;
        }

        public void DeleteItem(int itemId)
        {
            items.Delete(itemId);
        }

        public List<object> GetAllItems()
        {
            return items.GetAll().ToList<object>();
        }

        public void SetValueItem(int itemId, string nameOfProperty, object value)
        {
            T item = items.Get(itemId);

            PropertyInfo[] properties = item.GetType().GetProperties();

            foreach (PropertyInfo propertyInfo in properties)
            {
                if (propertyInfo.Name == nameOfProperty)
                {
                    propertyInfo.SetValue(item, value);
                }
            }
            items.Update(item);
        }
    }
}
