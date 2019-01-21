using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BookLibrary
{
    internal class LibraryContext : DbContext
    {
        public LibraryContext() : base("DbConnection")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<LibraryContext>()); // Recreate DB with losing data, if structure of my database was changed.
        }

        public DbSet<Book>   Books   { get; set; }
        public DbSet<Reader> Readers { get; set; }
    }
}
