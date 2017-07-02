using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BookStore.Model.Generated;
using BookStore.Services.Services;
using System.IO;
using BookStote.Helpers;

namespace BookStore
{
    public partial class BookDetail : Form
    {
        #region Global Variables
        private readonly BookService _bookService;
        private Book _book;
        private string _orgFileName = string.Empty;
        #endregion

        #region Constructors
        public BookDetail(Book book, User user, BookStoreDB db)
        {
            InitializeComponent();
            // init services 
            var authorService = new AuthorService(db);
            var categoryService = new CategoryService(db);
            _bookService = new BookService(db);
            _book = book;

            // populate dropdownlists
            PopulateAuthors(authorService);
            PopulateCategories(categoryService);

            // binding Book
            PopulateBook(book, user);

        }
        

        #endregion

        #region Events
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (OnValidating())
            {
                if (_book != null && _book.Id > 0)
                {
                    _book = _bookService.GetById(_book.Id);
                    _book.LastUpdateTime = DateTime.Now;
                }

                else
                {
                    _book = new Book { CreateTime = DateTime.Now };
                }

                _book.Title = txtTitle.Text;
                _book.Description = rtbDescription.Text;
                _book.Publisher = txtPublisher.Text;
                _book.Year = Convert.ToInt32(txtYear.Text);
                _book.AuthorId = Convert.ToInt32(cbxAuthor.SelectedValue);

                _book.CategoryId = string.IsNullOrEmpty(cbxCategory.Text) ? (int?)null : Convert.ToInt32(cbxCategory.SelectedValue);

                if (!string.IsNullOrEmpty(_orgFileName))
                {
                    var filePath = $"{Guid.NewGuid()}{Path.GetExtension(_orgFileName).ToLower()}";
                    if (FileHelpers.TryCopyFile(_orgFileName, filePath.GetFullPath(BookStoreConstants.BOOK_DIR_PATH)))
                    {
                        _book.Cover = filePath;
                    }

                }
                _book.LastUpdateTime = DateTime.Now;
                _bookService.Upsert(_book);
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
                    _bookService.Delete(_book);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(BookStoreConstants.MSG_DB_ERROR + ex.Message);
                }

                this.DialogResult = DialogResult.OK;
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
            using (OpenFileDialog fd = new OpenFileDialog())
            {
                fd.Filter = BookStoreConstants.IMAGE_FILETER;
                DialogResult dr = fd.ShowDialog();

                // get directory to save file
                if (dr == DialogResult.OK)
                {
                    picCover.Image = Image.FromFile(fd.FileName);
                    _orgFileName = fd.FileName;
                }
            }

        }

        #endregion

        #region Private Methods


        private void PopulateAuthors(AuthorService authorService)
        {

            var authorsSource = authorService.Query();
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

        private void PopulateBook(Book book, User user)
        {
            if (book != null)
            {
                txtTitle.Text = book.Title;
                rtbDescription.Text = book.Description;
                txtPublisher.Text = book.Publisher;
                txtYear.Text = book.Year.ToString();
                cbxAuthor.SelectedValue = book.AuthorId ?? 0;
                cbxCategory.SelectedValue = book.CategoryId ?? 0;

                if (!string.IsNullOrEmpty(book.Cover) && File.Exists(book.Cover.GetFullPath(BookStoreConstants.BOOK_DIR_PATH)))
                {
                    picCover.Image = Image.FromFile(book.Cover.GetFullPath(BookStoreConstants.BOOK_DIR_PATH));
                }

                btnSave.Text = BookStoreConstants.BUTTON_TEXT_UPDATE;
                if (user.Role.RoleType != BookStoreConstants.ADMIN_ROLE_TYPE)
                {
                    btnSave.Location = btnDelete.Location;
                    btnDelete.Visible = false;
                }
            }

            else
            {
                btnSave.Text = BookStoreConstants.BUTTON_TEXT_ADD;
                btnSave.Location = btnDelete.Location;
                btnDelete.Visible = false;
            }
        }

        private bool OnValidating()
        {
            // Validate Title
            if (String.IsNullOrEmpty(txtTitle.Text.Trim()))
            {
                errorProvider1.SetError(txtTitle, BookStoreConstants.MSG_REQUIRED_FIELD);
                return false;
            }
            errorProvider1.SetError(txtTitle, null);

            // Validate Author
            if (Convert.ToInt32(cbxAuthor.SelectedValue) == 0 || string.IsNullOrEmpty(cbxAuthor.Text))
            {
                errorProvider1.SetError(cbxAuthor, BookStoreConstants.MSG_REQUIRED_FIELD);
                return false;
            }
            errorProvider1.SetError(cbxAuthor, null);

            // Validate Year
            if (String.IsNullOrEmpty(txtYear.Text.Trim()))
            {
                errorProvider1.SetError(txtYear, BookStoreConstants.MSG_REQUIRED_FIELD);
                return false;
            }

            int validYear;
            if (!int.TryParse(txtYear.Text, out validYear))
            {
                errorProvider1.SetError(txtYear, BookStoreConstants.MSG_FORMAT_NUMBER);
                return false;
            }
            errorProvider1.SetError(txtYear, null);

            // Validate Publisher
            if (String.IsNullOrEmpty(txtPublisher.Text.Trim()))
            {
                errorProvider1.SetError(txtPublisher, BookStoreConstants.MSG_REQUIRED_FIELD);
                return false;
            }

            errorProvider1.SetError(txtPublisher, null);

            return true;
        }

        #endregion
    }
}
