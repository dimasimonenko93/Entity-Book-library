using BookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.DAL
{
    public class Book : IModels<BookProperties>
    {
        public void Create(BookProperties item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookProperties> Find(Func<BookProperties, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public BookProperties Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookProperties> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(BookProperties item)
        {
            throw new NotImplementedException();
        }
    }
}
