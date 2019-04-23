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

        public delegate int BeginEditHandler();
        public delegate void EndEditHandler(int Id, string columnName, object cellValue);

        public BeginEditHandler ReturnNewObjectIdFromDB;
        public EndEditHandler SetValue;

        public EntityDataGridView(string Name)
        {
            this.Name = Name;
            Dock = DockStyle.Fill;

            CellBeginEdit += dgv_CellBeginEdit;
            CellEndEdit += dgv_CellEndEdit;
        }

        public void AddColumns(PropertyInfo[] properties)
        {
            foreach (var p in properties)
            {
                Columns.Add(p.Name, p.Name);
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
