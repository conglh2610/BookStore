using BookStore.Model.Generated;
using BookStore.Services.Services;
using System;
using System.ComponentModel;
using System.Windows.Forms;

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

            var user = _userService.GetLogin(txtUserName.Text, txtPassword.Text);
            if (user != null)
            {
                lblErrorMessage.Text = String.Empty;
                var bookForm = new BookManagement(user);
                bookForm.Show();
                this.Hide();
            }

            else
            {
                lblErrorMessage.Text = "Your email or password is not correct.";
            }
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            TextBox objTextBox = (TextBox)sender;

            if (objTextBox.Text.Trim() == string.Empty)
            {
                errorProvider1.SetError(objTextBox, "Please enter the your email.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(objTextBox, null);
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            TextBox objTextBox = (TextBox)sender;

            if (objTextBox.Text.Trim() == string.Empty)
            {
                errorProvider1.SetError(objTextBox, "Please enter the your password.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(objTextBox, null);
            }
        }

        private void btnRegistry_Click(object sender, EventArgs e)
        {
            using (var registryForm = new Registry(_db))
            {
                registryForm.UserResitryCallback = UserResitryFn;
                registryForm.ShowDialog();
            }
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
