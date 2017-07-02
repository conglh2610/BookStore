using BookStore.Model.Generated;
using BookStore.Services.Services;
using System;
using System.Windows.Forms;
using BookStote.Helpers;

namespace BookStore
{
    public partial class Login : Form
    {
        #region Global Viarables
        private readonly UserService _userService;
        private readonly BookStoreDB _db;
        #endregion

        #region Constructors
        public Login()
        {
            InitializeComponent();
            _db = new BookStoreDB();
            _userService = new UserService(_db);
        }
        #endregion

        #region Events
        /// <summary>
        /// User clicks to access the Book Store. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (OnValidating())
            {
                var user = _userService.GetLogin(txtUserName.Text, txtPassword.Text);
                if (user != null)
                {
                    lblErrorMessage.Text = String.Empty;
                    this.Hide();
                    new BookManagement(user).Show();
                }

                else
                {
                    lblErrorMessage.Text = BookStoreConstants.MSG_LOGIN_FAIL;
                }
            }
            
        }

        private bool OnValidating()
        {

            if (String.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                errorProvider1.SetError(txtUserName, BookStoreConstants.MSG_EMAIL_REQUIRED_FIELD);
                return false;
            }
            errorProvider1.SetError(txtUserName, null);

            if (String.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                errorProvider1.SetError(txtPassword, BookStoreConstants.MSG_PASSWORD_REQUIRED_FIELD);
                return false;
            }
            errorProvider1.SetError(txtPassword, null);

            return true;
        }


        private void btnRegistry_Click(object sender, EventArgs e)
        {
            using (var registryForm = new Registry(_db))
            {
                registryForm.UserResitryCallback = UserResitryFn;
                registryForm.ShowDialog();
            }
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region Private Methods
        private void UserResitryFn(string strEmail, string strPassword)
        {
            txtUserName.Text = strEmail;
            txtPassword.Text = strPassword;
            btnLogin.Focus();
        }

        #endregion
    }
}
