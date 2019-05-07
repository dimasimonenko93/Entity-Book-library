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

        public MainForm()
        {
            InitializeComponent();

            var dataGridBooks = new EntityDataGridView(new BooksRepository());
            AddTabPage("Books", dataGridBooks);

            currentDataGrid = dataGridBooks;

            var dataGridReaders = new EntityDataGridView(new ReadersRepository());
            AddTabPage("Readers", dataGridReaders);
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
            currentDataGrid.RemoveSelectedRows();
        }

        private void AddTabPage(string Name, EntityDataGridView dataGridView)
        {
            TabPage tabPage = new TabPage();
            tabControl.TabPages.Add(tabPage);
            tabControl.TabPages[tabControl.TabCount - 1].Name = Name;
            tabControl.TabPages[tabControl.TabCount - 1].Text = Name;
            tabControl.TabPages[tabControl.TabCount - 1].Controls.Add(dataGridView);
            tabPage.Enter += (object sender, EventArgs e) => { currentDataGrid = dataGridView; };
        }
    }
}
