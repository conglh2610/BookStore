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
        #region Global Variables
        private User _user;
        private CustomControls.UserInfo userInfo;
        #endregion

        #region Constructors
        public frmMain(User user)
        {
            _user = user;
            InitializeComponent();
            this.userInfo = new CustomControls.UserInfo(user);
            this.userInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.plnHeader.Controls.Add(this.userInfo, 1, 0);
        }
        #endregion

        #region Events
        private void tsmCategory_Click(object sender, EventArgs e)
        {
            var categoryForm = new frmCategoryMngt(_user);
            categoryForm.Show();
            this.Close();
        }

        private void tsmAuthor_Click(object sender, EventArgs e)
        {
            var authorForm = new frmAuthorMngt(_user);
            authorForm.Show();
            this.Close();
        }

        private void tsmBook_Click(object sender, EventArgs e)
        {
            var bookForm = new frmBookMngt(_user);
            bookForm.Show();
            this.Close();
        }

        private void tsmExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}



