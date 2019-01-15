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
    public partial class MainForm : Form
    {
        Management databaseManagement;

        public MainForm()
        {
            InitializeComponent();

            databaseManagement = new Management();

            dataGridViewBooks.DataSource = databaseManagement.LoadDataGridViewBooks();

            dataGridViewReaders.DataSource = databaseManagement.LoadDataGridViewReaders();
        }

        private void btnOpenFormNewBook_Click(object sender, EventArgs e)
        {
            AddNewBook addNewBook = new AddNewBook();
            addNewBook.ShowDialog(this);
        }

        private void btnOpenFormNewReader_Click(object sender, EventArgs e)
        {
            AddNewReader addNewReader = new AddNewReader();
            addNewReader.ShowDialog(this);
        }
    }
}
