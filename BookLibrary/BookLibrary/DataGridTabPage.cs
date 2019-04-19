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
    public class DataGridTabPage : TabPage
    {
        public DataGridView dataGridView;

        public List<IItemProperties> currentList;

        public delegate int BeginEditHandler();
        public delegate void EndEditHandler(int Id, string columnName, object cellValue);

        public BeginEditHandler ReturnNewObjectIdFromDB;
        public EndEditHandler SetValue;

        public DataGridTabPage(string text, PropertyInfo[] properties, List<IItemProperties> currentList) : base(text)
        {
            Name = text;
            this.currentList = currentList;

            dataGridView = new DataGridView();
            dataGridView.Name = text;
            dataGridView.Dock = DockStyle.Fill;

            AddColumns(properties);
            AddRows(currentList);
        }

        public void AddColumns(PropertyInfo[] properties)
        {
            foreach (var p in properties)
            {
                dataGridView.Columns.Add(p.Name, p.Name);
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
                dataGridView.Rows.Add(row);
            }
        }
    }
}
