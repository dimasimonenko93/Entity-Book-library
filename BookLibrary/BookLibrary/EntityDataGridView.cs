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

            AddColumns(repository.properties);
            AddRows(repository.GetAll());

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

                int countOfCell = 0;
                foreach (var p in properties)
                {
                    Rows[countOfRows].Cells[countOfCell].Value = p.GetValue(item);
                    countOfCell++;
                }
                countOfRows++;
            }
        }

        public void FindAll(string text)
        {
            if(string.IsNullOrWhiteSpace(text))
            {
                Rows.Clear();
                AddRows(repository.GetAll());
            }
            else
            {
                Rows.Clear();

                var list = new List<object>();

                foreach(var item in repository.GetAll())
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
                        repository.Delete(Convert.ToInt32(rows.Cells[0].Value));
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
                CurrentRow.Cells[0].Value = repository.Create();
            }
        }

        private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int Id = Convert.ToInt32(this[0, e.RowIndex].Value);
            string columnName = Columns[e.ColumnIndex].Name;
            var cellValue = CurrentCell.Value;
            //var cellValue = Convert.ToInt32(currentTab.dataGridView.CurrentCell.Value); // boxing/unboxing error. Type of output value must be type of input value

            repository.SetValue(Id, columnName, cellValue);
        }
    }
}
