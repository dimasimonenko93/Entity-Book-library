using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using BookLibrary.DAL;
using BookLibrary.Models;

namespace BusinessLogic
{
    public class Management
    {
        private List<BookProperties> books;
        public List<ReaderProperties> readers;

        private EntitiesBase dataBase;
        
        public Management()
        {
            dataBase = new EntitiesBase();

            books = dataBase.books.GetAll();
            readers = dataBase.readers.GetAll();
        }

        public BookProperties GetBook(int id)
        {
            return dataBase.books.Get(id);
        }

        public List<BookProperties> GetAllBooks()
        {
            return dataBase.books.GetAll();
        }

        public void CreatBook(BookProperties b)
        {
            dataBase.books.Create(b);
            books.Add(b);
        }

        public void EditBook(BookProperties b)
        {
            dataBase.books.Update(b);
        }

        public void DeleteBook(int bookId)
        {
            dataBase.books.Delete(bookId);
        }

        public BookProperties SetBookValue(BookProperties book, string nameOfProperty, object value)
        {
            PropertyInfo[] properties = book.GetType().GetProperties();

            foreach (PropertyInfo propertyInfo in properties)
            {
                if(propertyInfo.Name == nameOfProperty)
                {
                    propertyInfo.SetValue(book, value);
                }
            }
            return book;
        }
    }
}
