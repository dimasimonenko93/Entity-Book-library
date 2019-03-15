using System;
using System.Drawing;
using System.Windows.Forms;
using BookLibrary.Models;
using BusinessLogic;

namespace BookLibrary
{
    public partial class MainForm : Form
    {
        Management management;

        public MainForm()
        {
            InitializeComponent();

            management = new Management();

            dataGridViewBooks.DataSource = management.GetAllBooks();
            dataGridViewReaders.DataSource = management.GetAllReaders();

        }

        private void tbSearchBooks_MouseClick(object sender, MouseEventArgs e)
        {
            tbSearchBooks.Clear();
            tbSearchBooks.ForeColor = Color.Black;
        }

        private void tbSearchBooks_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                try
                {

                }
                catch
                {
                    MessageBox.Show(this, "Books not found");
                }
            }
        }

        private void dataGridViewBooks_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if(e.RowIndex + 1 == management.GetAllBooks().Count)
            {
                BookProperties book = new BookProperties();
                management.CreateBook(book);

                dataGridViewBooks.DataSource = management.GetAllBooks();
                dataGridViewBooks.CurrentCell = dataGridViewBooks.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void dataGridViewBooks_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int bookId = Convert.ToInt32(dataGridViewBooks[0, e.RowIndex].Value);
            string columnName = dataGridViewBooks.Columns[e.ColumnIndex].Name;
            var value = dataGridViewBooks.CurrentCell.Value;

            //var b = management.GetBook(bookId);
            //b = management.SetBookValue(b, columnName, value);

            //management.EditBook(b);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if(dataGridViewBooks.SelectedRows.Count > 0)
            {
                foreach(DataGridViewRow rows in dataGridViewBooks.SelectedRows)
                {
                    management.DeleteBook(Convert.ToInt32(rows.Cells[0].Value));
                }
            }
            dataGridViewBooks.DataSource = management.GetAllBooks();
        }
    }
}
