using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using BookLibrary.DAL;
using BookLibrary.Models;

namespace BookLibrary.BL
{
    public class BooksRepository : IRepository
    {
        public PropertyInfo[] EntityProperties { get; set; }

        private BookDAL books;

        public BooksRepository()
        {
            books = new BookDAL();
            EntityProperties = typeof(Book).GetProperties();
        }

        public int CreateItem()
        {
            Book book = new Book();
            books.Create(book);
            return book.Id;
        }

        public void DeleteItem(int bookId)
        {
            books.Delete(bookId);
        }

        public List<object> GetAllItems()
        {
            return books.GetAll().ToList<object>();
        }

        public void SetValueItem(int bookId, string nameOfProperty, object value)
        {
            Book book = books.Get(bookId);

            PropertyInfo[] properties = book.GetType().GetProperties();

            foreach(PropertyInfo propertyInfo in properties)
            {
                if (propertyInfo.Name == nameOfProperty)
                {
                    propertyInfo.SetValue(book, value);
                }
            }
            books.Update(book);
        }
    }
}
