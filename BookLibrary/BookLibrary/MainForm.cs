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
        Management management;

        public MainForm()
        {
            InitializeComponent();

            management = new Management();

            dataGridViewBooks.DataSource = management.LoadDataGridViewBooks();

            dataGridViewReaders.DataSource = management.LoadDataGridViewReaders();
        }

        private void tbSearchBooks_Enter(object sender, EventArgs e)
        {
            tbSearchBooks.Clear();
            tbSearchBooks.ForeColor = Color.Black;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           var add = new FormTemplate();
           add.Text = tabControl.SelectedTab.Name;
           
           DialogResult result = add.ShowDialog(this);
           if (result == DialogResult.Cancel)
               return;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var edit = new FormTemplate();
            edit.Text = tabControl.SelectedTab.Name;

            DialogResult result = edit.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;
        }
    }
}
