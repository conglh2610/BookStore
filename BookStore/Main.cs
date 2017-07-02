using BookStore.Model.Generated;
using System;
using System.Windows.Forms;

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
            this.Close();
            new CategoryManagement(_user).Show();
        }

        private void tsLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            new Login().Show();
        }

        private void tsAuthor_Click(object sender, EventArgs e)
        {
            this.Close();
            new AuthorManagement(_user).Show();
        }

        private void tsBookManagement_Click(object sender, EventArgs e)
        {
            this.Close();
            new BookManagement(_user).Show();
        }

        #endregion

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                new Login().Show();
            }
        }
    }
}



