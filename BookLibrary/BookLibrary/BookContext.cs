using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BookLibrary
{
    class BookContext : DbContext
    {
        public BookContext() : base("DbConnection")
        {
        }

        public DbSet<Book>   Books   { get; set; }
        public DbSet<Reader> Readers { get; set; }
    }
}
