﻿namespace BookStore
{
    partial class CategoryManagement
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
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.gridViewCategory = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotalRecord = new System.Windows.Forms.TextBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCategory)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.Location = new System.Drawing.Point(24, 79);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(75, 23);
            this.btnAddCategory.TabIndex = 1;
            this.btnAddCategory.Text = "Add ";
            this.btnAddCategory.UseVisualStyleBackColor = true;
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(127, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Filter:";
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.gridViewCategory);
            this.pnlGrid.Location = new System.Drawing.Point(24, 108);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(528, 250);
            this.pnlGrid.TabIndex = 6;
            // 
            // gridViewCategory
            // 
            this.gridViewCategory.AllowUserToAddRows = false;
            this.gridViewCategory.AllowUserToDeleteRows = false;
            this.gridViewCategory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridViewCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridViewCategory.Location = new System.Drawing.Point(0, 0);
            this.gridViewCategory.Name = "gridViewCategory";
            this.gridViewCategory.ReadOnly = true;
            this.gridViewCategory.Size = new System.Drawing.Size(528, 250);
            this.gridViewCategory.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(416, 376);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Total:";
            // 
            // txtTotalRecord
            // 
            this.txtTotalRecord.Enabled = false;
            this.txtTotalRecord.Location = new System.Drawing.Point(465, 373);
            this.txtTotalRecord.Name = "txtTotalRecord";
            this.txtTotalRecord.Size = new System.Drawing.Size(87, 20);
            this.txtTotalRecord.TabIndex = 8;
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(166, 79);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(299, 20);
            this.txtFilter.TabIndex = 9;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // CategoryManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(557, 407);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.txtTotalRecord);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddCategory);
            this.Name = "CategoryManagement";
            this.Text = "Category Management";
            this.Controls.SetChildIndex(this.btnAddCategory, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.pnlGrid, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtTotalRecord, 0);
            this.Controls.SetChildIndex(this.txtFilter, 0);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCategory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotalRecord;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.DataGridView gridViewCategory;
    }
}
