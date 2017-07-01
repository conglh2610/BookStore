using BookStote.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookStore.Model.Generated;
using static BookStore.Deletgates;
using BookStore.Services.Services;

namespace BookStore
{
    public partial class Registry : Form
    {
        #region Global Variables
        private UserService _userService;
        private BookStoreDB _db;
        public UserResitryDelegate UserResitryCallback { get; internal set; }
        #endregion

        #region Contructors
        public Registry()
        {
            InitializeComponent();
        }

        public Registry(BookStoreDB db)
        {
            _db = db;
            _userService = new UserService(db);
            InitializeComponent();
        }

        #endregion

        #region Events
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // validate before save data
            if (this.ValidateChildren(ValidationConstraints.Enabled))
            {
                var user = new User();
                user.FirstName = txtFirstName.Text;
                user.LastName = txtLastName.Text;
                user.Email = txtEmail.Text;
                user.Password = txtPassword.Text.EncryptLoginPassword("SHA1");

                try
                {
                    user.RoleId = new RoleService(_db).GetRoleIdByRoleType(BookStoreConstants.USER_ROLE_TYPE);
                    if (user.RoleId < 1)
                    {
                        MessageBox.Show(BookStoreConstants.MSG_DB_ERROR);
                    }
                    else
                    {
                        var userByEmail = _userService.GetUserByEmail(txtEmail.Text);
                        if (userByEmail == null)
                        {
                            _userService.Upsert(user);
                        }
                        else
                        {
                            MessageBox.Show(BookStoreConstants.MSG_REGISTRY_DUPPLICATED);
                            return;
                        }

                    }
                }
                catch (Exception)
                {
                    MessageBox.Show(BookStoreConstants.MSG_DB_ERROR);
                    return;
                }

                DialogResult result = MessageBox.Show(BookStoreConstants.MSG_REGISTRY_SUCCESS, BookStoreConstants.CONFIRM_DIALOG_NAME, MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    UserResitryCallback(txtEmail.Text, txtPassword.Text);
                    this.Close();
                }

            }
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            TextBox objTextBox = (TextBox)sender;

            if (objTextBox.Text.Trim() == string.Empty)
            {
                errorProvider1.SetError(objTextBox, BookStoreConstants.MSG_REQUIRED_FIELD);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(objTextBox, null);
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {

            TextBox objTextBox = (TextBox)sender;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(objTextBox.Text);

            if (objTextBox.Text.Trim() == string.Empty)
            {
                errorProvider1.SetError(objTextBox, BookStoreConstants.MSG_REQUIRED_FIELD);
                e.Cancel = true;
            }
            else if (!match.Success)
            {
                errorProvider1.SetError(objTextBox, BookStoreConstants.MSG_EMAIL_INCORRECTED_FORMAT);
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
                errorProvider1.SetError(objTextBox, BookStoreConstants.MSG_REQUIRED_FIELD);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(objTextBox, null);
            }
        }

        private void txtPasswordConfirm_Validating(object sender, CancelEventArgs e)
        {
            TextBox objTextBox = (TextBox)sender;

            if (objTextBox.Text != txtPassword.Text)
            {
                errorProvider1.SetError(objTextBox, BookStoreConstants.MSG_PASSWORD_NOT_MATCH);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(objTextBox, null);
            }
        }
        #endregion
    }
}
