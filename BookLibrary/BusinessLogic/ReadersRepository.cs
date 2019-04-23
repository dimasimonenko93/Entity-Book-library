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
        private ReaderRepository readers;

        public ReadersRepository()
        {
            readers = new ReaderRepository();
        }

        public int Create()
        {
            ReaderProperties reader = new ReaderProperties();
            readers.Create(reader);
            return reader.Id;
        }

        public void Delete(int readerId)
        {
            readers.Delete(readerId);
        }

        public List<IItemProperties> GetAll()
        {
            return readers.GetAll().ToList<IItemProperties>();
        }

        public void SetValue(int readerId, string nameOfProperty, object value)
        {
            ReaderProperties reader = readers.Get(readerId);

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
