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
        private EntitiesBase dataBase;

        public List<BookProperties> books;
        
        public Management()
        {
            dataBase = new EntitiesBase();

            books = GetAllBooks();
        }

        //public BookProperties GetBook(int bookId)
        //{
        //    return dataBase.books.Get(bookId);
        //}

        //public ReaderProperties GetReader(int readerId)
        //{
        //    return dataBase.readers.Get(readerId);
        //}

        public List<BookProperties> GetAllBooks()
        {
            return dataBase.books.GetAll();
        }

        public List<ReaderProperties> GetAllReaders()
        {
            return dataBase.readers.GetAll();
        }

        public void CreateBook(BookProperties book)
        {
            dataBase.books.Create(book);
        }

        public void CreateReader(ReaderProperties reader)
        {
            dataBase.readers.Create(reader);
        }

        //public void EditBook(BookProperties book)
        //{
        //    dataBase.books.Update(book);
        //}

        //public void EditReader(ReaderProperties reader)
        //{
        //    dataBase.readers.Update(reader);
        //}

        public void DeleteBook(int bookId)
        {
            dataBase.books.Delete(bookId);
        }

        public void DeleteReader(int readerId)
        {
            dataBase.readers.Delete(readerId);
        }

        public void SetBookValue(int bookId, string nameOfProperty, object value)
        {
            BookProperties book = dataBase.books.Get(bookId);

            PropertyInfo[] properties = book.GetType().GetProperties();

            FindProperty(properties, nameOfProperty).SetValue(book, value);

            dataBase.books.Update(book);
        }

        public ReaderProperties SetReaderValue(ReaderProperties reader, string nameOfProperty, object value)
        {
            PropertyInfo[] properties = reader.GetType().GetProperties();

            foreach (PropertyInfo propertyInfo in properties)
            {
                if (propertyInfo.Name == nameOfProperty)
                {
                    propertyInfo.SetValue(reader, value);
                }
            }
            return reader;
        }

        private PropertyInfo FindProperty(PropertyInfo[] properties, string nameOfProperty)
        {
            foreach(PropertyInfo propertyInfo in properties)
            {
                if (propertyInfo.Name == nameOfProperty)
                {
                    return propertyInfo;
                }
            }
            return null;
        }
    }
}
