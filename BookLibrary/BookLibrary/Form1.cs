using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic;

namespace BookLibrary
{
    public partial class Form1 : Form
    {
        DatabaseManagement databaseManagement;

        public Form1()
        {
            InitializeComponent();

            databaseManagement = new DatabaseManagement();

            dataGridViewBooks.DataSource = databaseManagement.DataGridViewBooks();

            dataGridViewReaders.DataSource = databaseManagement.DataGridViewReaders();

        }
    }
}
