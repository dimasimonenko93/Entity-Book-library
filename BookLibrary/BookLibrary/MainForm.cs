﻿using System;
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

        DataGridView tempDataGridView;

        DataGridView dataGridViewBooks;
        DataGridView dataGridViewReaders;

        delegate int BeginEdit();
        delegate void EndEdit(int Id, string columnName, object cellValue);

        Action AddRowsDelegate;
        BeginEdit ReturnNewObjectIdFromDB;
        EndEdit SetValue;

        public MainForm()
        {
            InitializeComponent();

            management = new Management();

            dataGridViewBooks = CreateNewDataGridViewTab("Books", management.GetAllBooks());

            dataGridViewReaders = CreateNewDataGridViewTab("Readers", management.GetAllReaders());

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
                    tempDataGridView.Rows.Clear();
                    AddRowsDelegate();
                }
                else
                {
                    for(int i = 0; i < tempDataGridView.RowCount - 1; i++)
                    {
                        bool IsRowContains = false;
                        for(int j = 0; j < tempDataGridView.ColumnCount; j++)
                        {
                            if(tempDataGridView.Rows[i].Cells[j].Value != null)
                            {
                                if(tempDataGridView.Rows[i].Cells[j].Value.ToString().Contains(tbSearch.Text))
                                {
                                    IsRowContains = true;
                                    break;
                                }
                            }
                        }

                        if(!IsRowContains)
                        {
                            DataGridViewRow dgvDelRow = tempDataGridView.Rows[i];
                            tempDataGridView.Rows.Remove(dgvDelRow);
                            i--;
                        }
                    }
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
            if(tempDataGridView.SelectedRows.Count > 0)
            {
                foreach(DataGridViewRow rows in tempDataGridView.SelectedRows)
                {
                    management.DeleteBook(Convert.ToInt32(rows.Cells[0].Value));
                    try
                    {
                        tempDataGridView.Rows.Remove(rows);
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
            foreach (T item in getAll)
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
                tempDataGridView = dataGridViewBooks;

                ReturnNewObjectIdFromDB = () =>
                {
                    var book = new BookProperties();
                    management.CreateBook(book);
                    return book.Id;
                };

                SetValue = management.SetBookValue;
                AddRowsDelegate = () => AddRows(tempDataGridView, management.GetAllBooks());
            }
            else if(tabControl.SelectedTab.Name == dataGridViewReaders.Name)
            {
                tempDataGridView = dataGridViewReaders;

                ReturnNewObjectIdFromDB = () =>
                {
                    var reader = new ReaderProperties();
                    management.CreateReader(reader);
                    return reader.Id;
                };

                SetValue = management.SetReaderValue;
                AddRowsDelegate = () => AddRows(tempDataGridView,management.GetAllReaders());
            }
        }
    }
}
