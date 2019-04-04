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
        Management management;

        DataGridView currentDataGridView;

        DataGridView dataGridViewBooks;
        DataGridView dataGridViewReaders;

        delegate int BeginEdit();
        delegate void EndEdit(int Id, string columnName, object cellValue);
        delegate List<IItemProperties> GetAll();

        BeginEdit ReturnNewObjectIdFromDB;
        EndEdit SetValue;
        GetAll CurrentList;
        GetAll NewList = () => new List<IItemProperties>();

        public MainForm()
        {
            InitializeComponent();

            management = new Management();

            dataGridViewBooks = CreateNewDataGridViewTab("Books", management.GetAllBooks());
            AddRows(dataGridViewBooks, management.GetAllBooks().ToList<IItemProperties>());

            dataGridViewReaders = CreateNewDataGridViewTab("Readers", management.GetAllReaders());
            AddRows(dataGridViewReaders, management.GetAllReaders().ToList<IItemProperties>());

            SetDelegates();
        }

        private void tbSearch_MouseClick(object sender, MouseEventArgs e)
        {
            tbSearch.Clear();
            tbSearch.ForeColor = Color.Black;
        }

        private void tbSearch_KeyDown(object sender, KeyEventArgs e) // Search in current DGV, not in GetAll();
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(string.IsNullOrWhiteSpace(tbSearch.Text))
                {
                    currentDataGridView.Rows.Clear();
                    AddRows(currentDataGridView, CurrentList());
                }
                else
                {
                    currentDataGridView.Rows.Clear();

                    var list = NewList();

                    foreach(var item in CurrentList())
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

        private void dataGridViewBooks_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var dataGrid = (DataGridView)sender;

            int Id = Convert.ToInt32(dataGrid[0, e.RowIndex].Value);
            string columnName = dataGrid.Columns[e.ColumnIndex].Name;
            var cellValue = dataGrid.CurrentCell.Value;

            //management.SetBookValue(bookId, columnName, value);
            SetValue(Id, columnName, cellValue);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if(currentDataGridView.SelectedRows.Count > 0)
            {
                foreach(DataGridViewRow rows in currentDataGridView.SelectedRows)
                {
                    management.DeleteBook(Convert.ToInt32(rows.Cells[0].Value));
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
            dataGridView.CellEndEdit += dataGridViewBooks_CellEndEdit;
            AddColumns(dataGridView, typeof(T).GetProperties());
            //AddRows(dataGridView, getAll);

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

        private void AddRows(DataGridView dgv, List<IItemProperties> getAll)
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
                    management.CreateBook(book);
                    return book.Id;
                };

                SetValue = management.SetBookValue;
                CurrentList = () => management.GetAllBooks().ToList<IItemProperties>();
            }
            else if(tabControl.SelectedTab.Name == dataGridViewReaders.Name)
            {
                currentDataGridView = dataGridViewReaders;

                ReturnNewObjectIdFromDB = () =>
                {
                    var reader = new ReaderProperties();
                    management.CreateReader(reader);
                    return reader.Id;
                };

                SetValue = management.SetReaderValue;
                CurrentList = () => management.GetAllReaders().ToList<IItemProperties>();
            }
        }
    }
}
