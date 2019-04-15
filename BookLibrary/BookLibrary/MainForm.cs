using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using BookLibrary.Models;
using BusinessLogic;

namespace BookLibrary
{
    public partial class MainForm : Form
    {
        Repository repository;

        DataGridView dataGridViewBooks;
        DataGridView dataGridViewReaders;

        DataGridView currentDataGridView;

        List<IItemProperties> currentList;

        delegate int BeginEdit();
        delegate void EndEditHandler(int Id, string columnName, object cellValue);

        BeginEdit ReturnNewObjectIdFromDB;
        EndEditHandler SetValue;

        public MainForm()
        {
            InitializeComponent();

            repository = new Repository();

            dataGridViewBooks = CreateNewDataGridViewTab("Books", repository.GetAllBooks());

            dataGridViewReaders = CreateNewDataGridViewTab("Readers", repository.GetAllReaders());

            SetDelegates();
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
                    currentDataGridView.Rows.Clear();
                    AddRows(currentDataGridView, currentList);
                }
                else
                {
                    currentDataGridView.Rows.Clear();

                    var list = new List<IItemProperties>();

                    foreach (var item in currentList)
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

                    AddRows(currentDataGridView, list);
                }
            }
        }

        private void dataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            var dataGrid = (DataGridView)sender;

            if(dataGrid.CurrentRow.Cells[0].Value == null)
            {
                //var book = new BookProperties();
                //management.CreateBook(book);
                //dataGrid.CurrentRow.Cells[0].Value = book.Id;
                dataGrid.CurrentRow.Cells[0].Value = ReturnNewObjectIdFromDB();
            }
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var dataGrid = (DataGridView)sender;

            int Id = Convert.ToInt32(dataGrid[0, e.RowIndex].Value);
            string columnName = dataGrid.Columns[e.ColumnIndex].Name;
            var cellValue = dataGrid.CurrentCell.Value;

            SetValue(Id, columnName, cellValue);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if(currentDataGridView.SelectedRows.Count > 0)
            {
                foreach(DataGridViewRow rows in currentDataGridView.SelectedRows)
                {
                    repository.DeleteBook(Convert.ToInt32(rows.Cells[0].Value));
                    try
                    {
                        currentDataGridView.Rows.Remove(rows);
                    }
                    catch
                    {

                    }
                }
            }
        }

        private DataGridView CreateNewDataGridViewTab<T>(string TabName, List<T> getAll)
        {
            TabPage tp = new TabPage(TabName);
            tp.Name = TabName;

            tabControl.TabPages.Add(tp);

            DataGridView dataGridView = new DataGridView()
            {
                Name = TabName,
                Dock = DockStyle.Fill,
            };
            dataGridView.CellBeginEdit += dataGridView_CellBeginEdit;
            dataGridView.CellEndEdit += dataGridView_CellEndEdit;
            AddColumns(dataGridView, typeof(T).GetProperties());
            AddRows(dataGridView, getAll);

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

        private void AddRows<T>(DataGridView dgv, List<T> getAll)
        {
            foreach(var item in getAll)
            {
                var properties = item.GetType().GetProperties();
                var row = new DataGridViewRow();

                foreach(var p in properties)
                {
                    var cell = new DataGridViewTextBoxCell();
                    cell.Value = p.GetValue(item);
                    row.Cells.Add(cell);
                }
                dgv.Rows.Add(row);
            }
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDelegates();
        }

        private void SetDelegates()
        {
            if(tabControl.SelectedTab.Name == dataGridViewBooks.Name)
            {
                currentDataGridView = dataGridViewBooks;

                ReturnNewObjectIdFromDB = () =>
                {
                    var book = new BookProperties();
                    repository.CreateBook(book);
                    return book.Id;
                };

                SetValue = repository.SetBookValue;
                currentList =  repository.GetAllBooks().ToList<IItemProperties>();
            }
            else if(tabControl.SelectedTab.Name == dataGridViewReaders.Name)
            {
                currentDataGridView = dataGridViewReaders;

                ReturnNewObjectIdFromDB = () =>
                {
                    var reader = new ReaderProperties();
                    repository.CreateReader(reader);
                    return reader.Id;
                };

                SetValue = repository.SetReaderValue;
                currentList = repository.GetAllReaders().ToList<IItemProperties>();
            }
        }
    }
}
