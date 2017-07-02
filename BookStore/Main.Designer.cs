namespace BookStore
{
    partial class Main
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
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsCategory = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsAuthor = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBookManagement = new System.Windows.Forms.ToolStripLabel();
            this.tsLogout = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.lblDisplayName = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsCategory,
            this.toolStripSeparator1,
            this.tsAuthor,
            this.toolStripSeparator2,
            this.tsBookManagement,
            this.tsLogout,
            this.toolStripSeparator3,
            this.lblDisplayName});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(785, 25);
            this.toolStrip.TabIndex = 10;
            this.toolStrip.Text = "toolStrip";
            // 
            // tsCategory
            // 
            this.tsCategory.Name = "tsCategory";
            this.tsCategory.Size = new System.Drawing.Size(129, 22);
            this.tsCategory.Text = "Category Management";
            this.tsCategory.Click += new System.EventHandler(this.tsCategory_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsAuthor
            // 
            this.tsAuthor.Name = "tsAuthor";
            this.tsAuthor.Size = new System.Drawing.Size(118, 22);
            this.tsAuthor.Text = "Author Management";
            this.tsAuthor.Click += new System.EventHandler(this.tsAuthor_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsBookManagement
            // 
            this.tsBookManagement.Name = "tsBookManagement";
            this.tsBookManagement.Size = new System.Drawing.Size(108, 22);
            this.tsBookManagement.Text = "Book Management";
            this.tsBookManagement.Click += new System.EventHandler(this.tsBookManagement_Click);
            // 
            // tsLogout
            // 
            this.tsLogout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsLogout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsLogout.Image = global::BookStore.Properties.Resources.logout_24;
            this.tsLogout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsLogout.Name = "tsLogout";
            this.tsLogout.Size = new System.Drawing.Size(23, 22);
            this.tsLogout.Text = "Logout";
            this.tsLogout.Click += new System.EventHandler(this.tsLogout_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // lblDisplayName
            // 
            this.lblDisplayName.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblDisplayName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDisplayName.Name = "lblDisplayName";
            this.lblDisplayName.Size = new System.Drawing.Size(102, 22);
            this.lblDisplayName.Text = "Display Name";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 302);
            this.Controls.Add(this.toolStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel tsCategory;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel tsAuthor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel tsBookManagement;
        private System.Windows.Forms.ToolStripLabel lblDisplayName;
        private System.Windows.Forms.ToolStripButton tsLogout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}