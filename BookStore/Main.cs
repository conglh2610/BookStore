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
            InitializeComponent();
            _user = user;
            (this.toolStrip.Items.Find("lblDisplayName", true)[0]).Text = $@"{user.FirstName} {user.LastName}";
        }
        #endregion

        #region Events

        private void tsCategory_Click(object sender, EventArgs e)
        {
            new CategoryManagement(_user).Show();
            this.Close();
        }

        private void tsLogout_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Close();
        }

        private void tsAuthor_Click(object sender, EventArgs e)
        {
            new AuthorManagement(_user).Show();
            this.Close();
        }

        private void tsBookManagement_Click(object sender, EventArgs e)
        {
            new BookManagement(_user).Show();
            this.Close();
        }

        #endregion

       
    }
}



