using BookStore.CustomControls;
using BookStore.Model.Generated;
using BookStore.Services.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static BookStore.Deletgates;

namespace BookStore
{
    public partial class frmBookMngt : frmMain
    {
        BookService _bookService = null;
        BookStoreDB _db = null;
        public frmBookMngt()
        {
            InitializeComponent();
        }
        public frmBookMngt(BookStoreDB db, User user) : base(db, user)
        {
            InitializeComponent();
            _db = db;

            // init services 
            var authorService = new AuthorService(db);
            var categoryService = new CategoryService(db);
            _bookService = new BookService(db);

            // create empty value
            var emptyAuthor = new Author();
            emptyAuthor.Id = 0;
            emptyAuthor.Title = "-- All Authors--";

            // get list from service
            var authorDataSource = authorService.List().ToList();
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
            var categoryDataSource = categoryService.List().ToList();
            categoryDataSource.Add(emptyCategory);
            categoryDataSource = categoryDataSource.OrderBy(t => t.Title).ToList();

            // bind to datasource
            cbxCategory.DataSource = categoryDataSource;
            cbxCategory.DisplayMember = "Title";
            cbxCategory.ValueMember = "Id";
            cbxCategory.SelectedValue = 0;

            SearchBook();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var bookDetailDialog = new frmBookDetail(null);
            bookDetailDialog.AddUpdateItemCallback = new AddItemDelegate(this.AddUpdateItemCallbackFn);
            bookDetailDialog.ShowDialog();
        }

        private void AddUpdateItemCallbackFn(string strValue)
        {
            SearchBook();
        }

        private void SearchBook()
        {
            var response = _bookService.SearchBook(txtFilter.Text, txtYear.Text, Convert.ToInt32(cbxAuthor.SelectedValue), Convert.ToInt32(cbxCategory.SelectedValue)).ToList();
            var totalRecords = response.Count();
            txtTotalRecords.Text = totalRecords.ToString();
            booksRepeater.Width = 860;
            booksRepeater.Controls.Clear();
            for (int i = 0; i < totalRecords; i++)
            {
                var bookItem = new BookItem(response[i]);
                bookItem.Location = new Point((i % 5) * bookItem.Width, (i / 5) * bookItem.Height);
                booksRepeater.Controls.Add(bookItem);
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchBook();
        }
    }
}
