using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using BookLibrary.Models;
using BusinessLogic;

namespace BookLibrary
{
    public partial class MainForm : Form
    {
        Management management;

        DataGridView dataGridViewBooks;
        DataGridView dataGridViewReaders;

        public MainForm()
        {
            InitializeComponent();

            management = new Management();

            dataGridViewBooks = CreateNewDataGridViewTab("Books");
            AddColumns(dataGridViewBooks, typeof(BookProperties).GetProperties());
            AddRowsToDgvBooks();

            dataGridViewReaders = CreateNewDataGridViewTab("Readers");
            AddColumns(dataGridViewReaders, typeof(ReaderProperties).GetProperties());
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

            management.SetBookValue(bookId, columnName, value);
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

        private DataGridView CreateNewDataGridViewTab(string TabName)
        {
            TabPage tp = new TabPage(TabName);
            tp.Name = TabName;

            tabControl.TabPages.Add(tp);

            DataGridView dataGridView = new DataGridView()
            {
                Name = TabName,
                Dock = DockStyle.Fill,
            };

            tabControl.TabPages[TabName].Controls.Add(dataGridView);

            return dataGridView;
        }

        private void AddColumns(DataGridView dgv, PropertyInfo[] properties)
        {
            foreach(var p in properties)
            {
                dgv.Columns.Add(p.Name, p.Name);
            }
        }

        private void AddRowsToDgvBooks()
        {
            foreach (var item in management.GetAllBooks())
            {
                var properties = item.GetType().GetProperties();
                var row = new DataGridViewRow();

                foreach(var p in properties)
                {
                    var cell = new DataGridViewTextBoxCell();
                    cell.Value = p.GetValue(item);
                    row.Cells.Add(cell);
                }
                dataGridViewBooks.Rows.Add(row);
            }
        }
    }
}
