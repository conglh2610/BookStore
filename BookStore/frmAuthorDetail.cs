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
        private readonly AuthorService _authorService = null;
        private Author _updateAuthor = null;
        string _orgFileName = string.Empty;
        public frmAuthorDetail()
        {
            InitializeComponent();
        }
        public frmAuthorDetail(AuthorService authorService)
        {
            InitializeComponent();            
            _authorService = authorService;
            picCover.SizeMode = PictureBoxSizeMode.StretchImage;
            btnSave.Text = "Insert";
        }

        public frmAuthorDetail(AuthorService authorService, Author authorUpdate)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            _updateAuthor = authorUpdate;
            this.btnSave.Text = "Update";
            _authorService = authorService;
            txtTitle.Text = authorUpdate.Title;
            rtbDescription.Text = authorUpdate.Description;

            picCover.SizeMode = PictureBoxSizeMode.StretchImage;
            if (!string.IsNullOrEmpty(authorUpdate.Cover))
            {
                picCover.Image = Image.FromFile(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())) + authorUpdate.Cover);
            }
            
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            AddUpdateItemCallback("");
        }
        private void btnSave_Click(object sender, EventArgs e)
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
    }
}
