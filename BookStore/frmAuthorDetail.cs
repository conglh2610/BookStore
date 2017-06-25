using BookStore.Model.Generated;
using BookStore.Services.Services;
using BookStote.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BookStore.Deletgates;

namespace BookStore
{
    public partial class frmAuthorDetail : Form
    {

        public AddItemDelegate AddUpdateItemCallback { get; internal set; }
        private AuthorService _authorService = null;
        private BookStoreDB _db = null;
        private User _user = null;
        private Author _updateAuthor = null;
        string _orgFileName = string.Empty;

        public frmAuthorDetail(User user, Author authorUpdate)
        {
            InitializeComponent();
            _db = new BookStoreDB();
            _user = user;
            _authorService = new AuthorService(_db);
            if (authorUpdate != null && authorUpdate.Id > 0)
            {
                this.btnSave.Text = "Update";
                _updateAuthor = authorUpdate;
                txtTitle.Text = authorUpdate.Title;
                rtbDescription.Text = authorUpdate.Description;
                picCover.SizeMode = PictureBoxSizeMode.StretchImage;
                if (!string.IsNullOrEmpty(authorUpdate.Cover))
                {
                    picCover.Image = Image.FromFile(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())) + authorUpdate.Cover);
                }

                if (user.Role.RoleType != BookStoreConstants.ADMIN_ROLE_TYPE)
                {
                    btnSave.Location = btnDelete.Location;
                    btnDelete.Visible = false;
                }
            }

            else
            {
                btnSave.Text = "Insert";
                btnSave.Location = btnDelete.Location;
                btnDelete.Visible = false;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            AddUpdateItemCallback("");
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren(ValidationConstraints.Enabled))
            {
                if (_updateAuthor != null && _updateAuthor.Id > 0)
                {
                    _updateAuthor = _authorService.GetById(_updateAuthor.Id);
                    _updateAuthor.Title = txtTitle.Text;
                    _updateAuthor.Description = rtbDescription.Text;
                    if (!string.IsNullOrEmpty(_orgFileName))
                    {
                        string authorPath = Path.GetDirectoryName(BookStoreConstants.AUTHOR_DIR_PATH);
                        var filePath = String.Empty;
                        FileHelpers.TryCopyFile(_orgFileName, BookStoreConstants.AUTHOR_DIR_PATH, out filePath);
                        _updateAuthor.Cover = filePath;
                    }
                    _updateAuthor.LastUpdateTime = DateTime.Now;
                    _authorService.Update(_updateAuthor);
                }

                else
                {
                    var newAuthor = new Author();
                    newAuthor.Title = txtTitle.Text;
                    newAuthor.Description = rtbDescription.Text;
                    if (!string.IsNullOrEmpty(_orgFileName))
                    {
                        string authorPath = Path.GetDirectoryName(BookStoreConstants.AUTHOR_DIR_PATH);
                        var filePath = String.Empty;
                        FileHelpers.TryCopyFile(_orgFileName, BookStoreConstants.AUTHOR_DIR_PATH, out filePath);
                        newAuthor.Cover = filePath;
                    }
                    newAuthor.CreateTime = DateTime.Now;

                    _authorService.Insert(newAuthor);
                }

                this.Close();
            }
            
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(BookStoreConstants.MSG_CONFIRM_DELETE, BookStoreConstants.CONFIRM_DIALOG_NAME, MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    _authorService.Delete(_updateAuthor.Id);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(BookStoreConstants.MSG_DB_ERROR + ex.Message);
                }

                this.Close();
            }
        }
    }
}
