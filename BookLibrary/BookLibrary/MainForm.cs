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

            dataGridViewBooks.DataSource = management.books;

            //dataGridViewReaders.DataSource = management.dataSet.Tables[1];
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           var add = new FormTemplate(tabControl.SelectedIndex);
           add.Text = tabControl.SelectedTab.Name;

           DialogResult result = add.ShowDialog(this);
           if (result == DialogResult.Cancel)
               return;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var edit = new FormTemplate(tabControl.SelectedIndex);
            edit.Text = tabControl.SelectedTab.Name;

            DialogResult result = edit.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;
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
                    dataGridViewBooks.DataSource = management.books.Select(tbSearchBooks.Text); // Is Name of Columns saved ?
                }
                catch
                {
                    MessageBox.Show(this, "Books not found");
                }
            }
        }
    }
}
