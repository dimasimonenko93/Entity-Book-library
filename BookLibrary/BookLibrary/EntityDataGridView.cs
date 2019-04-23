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
        public List<IItemProperties> currentList;

        public Action<int> DeleteItem;
        public Func<int> ReturnNewObjectIdFromDB;
        public Action<int, string, object> SetValue;
        
        public EntityDataGridView(string Name, IRepository repository, PropertyInfo[] properties)
        {
            this.Name = Name;
            Dock = DockStyle.Fill;

            DeleteItem = (int id) => { repository.Delete(id); currentList = repository.GetAll(); };
            ReturnNewObjectIdFromDB = repository.Create;
            SetValue = repository.SetValue;
            currentList = repository.GetAll();

            AddColumns(properties);
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

        public void AddRows(List<IItemProperties> getAll)
        {
            foreach (var item in getAll)
            {
                var properties = item.GetType().GetProperties();
                var row = new DataGridViewRow();

                foreach (var p in properties)
                {
                    var cell = new DataGridViewTextBoxCell();
                    cell.Value = p.GetValue(item);
                    row.Cells.Add(cell);
                }
                Rows.Add(row);
            }
        }

        public void FindAll(string text)
        {
            if(string.IsNullOrWhiteSpace(text))
            {
                Rows.Clear();
                AddRows(currentList);
            }
            else
            {
                Rows.Clear();

                var list = new List<IItemProperties>();

                foreach(var item in currentList)
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

        private void dgv_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (CurrentRow.Cells[0].Value == null)
            {
                CurrentRow.Cells[0].Value = ReturnNewObjectIdFromDB();
            }
        }

        private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int Id = Convert.ToInt32(this[0, e.RowIndex].Value);
            string columnName = Columns[e.ColumnIndex].Name;
            var cellValue = CurrentCell.Value;
            //var cellValue = Convert.ToInt32(currentTab.dataGridView.CurrentCell.Value); // boxing/unboxing error. Type of output value must be type of input value

            SetValue(Id, columnName, cellValue);
        }
    }
}
