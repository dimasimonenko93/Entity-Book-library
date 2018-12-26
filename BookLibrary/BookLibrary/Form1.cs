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

            using (BookContext db = new BookContext())
            {
                Book book1 = new Book { Name = "Mathematics" };
                Book book2 = new Book { Name = "Geography" };

                db.Books.Add(book1);
                db.Books.Add(book2);
                db.SaveChanges();
            }
        }
    }
}
