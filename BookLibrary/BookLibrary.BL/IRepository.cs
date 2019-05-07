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
        PropertyInfo[] EntityProperties { get; set; }
        List<object> GetAllItems();
        int CreateItem();
        void DeleteItem(int itemId);
        void SetValueItem(int itemkId, string nameOfProperty, object value);
    }
}
