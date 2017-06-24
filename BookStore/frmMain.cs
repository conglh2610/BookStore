using BookStore.Model.Generated;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore
{
    public partial class frmMain : Form
    {
        private User _user;
        private BookStoreDB _db;
        private CustomControls.UserInfo userInfo;

        public frmMain(BookStoreDB db, User user)
        {
            _user = user;
            _db = db;
            InitializeComponent();
            this.userInfo = new CustomControls.UserInfo(user);
            this.userInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.plnHeader.Controls.Add(this.userInfo, 1, 0);

        }

        public frmMain()
        {
        }

        private void tsmCategory_Click(object sender, EventArgs e)
        {
            var categoryForm = new frmCategoryMngt(_db, _user);
            categoryForm.Show();
            this.Close();
        }

        private void tsmAuthor_Click(object sender, EventArgs e)
        {
            var authorForm = new frmAuthorMngt(_db, _user);
            authorForm.Show();
            this.Close();
        }

        private void tsmBook_Click(object sender, EventArgs e)
        {
            //var bookForm = new frmBookSearch(_user);
            //bookForm.Show();
            //this.Close();
        }

        private void tsmExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}



