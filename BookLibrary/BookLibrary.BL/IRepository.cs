using BookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.BL
{
    public interface IRepository
    {
        PropertyInfo[] properties { get; set; }
        List<object> GetAll();
        int Create();
        void Delete(int bookId);
        void SetValue(int bookId, string nameOfProperty, object value);
    }
}
