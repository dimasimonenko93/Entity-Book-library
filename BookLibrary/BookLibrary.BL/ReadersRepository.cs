using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BookLibrary.DAL;
using BookLibrary.Models;

namespace BookLibrary.BL
{
    public class ReadersRepository : IRepository
    {
        public PropertyInfo[] EntityProperties { get; set; }

        private ReaderDAL readers;

        public ReadersRepository()
        {
            readers = new ReaderDAL();
            EntityProperties = typeof(Reader).GetProperties();
        }

        public int CreateItem()
        {
            Reader reader = new Reader();
            readers.Create(reader);
            return reader.Id;
        }

        public void DeleteItem(int readerId)
        {
            readers.Delete(readerId);
        }

        public List<object> GetAllItems()
        {
            return readers.GetAll().ToList<object>();
        }

        public void SetValueItem(int readerId, string nameOfProperty, object value)
        {
            Reader reader = readers.Get(readerId);

            PropertyInfo[] properties = reader.GetType().GetProperties();

            foreach (PropertyInfo propertyInfo in properties)
            {
                if (propertyInfo.Name == nameOfProperty)
                {
                    propertyInfo.SetValue(reader, value);
                }
            }
            readers.Update(reader);
        }
    }
}
