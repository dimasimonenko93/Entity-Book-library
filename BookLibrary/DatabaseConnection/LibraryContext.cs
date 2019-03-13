using System.Data.Entity;
using BookLibrary.Models;

namespace BookLibrary
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() : base("DbConnection")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<LibraryContext>()); // Recreate DB with losing data, if structure of my database was changed.
        }

        public DbSet<BookProperties>   Books   { get; set; }
        public DbSet<ReaderProperties> Readers { get; set; }
    }
}
