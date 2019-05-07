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
    public class Repository<T> : IRepository where T : class, IModel, new()
    {
        public PropertyInfo[] EntityProperties { get; set; }

        private DAL<T> items;

        public Repository()
        {
            items = new DAL<T>();
            EntityProperties = typeof(T).GetProperties();
        }

        public int CreateItem()
        {
            T item = new T();
            items.Create(item);
            IModel itemID = item;
            return itemID.Id;
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
