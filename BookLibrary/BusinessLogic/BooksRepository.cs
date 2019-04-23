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
        private BookRepository books;

        public BooksRepository()
        {
            books = new BookRepository();
        }

        public int Create()
        {
            BookProperties book = new BookProperties();
            books.Create(book);
            return book.Id;
        }

        public void Delete(int bookId)
        {
            books.Delete(bookId);
        }

        public List<IItemProperties> GetAll()
        {
            return books.GetAll().ToList<IItemProperties>();
        }

        public void SetValue(int bookId, string nameOfProperty, object value)
        {
            BookProperties book = books.Get(bookId);

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
