using BookStote.Helpers;
using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BookStore.Model.Generated;
using static BookStore.Deletgates;
using BookStore.Services.Services;

namespace BookStore
{
    public partial class Registry : Form
    {
        #region Global Variables
        private readonly UserService _userService;
        private readonly BookStoreDB _db;
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
            if (this.OnValidating())
            {
                var user = new User
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Email = txtEmail.Text,
                    Password = txtPassword.Text.EncryptLoginPassword("SHA1")
                };

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

        private bool OnValidating()
        {
            // Validate First Name
            if (String.IsNullOrEmpty(txtFirstName.Text.Trim()))
            {
                errorProvider1.SetError(txtFirstName, BookStoreConstants.MSG_REQUIRED_FIELD);
                return false;
            }
            errorProvider1.SetError(txtFirstName, null);

            // Validate Email
            if (String.IsNullOrEmpty(txtEmail.Text.Trim()))
            {
                errorProvider1.SetError(txtEmail, BookStoreConstants.MSG_REQUIRED_FIELD);
                return false;
            }

            // Validate Email Format
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(txtEmail.Text);

            if (!match.Success)
            {
                errorProvider1.SetError(txtEmail, BookStoreConstants.MSG_EMAIL_INCORRECTED_FORMAT);
                return false;
            }
            errorProvider1.SetError(txtEmail, null);

            // Validate Password
            if (String.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                errorProvider1.SetError(txtPassword, BookStoreConstants.MSG_REQUIRED_FIELD);
                return false;
            }
            errorProvider1.SetError(txtPassword, null);

            // Validate Password Confirm
            if (txtPassword.Text != txtPasswordConfirm.Text )
            {
                errorProvider1.SetError(txtPasswordConfirm, BookStoreConstants.MSG_PASSWORD_NOT_MATCH);
                return false;
            }
            errorProvider1.SetError(txtPasswordConfirm, null);

            return true;
        }
        
        #endregion
    }
}
