namespace BookLibrary
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.Books = new System.Windows.Forms.TabPage();
            this.dataGridViewBooks = new System.Windows.Forms.DataGridView();
            this.Readers = new System.Windows.Forms.TabPage();
            this.dataGridViewReaders = new System.Windows.Forms.DataGridView();
            this.panelForButtons = new System.Windows.Forms.Panel();
            this.tbSearchBooks = new System.Windows.Forms.TextBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.Books.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooks)).BeginInit();
            this.Readers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReaders)).BeginInit();
            this.panelForButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.Books);
            this.tabControl.Controls.Add(this.Readers);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabControl.ItemSize = new System.Drawing.Size(42, 18);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1207, 471);
            this.tabControl.TabIndex = 0;
            // 
            // Books
            // 
            this.Books.Controls.Add(this.dataGridViewBooks);
            this.Books.Location = new System.Drawing.Point(4, 22);
            this.Books.Name = "Books";
            this.Books.Size = new System.Drawing.Size(1199, 445);
            this.Books.TabIndex = 0;
            this.Books.Text = "Books";
            this.Books.UseVisualStyleBackColor = true;
            // 
            // dataGridViewBooks
            // 
            this.dataGridViewBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewBooks.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewBooks.Name = "dataGridViewBooks";
            this.dataGridViewBooks.Size = new System.Drawing.Size(1199, 445);
            this.dataGridViewBooks.TabIndex = 0;
            this.dataGridViewBooks.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewBooks_CellBeginEdit);
            this.dataGridViewBooks.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBooks_CellEndEdit);
            // 
            // Readers
            // 
            this.Readers.Controls.Add(this.dataGridViewReaders);
            this.Readers.Location = new System.Drawing.Point(4, 22);
            this.Readers.Name = "Readers";
            this.Readers.Size = new System.Drawing.Size(1199, 445);
            this.Readers.TabIndex = 1;
            this.Readers.Text = "Readers";
            this.Readers.UseVisualStyleBackColor = true;
            // 
            // dataGridViewReaders
            // 
            this.dataGridViewReaders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReaders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewReaders.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewReaders.Name = "dataGridViewReaders";
            this.dataGridViewReaders.Size = new System.Drawing.Size(1199, 445);
            this.dataGridViewReaders.TabIndex = 1;
            // 
            // panelForButtons
            // 
            this.panelForButtons.Controls.Add(this.tbSearchBooks);
            this.panelForButtons.Controls.Add(this.btnRemove);
            this.panelForButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelForButtons.Location = new System.Drawing.Point(0, 499);
            this.panelForButtons.Name = "panelForButtons";
            this.panelForButtons.Size = new System.Drawing.Size(1207, 86);
            this.panelForButtons.TabIndex = 3;
            // 
            // tbSearchBooks
            // 
            this.tbSearchBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbSearchBooks.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbSearchBooks.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.tbSearchBooks.Location = new System.Drawing.Point(12, 37);
            this.tbSearchBooks.Name = "tbSearchBooks";
            this.tbSearchBooks.Size = new System.Drawing.Size(348, 29);
            this.tbSearchBooks.TabIndex = 3;
            this.tbSearchBooks.Text = "To search in books or in their properties...";
            this.tbSearchBooks.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tbSearchBooks_MouseClick);
            this.tbSearchBooks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSearchBooks_KeyDown);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Location = new System.Drawing.Point(1059, 28);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(136, 46);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 585);
            this.Controls.Add(this.panelForButtons);
            this.Controls.Add(this.tabControl);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "MainForm";
            this.Text = "Book Library";
            this.tabControl.ResumeLayout(false);
            this.Books.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooks)).EndInit();
            this.Readers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReaders)).EndInit();
            this.panelForButtons.ResumeLayout(false);
            this.panelForButtons.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Panel panelForButtons;
        private System.Windows.Forms.TextBox tbSearchBooks;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.TabPage Books;
        private System.Windows.Forms.DataGridView dataGridViewBooks;
        private System.Windows.Forms.TabPage Readers;
        private System.Windows.Forms.DataGridView dataGridViewReaders;
    }
}

