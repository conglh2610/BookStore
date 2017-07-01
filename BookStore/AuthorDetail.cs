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
        public Deletgates.AddItemDelegate AddUpdateItemCallback { get; internal set; }
        private readonly AuthorService _authorService;
        private Author _author;
        string _orgFileName;
        #endregion

        #region Constructors

        public AuthorDetail()
        {
            InitializeComponent();
        }

        public AuthorDetail(User user, Author author)
        {
            InitializeComponent();

            _author = author;
            _authorService = new AuthorService(new BookStoreDB());
            _orgFileName = string.Empty;

            if (author != null && author.Id > 0)
            {
                this.btnSave.Text = "Update";
                _author = author;
                txtTitle.Text = author.Title;
                rtbDescription.Text = author.Description;

                // display cover photo
                if (!string.IsNullOrEmpty(author.Cover))
                {
                    picCover.SizeMode = PictureBoxSizeMode.StretchImage;
                    picCover.Image = Image.FromFile(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())) + author.Cover);
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
                btnSave.Text = "Insert";
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
                    var filePath = $"{Path.GetExtension(_orgFileName).ToLower()}";
                    if (FileHelpers.TryCopyFile(_orgFileName, filePath.GetFullPath(BookStoreConstants.BOOK_DIR_PATH)))
                    {
                        _author.Cover = filePath;
                    }
                }

                _authorService.Upsert(_author);
            }

            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(BookStoreConstants.MSG_CONFIRM_DELETE, BookStoreConstants.CONFIRM_DIALOG_NAME, MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    _authorService.Delete(_author.Id);
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
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = BookStoreConstants.IMAGE_FILETER;
            DialogResult dr = fd.ShowDialog();

            // get directory to save file
            if (dr == DialogResult.OK)
            {
                picCover.Image = Image.FromFile(fd.FileName);
                _orgFileName = fd.FileName;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            AddUpdateItemCallback("");
        }
        #endregion
    }
}
