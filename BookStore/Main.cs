using BookStore.Model.Generated;
using System;
using System.Windows.Forms;
using BookStore.CustomControls;

namespace BookStore
{
    public partial class Main : Form
    {
        #region Global Variables
        private readonly User _user;
        #endregion

        #region Constructors

        public Main()
        {
            InitializeComponent();
        }

        public Main(User user)
        {
            _user = user;
            
            InitializeComponent();

            var userInfoControl = new UserInfo(user)
            {
                Anchor = AnchorStyles.Top |
                         AnchorStyles.Right
            };
            this.plnHeader.Controls.Add(userInfoControl, 1, 0);
        }
        #endregion

        #region Events
        private void tsmCategory_Click(object sender, EventArgs e)
        {
            new CategoryManagement(_user).Show();
            this.Close();
        }

        private void tsmAuthor_Click(object sender, EventArgs e)
        {
            new AuthorManagement(_user).Show();
            this.Close();
        }

        private void tsmBook_Click(object sender, EventArgs e)
        {
            new BookManagement(_user).Show();
            this.Close();
        }

        private void tsmExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}



