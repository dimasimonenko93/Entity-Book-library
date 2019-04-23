using BookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.BL
{
    public interface IRepository
    {
        List<IItemProperties> GetAll();
        int Create();
        void Delete(int bookId);
        void SetValue(int bookId, string nameOfProperty, object value);
    }
}
