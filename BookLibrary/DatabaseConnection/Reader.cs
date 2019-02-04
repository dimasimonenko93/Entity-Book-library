using BookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.DAL
{
    public class Reader : IModels<ReaderProperties>
    {
        public void Create(ReaderProperties item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReaderProperties> Find(Func<ReaderProperties, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public ReaderProperties Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReaderProperties> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(ReaderProperties item)
        {
            throw new NotImplementedException();
        }
    }
}
