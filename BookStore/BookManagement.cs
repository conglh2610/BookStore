using BookStore.CustomControls;
using BookStore.Model.Generated;
using BookStore.Services.Services;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BookStore
{
    public partial class BookManagement : Main
    {
        #region Global Variables
        readonly User _user;
        readonly BookStoreDB _db;
        BookService _bookService;
        #endregion

        #region Constructors
        public BookManagement(User user) : base(user)
        {
            InitializeComponent();
            var db = new BookStoreDB();
            _user = user;
            _db = db;
            _bookService = new BookService(db);
            // init services 
            var authorService = new AuthorService(db);
            var categoryService = new CategoryService(db);

            // create empty value
            var emptyAuthor = new Author();
            emptyAuthor.Id = 0;
            emptyAuthor.Title = "-- All Authors--";

            // get list from service
            var authorDataSource = authorService.Query();
            authorDataSource.Add(emptyAuthor);
            authorDataSource = authorDataSource.OrderBy(t => t.Title).ToList();

            // bind to datasource
            cbxAuthor.DataSource = authorDataSource;
            cbxAuthor.DisplayMember = "Title";
            cbxAuthor.ValueMember = "Id";
            cbxAuthor.SelectedValue = 0;

            // create empty value
            var emptyCategory = new Category();
            emptyCategory.Id = 0;
            emptyCategory.Title = "--All Categories--";

            // get list from service
            var categoryDataSource = categoryService.Query();
            categoryDataSource.Add(emptyCategory);
            categoryDataSource = categoryDataSource.OrderBy(t => t.Title).ToList();

            // bind to datasource
            cbxCategory.DataSource = categoryDataSource;
            cbxCategory.DisplayMember = "Title";
            cbxCategory.ValueMember = "Id";
            cbxCategory.SelectedValue = 0;

            SearchBook();

        }
        #endregion

        #region Events
        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var bookDetailDialog = new BookDetail(null, _user, _db))
            {
                DialogResult dr = bookDetailDialog.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    SearchBook();
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchBook();
        }
        #endregion

        #region Private Methods
        private void SearchBook()
        {
            var response = _bookService.SearchBook(txtFilter.Text, txtYear.Text, Convert.ToInt32(cbxAuthor.SelectedValue), Convert.ToInt32(cbxCategory.SelectedValue)).ToList();
            var totalRecords = response.Count();
            txtTotalRecords.Text = totalRecords.ToString();
            booksRepeater.Width = 860;
            booksRepeater.Controls.Clear();
            for (int i = 0; i < totalRecords; i++)
            {
                var bookItem = new BookItem(response[i].Id, _user, SearchBookCallBackFn);
                bookItem.Location = new Point((i % 5) * bookItem.Width, (i / 5) * bookItem.Height);
                booksRepeater.Controls.Add(bookItem);
            }
        }

        private void SearchBookCallBackFn()
        {
            _bookService = new BookService(new BookStoreDB());
            SearchBook();
        }

        #endregion
    }
}
