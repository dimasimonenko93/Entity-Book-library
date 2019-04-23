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

        EntityDataGridView currentDataGrid;
        EntityDataGridView dataGridBooks;
        EntityDataGridView dataGridReaders;


        public MainForm()
        {
            InitializeComponent();

            repository = new Repository();

            dataGridBooks = new EntityDataGridView("Books")
            {
                ReturnNewObjectIdFromDB = () => { var book = new BookProperties(); repository.CreateBook(book); return book.Id; },
                SetValue = repository.SetBookValue,
                currentList = repository.GetAllBooks().ToList<IItemProperties>()
            };
            dataGridBooks.AddColumns(typeof(BookProperties).GetProperties());
            dataGridBooks.AddRows(repository.GetAllBooks().ToList<IItemProperties>());
            AddTabPage(dataGridBooks);

            currentDataGrid = dataGridBooks;

            dataGridReaders = new EntityDataGridView("Readers")
            {
                ReturnNewObjectIdFromDB = () => { var reader = new ReaderProperties(); repository.CreateReader(reader); return reader.Id; },
                SetValue = repository.SetReaderValue,
                currentList = repository.GetAllReaders().ToList<IItemProperties>()
            };
            dataGridReaders.AddColumns(typeof(ReaderProperties).GetProperties());
            dataGridReaders.AddRows(repository.GetAllReaders().ToList<IItemProperties>());
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
                if(string.IsNullOrWhiteSpace(tbSearch.Text))
                {
                    currentDataGrid.Rows.Clear();
                    currentDataGrid.AddRows(currentDataGrid.currentList);
                }
                else
                {
                    currentDataGrid.Rows.Clear();

                    var list = new List<IItemProperties>();

                    foreach (var item in currentDataGrid.currentList)
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
                    currentDataGrid.AddRows(list);
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if(currentDataGrid.SelectedRows.Count > 0)
            {
                foreach(DataGridViewRow rows in currentDataGrid.SelectedRows)
                {
                    repository.DeleteBook(Convert.ToInt32(rows.Cells[0].Value));
                    try
                    {
                        currentDataGrid.Rows.Remove(rows);
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
