namespace BookStore
{
    partial class frmAuthorDetail
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rtbDesription = new System.Windows.Forms.RichTextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.picCover = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCover)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Description:";
            // 
            // rtbDesription
            // 
            this.rtbDesription.Location = new System.Drawing.Point(104, 70);
            this.rtbDesription.Name = "rtbDesription";
            this.rtbDesription.Size = new System.Drawing.Size(268, 92);
            this.rtbDesription.TabIndex = 2;
            this.rtbDesription.Text = "";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(297, 378);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(104, 33);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(268, 20);
            this.txtTitle.TabIndex = 1;
            this.txtTitle.Validating += new System.ComponentModel.CancelEventHandler(this.txtTitle_Validating);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // picCover
            // 
            this.picCover.Location = new System.Drawing.Point(104, 210);
            this.picCover.Name = "picCover";
            this.picCover.Size = new System.Drawing.Size(268, 146);
            this.picCover.TabIndex = 4;
            this.picCover.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cover:";
            // 
            // btnBrowser
            // 
            this.btnBrowser.Location = new System.Drawing.Point(104, 177);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(103, 21);
            this.btnBrowser.TabIndex = 6;
            this.btnBrowser.Text = "Image Browser";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // frmAuthorDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 413);
            this.Controls.Add(this.btnBrowser);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.picCover);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.rtbDesription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmAuthorDetail";
            this.Text = "Author Detail";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCover)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtbDesription;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.PictureBox picCover;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}