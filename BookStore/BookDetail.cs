using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookStore.Model.Generated;
using BookStore.Services.Services;
using System.IO;
using BookStore.Services.Repository;
using BookStote.Helpers;

namespace BookStore
{
    public partial class BookDetail : Form
    {
        #region Global Variables
        private readonly BookService _bookService;
        private Book _book;
        string _orgFileName = string.Empty;
        public Deletgates.AddItemDelegate AddUpdateItemCallback { get; internal set; }
        #endregion

        #region Constructors
        public BookDetail(Book book, User user)
        {
            InitializeComponent();
            var db = new BookStoreDB();
            // init services 
            var authorService = new AuthorService(db);
            var categoryService = new CategoryService(db);
            _bookService = new BookService(db);

            _book = book;

            // populate dropdownlists
            PopulateAuthors(authorService);
            PopulateCategories(categoryService);

            if (book != null)
            {
                txtTitle.Text = book.Title;
                rtbDescription.Text = book.Description;
                txtPublisher.Text = book.Publisher;
                txtYear.Text = book.Year.ToString();
                cbxAuthor.SelectedValue = book.AuthorId;
                cbxCategory.SelectedValue = book.CategoryId ?? 0;

                if (!string.IsNullOrEmpty(book.Cover))
                {
                    picCover.Image = Image.FromFile(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())) + book.Cover);
                }

                btnSave.Text = "Update";
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

        #endregion

        #region Events
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren(ValidationConstraints.Enabled))
            {
                if (_book != null && _book.Id > 0)
                {
                    _book = _bookService.GetById(_book.Id);
                    _book.LastUpdateTime = DateTime.Now;
                }

                else
                {
                    _book = new Book {CreateTime = DateTime.Now};
                }

                _book.Title = txtTitle.Text;
                _book.Description = rtbDescription.Text;
                _book.Publisher = txtPublisher.Text;
                _book.Year = Convert.ToInt32(txtYear.Text);
                _book.AuthorId = Convert.ToInt32(cbxAuthor.SelectedValue);

                _book.CategoryId = string.IsNullOrEmpty(cbxCategory.Text) ? (int?) null : Convert.ToInt32(cbxCategory.SelectedValue);

                if (!string.IsNullOrEmpty(_orgFileName))
                {
                    var filePath = $"{Path.GetExtension(_orgFileName).ToLower()}";
                    if (FileHelpers.TryCopyFile(_orgFileName, filePath.GetFullPath(BookStoreConstants.BOOK_DIR_PATH)))
                    {
                        _book.Cover = filePath;
                    }

                }
                _book.LastUpdateTime = DateTime.Now;
                _bookService.Upsert(_book);

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
                    _bookService.Delete(_book.Id);
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

        private void txtYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                   (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
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

        private void cbxAuthor_Validating(object sender, CancelEventArgs e)
        {
            ComboBox objCbx = (ComboBox)sender;

            if (Convert.ToInt32(objCbx.SelectedValue) == 0 || string.IsNullOrEmpty(objCbx.Text))
            {
                errorProvider1.SetError(objCbx, BookStoreConstants.MSG_REQUIRED_FIELD);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(objCbx, null);
            }
        }

        private void txtPublisher_Validating(object sender, CancelEventArgs e)
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

        private void txtYear_Validating(object sender, CancelEventArgs e)
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
        #endregion

        #region Private Methods


        private void PopulateAuthors(AuthorService authorService)
        {
 
            var authorsSource = authorService.Query();
            authorsSource.Add(new Author {Id = 0, Title = String.Empty});
            // get list from service and bind to datasource

            cbxAuthor.DataSource = authorsSource.OrderBy(t => t.Title).ToList();
            cbxAuthor.DisplayMember = "Title";
            cbxAuthor.ValueMember = "Id";
           
        }
        private void PopulateCategories(CategoryService categoryService)
        {

            var categoriesDataSource = categoryService.Query();
            categoriesDataSource.Add(new Category { Id = 0, Title = String.Empty });

            // get list from service and bind to datasource
            cbxCategory.DataSource = categoriesDataSource.OrderBy(t => t.Title).ToList();
            cbxCategory.DisplayMember = "Title";
            cbxCategory.ValueMember = "Id";

        }


        #endregion

    }
}
