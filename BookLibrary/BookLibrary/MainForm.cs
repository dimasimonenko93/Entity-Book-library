using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using BookLibrary.Models;
using BusinessLogic;

namespace BookLibrary.WinForm
{
    public partial class MainForm : Form
    {
        Repository repository;

        DataGridTabPage currentTab;
        DataGridTabPage tabWithBooks;
        DataGridTabPage tabWithReaders;


        public MainForm()
        {
            InitializeComponent();

            repository = new Repository();

            tabWithBooks = new DataGridTabPage("Books", typeof(BookProperties).GetProperties(), repository.GetAllBooks().ToList<IItemProperties>());
            tabWithBooks.ReturnNewObjectIdFromDB = () => {var book = new BookProperties(); repository.CreateBook(book);  return book.Id; };
            tabWithBooks.SetValue = repository.SetBookValue;
            tabWithBooks.dataGridView.CellBeginEdit += dataGridView_CellBeginEdit;
            tabWithBooks.dataGridView.CellEndEdit += dataGridView_CellEndEdit;
            tabWithBooks.Enter += (object sender, EventArgs e) => { currentTab = tabWithBooks; };

            tabControl.TabPages.Add(tabWithBooks);
            tabControl.TabPages[tabWithBooks.Name].Controls.Add(tabWithBooks.dataGridView);

            tabWithReaders = new DataGridTabPage("Readers", typeof(ReaderProperties).GetProperties(), repository.GetAllReaders().ToList<IItemProperties>());
            tabWithReaders.ReturnNewObjectIdFromDB = () => { var reader = new ReaderProperties(); repository.CreateReader(reader); return reader.Id; };
            tabWithReaders.SetValue = repository.SetReaderValue;
            tabWithReaders.dataGridView.CellBeginEdit += dataGridView_CellBeginEdit;
            tabWithReaders.dataGridView.CellEndEdit += dataGridView_CellEndEdit;
            tabWithReaders.Enter += (object sender, EventArgs e) => { currentTab = tabWithReaders; };

            tabControl.TabPages.Add(tabWithReaders);
            tabControl.TabPages[tabWithReaders.Name].Controls.Add(tabWithReaders.dataGridView);
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
                if(string.IsNullOrWhiteSpace(tbSearch.Text))
                {
                    currentTab.dataGridView.Rows.Clear();
                    currentTab.AddRows(currentTab.currentList);
                }
                else
                {
                    currentTab.dataGridView.Rows.Clear();

                    var list = new List<IItemProperties>();

                    foreach (var item in currentTab.currentList)
                    {
                        var properties = item.GetType().GetProperties();

                        foreach(var p in properties)
                        {
                            if(Convert.ToString(p.GetValue(item)).Contains(tbSearch.Text)) // when tbSearch.Text = "s" - return all
                            {
                                list.Add(item);
                                break;
                            }
                        }
                    }

                    currentTab.AddRows(list);
                }
            }
        }

        private void dataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if(currentTab.dataGridView.CurrentRow.Cells[0].Value == null)
            {
                currentTab.dataGridView.CurrentRow.Cells[0].Value = currentTab.ReturnNewObjectIdFromDB();
            }
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int Id = Convert.ToInt32(currentTab.dataGridView[0, e.RowIndex].Value);
            string columnName = currentTab.dataGridView.Columns[e.ColumnIndex].Name;
            var cellValue = currentTab.dataGridView.CurrentCell.Value;
            //var cellValue = Convert.ToInt32(currentTab.dataGridView.CurrentCell.Value); // boxing/unboxing error. Type of output value must be type of input value

            currentTab.SetValue(Id, columnName, cellValue);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if(currentTab.dataGridView.SelectedRows.Count > 0)
            {
                foreach(DataGridViewRow rows in currentTab.dataGridView.SelectedRows)
                {
                    repository.DeleteBook(Convert.ToInt32(rows.Cells[0].Value));
                    try
                    {
                        currentTab.dataGridView.Rows.Remove(rows);
                    }
                    catch
                    {

                    }
                }
            }
        }
    }
}
