using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookLibrary
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            using (LibraryContext db = new LibraryContext())
            {
                Book book1 = new Book { Name = "Mathematics" };
                Book book2 = new Book { Name = "Geography" };

                db.Books.Add(book1);
                db.Books.Add(book2);
                db.Books.Add(book2);

                Reader reader1 = new Reader { Name = "Alex" };

                db.Readers.Add(reader1);
                db.Readers.Add(reader1);

                db.SaveChanges();
            }
        }
    }
}
