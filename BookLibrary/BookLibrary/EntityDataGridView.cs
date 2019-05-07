using BookLibrary.BL;
using BookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookLibrary.WinForm
{
    public class EntityDataGridView : DataGridView
    {
        private IRepository repository;

        public EntityDataGridView(IRepository repository)
        {
            this.repository = repository;
            Dock = DockStyle.Fill;

            AddColumns(repository.EntityProperties);
            AddRows(repository.GetAllItems());

            CellBeginEdit += dgv_CellBeginEdit;
            CellEndEdit += dgv_CellEndEdit;
        }

        public void AddColumns(PropertyInfo[] properties)
        {
            foreach (var p in properties)
            {
                DataGridViewColumn column;
                if(p.PropertyType == typeof(bool))
                {
                    column = new DataGridViewCheckBoxColumn();
                    column.CellTemplate = new DataGridViewCheckBoxCell();
                }
                else
                {
                    column = new DataGridViewTextBoxColumn();
                    column.CellTemplate = new DataGridViewTextBoxCell();
                }
                column.Name = p.Name;
                column.HeaderText = p.Name;
                Columns.Add(column);
            }
        }

        public void AddRows(List<object> repositoryEntities)
        {
            int countOfRows = 0;

            foreach (var item in repositoryEntities)
            {
                var row = new DataGridViewRow();
                Rows.Add(row);

                var properties = item.GetType().GetProperties();

                foreach (var p in properties)
                {
                    Rows[countOfRows].Cells[p.Name].Value = p.GetValue(item);
                }
                countOfRows++;
            }
        }

        public void FindAll(string text)
        {
            if(string.IsNullOrWhiteSpace(text))
            {
                Rows.Clear();
                AddRows(repository.GetAllItems());
            }
            else
            {
                Rows.Clear();

                var list = new List<object>();

                foreach(var item in repository.GetAllItems())
                {
                    var properties = item.GetType().GetProperties();

                    foreach(var p in properties)
                    {
                        if(Convert.ToString(p.GetValue(item)).Contains(text)) // when tbSearch.Text = "s" - return all
                        {
                            list.Add(item);
                            break;
                        }
                    }
                }
                AddRows(list);
            }
        }

        public void RemoveSelectedRows()
        {
            if (SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow rows in SelectedRows)
                {
                    try
                    {
                        Rows.Remove(rows);
                        repository.DeleteItem(Convert.ToInt32(rows.Cells[0].Value));
                    }
                    catch
                    {
                    }
                }
            }
        }

        private void dgv_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (CurrentRow.Cells[0].Value == null)
            {
                CurrentRow.Cells[0].Value = repository.CreateItem();
            }
        }

        private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int Id = Convert.ToInt32(this[0, e.RowIndex].Value);
            string columnName = Columns[e.ColumnIndex].Name;
            var cellValue = CurrentCell.Value;
            //var cellValue = Convert.ToInt32(currentTab.dataGridView.CurrentCell.Value); // boxing/unboxing error. Type of output value must be type of input value

            repository.SetValueItem(Id, columnName, cellValue);
        }
    }
}
