using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using BookLibrary.BL;
using BookLibrary.Models;

namespace BookLibrary.WinForm
{
    public partial class MainForm : Form
    {
        EntityDataGridView currentDataGrid;
        EntityDataGridView dataGridBooks;
        EntityDataGridView dataGridReaders;


        public MainForm()
        {
            InitializeComponent();

            dataGridBooks = new EntityDataGridView("Books", new BooksRepository(), typeof(BookProperties).GetProperties());
            AddTabPage(dataGridBooks);

            currentDataGrid = dataGridBooks;

            dataGridReaders = new EntityDataGridView("Readers", new ReadersRepository(), typeof(ReaderProperties).GetProperties());
            AddTabPage(dataGridReaders);
        }

        private void tbSearch_MouseClick(object sender, MouseEventArgs e)
        {
            tbSearch.Clear();
            tbSearch.ForeColor = Color.Black;
        }

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                currentDataGrid.FindAll(tbSearch.Text);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if(currentDataGrid.SelectedRows.Count > 0)
            {
                foreach(DataGridViewRow rows in currentDataGrid.SelectedRows)
                {
                    try
                    {
                        currentDataGrid.Rows.Remove(rows);
                        currentDataGrid.DeleteItem(Convert.ToInt32(rows.Cells[0].Value));
                    }
                    catch
                    {
                    }
                }
            }
        }

        private void AddTabPage(EntityDataGridView dataGridView)
        {
            TabPage tabPage = new TabPage(dataGridView.Name);
            tabControl.TabPages.Add(tabPage);
            tabControl.TabPages[tabControl.TabCount - 1].Controls.Add(dataGridView);
            tabPage.Enter += (object sender, EventArgs e) => { currentDataGrid = dataGridView; };
        }
    }
}
