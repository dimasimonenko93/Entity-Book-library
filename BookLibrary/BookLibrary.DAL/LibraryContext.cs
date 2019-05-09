using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.DAL
{
    class LibraryContext<T> : DbContext where T : class, new()
    {
        public LibraryContext() : base("DbConnection")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<LibraryContext<T>>()); // Recreate DB with losing data, if structure of my database was changed.
            //Database.SetInitializer(new DropCreateDatabaseAlways<LibraryContext<T>>()); // Recreate DB with losing data, if structure of my database was changed.
        }

        public DbSet<T> Items { get; set; }
    }
}
