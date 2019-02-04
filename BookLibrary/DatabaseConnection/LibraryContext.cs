using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BookLibrary.Models;

namespace BookLibrary
{
    internal class LibraryContext : DbContext
    {
        public LibraryContext() : base("DbConnection")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<LibraryContext>()); // Recreate DB with losing data, if structure of my database was changed.
        }

        public DbSet<BookProperties>   Books   { get; set; }
        public DbSet<ReaderProperties> Readers { get; set; }
    }
}
