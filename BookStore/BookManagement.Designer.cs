namespace BookStore
{
    partial class BookManagement
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
            this.myPanel1 = new BookStore.CustomControls.MyPanel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxCategory = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxAuthor = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtTotalRecords = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.flowLayoutBooks = new System.Windows.Forms.FlowLayoutPanel();
            this.myPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // myPanel1
            // 
            this.myPanel1.Controls.Add(this.btnSearch);
            this.myPanel1.Controls.Add(this.txtYear);
            this.myPanel1.Controls.Add(this.label6);
            this.myPanel1.Controls.Add(this.cbxCategory);
            this.myPanel1.Controls.Add(this.label4);
            this.myPanel1.Controls.Add(this.cbxAuthor);
            this.myPanel1.Controls.Add(this.label3);
            this.myPanel1.Controls.Add(this.txtFilter);
            this.myPanel1.Controls.Add(this.label2);
            this.myPanel1.Location = new System.Drawing.Point(8, 82);
            this.myPanel1.Name = "myPanel1";
            this.myPanel1.Size = new System.Drawing.Size(887, 62);
            this.myPanel1.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(800, 19);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(244, 22);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(85, 20);
            this.txtYear.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(210, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Year:";
            // 
            // cbxCategory
            // 
            this.cbxCategory.FormattingEnabled = true;
            this.cbxCategory.Location = new System.Drawing.Point(616, 21);
            this.cbxCategory.Name = "cbxCategory";
            this.cbxCategory.Size = new System.Drawing.Size(156, 21);
            this.cbxCategory.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(558, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Category:";
            // 
            // cbxAuthor
            // 
            this.cbxAuthor.FormattingEnabled = true;
            this.cbxAuthor.Location = new System.Drawing.Point(393, 21);
            this.cbxAuthor.Name = "cbxAuthor";
            this.cbxAuthor.Size = new System.Drawing.Size(143, 21);
            this.cbxAuthor.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(351, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Author:";
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(45, 22);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(159, 20);
            this.txtFilter.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Filter:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search Books";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(820, 50);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add ";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtTotalRecords
            // 
            this.txtTotalRecords.Enabled = false;
            this.txtTotalRecords.Location = new System.Drawing.Point(759, 492);
            this.txtTotalRecords.Name = "txtTotalRecords";
            this.txtTotalRecords.Size = new System.Drawing.Size(87, 20);
            this.txtTotalRecords.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(710, 495);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Total:";
            // 
            // flowLayoutBooks
            // 
            this.flowLayoutBooks.AutoScroll = true;
            this.flowLayoutBooks.Location = new System.Drawing.Point(7, 159);
            this.flowLayoutBooks.Name = "flowLayoutBooks";
            this.flowLayoutBooks.Size = new System.Drawing.Size(888, 327);
            this.flowLayoutBooks.TabIndex = 11;
            // 
            // BookManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(904, 524);
            this.Controls.Add(this.flowLayoutBooks);
            this.Controls.Add(this.txtTotalRecords);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.myPanel1);
            this.Name = "BookManagement";
            this.Text = "Landing Page";
            this.Controls.SetChildIndex(this.myPanel1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtTotalRecords, 0);
            this.Controls.SetChildIndex(this.flowLayoutBooks, 0);
            this.myPanel1.ResumeLayout(false);
            this.myPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CustomControls.MyPanel myPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxAuthor;
        private System.Windows.Forms.ComboBox cbxCategory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTotalRecords;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutBooks;
    }
}
