using BookStore.Model.Generated;
using BookStore.Services.Services;
using BookStote.Helpers;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BookStore
{
    public partial class AuthorDetail : Form
    {
        #region Global Viarables
        private readonly AuthorService _authorService;
        private Author _author;
        string _orgFileName;
        #endregion

        #region Constructors

        public AuthorDetail()
        {
            InitializeComponent();
        }

        public AuthorDetail(User user, Author author, AuthorService authorService)
        {
            InitializeComponent();

            _author = author;
            _authorService = authorService;
            _orgFileName = string.Empty;

            if (author != null && author.Id > 0)
            {
                this.btnSave.Text = BookStoreConstants.BUTTON_TEXT_UPDATE;
                _author = author;
                txtTitle.Text = author.Title;
                rtbDescription.Text = author.Description;

                // display cover photo
                if (!string.IsNullOrEmpty(author.Cover) && File.Exists(author.Cover.GetFullPath(BookStoreConstants.AUTHOR_DIR_PATH)))
                {
                    picCover.Image = Image.FromFile(author.Cover.GetFullPath(BookStoreConstants.AUTHOR_DIR_PATH));
                }

                // check user role
                if (user.Role.RoleType != BookStoreConstants.ADMIN_ROLE_TYPE)
                {
                    btnSave.Location = btnDelete.Location;
                    btnDelete.Visible = false;
                }
            }

            else
            {
                // setting for insert mode
                btnSave.Text = BookStoreConstants.BUTTON_TEXT_ADD;
                btnSave.Location = btnDelete.Location;
                btnDelete.Visible = false;
            }
        }
        #endregion

        #region Events
        private void btnSave_Click(object sender, EventArgs e)
        {
            // validate before save data
            if (this.ValidateChildren(ValidationConstraints.Enabled))
            {
                // for update mode
                if (_author != null && _author.Id > 0)
                {
                    _author.LastUpdateTime = DateTime.Now;
                }
                else
                {
                    _author = new Author { CreateTime = DateTime.Now };

                }

                // save cover photo
                if (!string.IsNullOrEmpty(_orgFileName))
                {
                    var filePath = $"{Guid.NewGuid()}{Path.GetExtension(_orgFileName).ToLower()}";
                    if (FileHelpers.TryCopyFile(_orgFileName, filePath.GetFullPath(BookStoreConstants.AUTHOR_DIR_PATH)))
                    {
                        _author.Cover = filePath;
                    }
                }

                _author.Title = txtTitle.Text;
                _author.Description = rtbDescription.Text;

                _authorService.Upsert(_author);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(BookStoreConstants.MSG_CONFIRM_DELETE, BookStoreConstants.CONFIRM_DIALOG_NAME, MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (_author.Books != null && _author.Books.Count > 0)
                    {
                        var dr = MessageBox.Show(BookStoreConstants.MSG_AUTHOR_CONFIRM_DELETE, BookStoreConstants.CONFIRM_DIALOG_NAME, MessageBoxButtons.YesNo);
                        if (dr == DialogResult.No)
                        {
                            return;
                        }

                        foreach (Book book in _author.Books)
                        {
                            book.AuthorId = null;
                        }
                    }

                    _authorService.Delete(_author);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(BookStoreConstants.MSG_DB_ERROR + ex.Message);
                }

                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
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

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            // Browser and display image.
            OpenFileDialog fd = new OpenFileDialog { Filter = BookStoreConstants.IMAGE_FILETER };
            DialogResult dr = fd.ShowDialog();

            // get directory to save file
            if (dr == DialogResult.OK)
            {
                picCover.Image = Image.FromFile(fd.FileName);
                _orgFileName = fd.FileName;
            }
        }

        #endregion
    }
}
