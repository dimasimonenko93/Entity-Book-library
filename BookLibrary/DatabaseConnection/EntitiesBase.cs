namespace BookLibrary.DAL
{
    public class EntitiesBase
    {
        public BookRepository books;
        public ReaderRepository readers;

        public EntitiesBase()
        {
            books = new BookRepository();
            readers = new ReaderRepository();
        }
    }
}
