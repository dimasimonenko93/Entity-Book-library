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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Books = new System.Windows.Forms.TabPage();
            this.dataGridViewBooks = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridViewReaders = new System.Windows.Forms.DataGridView();
            this.panelForButtons = new System.Windows.Forms.Panel();
            this.btnRemoveBook = new System.Windows.Forms.Button();
            this.btnOpenFormNewBook = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRemoveReader = new System.Windows.Forms.Button();
            this.btnOpenFormNewReader = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.Books.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooks)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReaders)).BeginInit();
            this.panelForButtons.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Books);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabControl1.ItemSize = new System.Drawing.Size(42, 18);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1199, 594);
            this.tabControl1.TabIndex = 0;
            // 
            // Books
            // 
            this.Books.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Books.Controls.Add(this.panelForButtons);
            this.Books.Controls.Add(this.dataGridViewBooks);
            this.Books.Location = new System.Drawing.Point(4, 22);
            this.Books.Name = "Books";
            this.Books.Padding = new System.Windows.Forms.Padding(3);
            this.Books.Size = new System.Drawing.Size(1191, 568);
            this.Books.TabIndex = 0;
            this.Books.Text = "Books";
            // 
            // dataGridViewBooks
            // 
            this.dataGridViewBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBooks.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewBooks.Name = "dataGridViewBooks";
            this.dataGridViewBooks.Size = new System.Drawing.Size(1191, 471);
            this.dataGridViewBooks.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.dataGridViewReaders);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1191, 568);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Readers";
            // 
            // dataGridViewReaders
            // 
            this.dataGridViewReaders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewReaders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReaders.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewReaders.Name = "dataGridViewReaders";
            this.dataGridViewReaders.Size = new System.Drawing.Size(1191, 471);
            this.dataGridViewReaders.TabIndex = 0;
            // 
            // panelForButtons
            // 
            this.panelForButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelForButtons.Controls.Add(this.btnRemoveBook);
            this.panelForButtons.Controls.Add(this.btnOpenFormNewBook);
            this.panelForButtons.Location = new System.Drawing.Point(-4, 477);
            this.panelForButtons.Name = "panelForButtons";
            this.panelForButtons.Size = new System.Drawing.Size(1199, 95);
            this.panelForButtons.TabIndex = 2;
            // 
            // btnRemoveBook
            // 
            this.btnRemoveBook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveBook.Location = new System.Drawing.Point(1051, 37);
            this.btnRemoveBook.Name = "btnRemoveBook";
            this.btnRemoveBook.Size = new System.Drawing.Size(136, 46);
            this.btnRemoveBook.TabIndex = 1;
            this.btnRemoveBook.Text = "Remove book";
            this.btnRemoveBook.UseVisualStyleBackColor = true;
            // 
            // btnOpenFormNewBook
            // 
            this.btnOpenFormNewBook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFormNewBook.Location = new System.Drawing.Point(909, 37);
            this.btnOpenFormNewBook.Name = "btnOpenFormNewBook";
            this.btnOpenFormNewBook.Size = new System.Drawing.Size(136, 46);
            this.btnOpenFormNewBook.TabIndex = 0;
            this.btnOpenFormNewBook.Text = "Add new book";
            this.btnOpenFormNewBook.UseVisualStyleBackColor = true;
            this.btnOpenFormNewBook.Click += new System.EventHandler(this.btnOpenFormNewBook_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnRemoveReader);
            this.panel1.Controls.Add(this.btnOpenFormNewReader);
            this.panel1.Location = new System.Drawing.Point(-4, 477);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1199, 95);
            this.panel1.TabIndex = 3;
            // 
            // btnRemoveReader
            // 
            this.btnRemoveReader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveReader.Location = new System.Drawing.Point(1051, 37);
            this.btnRemoveReader.Name = "btnRemoveReader";
            this.btnRemoveReader.Size = new System.Drawing.Size(136, 46);
            this.btnRemoveReader.TabIndex = 1;
            this.btnRemoveReader.Text = "Remove reader";
            this.btnRemoveReader.UseVisualStyleBackColor = true;
            // 
            // btnOpenFormNewReader
            // 
            this.btnOpenFormNewReader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFormNewReader.Location = new System.Drawing.Point(909, 37);
            this.btnOpenFormNewReader.Name = "btnOpenFormNewReader";
            this.btnOpenFormNewReader.Size = new System.Drawing.Size(136, 46);
            this.btnOpenFormNewReader.TabIndex = 0;
            this.btnOpenFormNewReader.Text = "Add new reader";
            this.btnOpenFormNewReader.UseVisualStyleBackColor = true;
            this.btnOpenFormNewReader.Click += new System.EventHandler(this.btnOpenFormNewReader_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 594);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "Book Library";
            this.tabControl1.ResumeLayout(false);
            this.Books.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooks)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReaders)).EndInit();
            this.panelForButtons.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Books;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridViewBooks;
        private System.Windows.Forms.DataGridView dataGridViewReaders;
        private System.Windows.Forms.Panel panelForButtons;
        private System.Windows.Forms.Button btnRemoveBook;
        private System.Windows.Forms.Button btnOpenFormNewBook;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRemoveReader;
        private System.Windows.Forms.Button btnOpenFormNewReader;
    }
}

