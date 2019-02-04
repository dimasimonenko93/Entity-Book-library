using BookLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookLibrary
{
    public partial class FormTemplate : Form
    {
        public FormTemplate()
        {
            InitializeComponent();

            CreateLabels();
        }

        private void CreateLabels() // Test version
        {
            BookProperties b = new BookProperties();
            Point tempLocation = new Point(0, 0);

            PropertyInfo[] properties = b.GetType().GetProperties(); 

            //The GetProperties() method does not return properties in a particular order, 
            //such as alphabetical or declaration order. Your code must not depend on the 
            //order in which properties are returned, because that order varies.

            foreach (PropertyInfo propertyInfo in properties)
            {
                Label l = new Label();
                l.Text = propertyInfo.Name;
                l.Location = tempLocation;
                tempLocation.Y = tempLocation.Y + l.Size.Height;
                Controls.Add(l);
            }
        }
    }
}
