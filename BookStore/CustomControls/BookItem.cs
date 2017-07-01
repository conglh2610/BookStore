using System.Drawing;
using System.Windows.Forms;
using BookStore.Model.Generated;
using System.IO;
using BookStote.Helpers;
using static BookStore.Deletgates;
using System;
using BookStore.Services.Services;

namespace BookStore.CustomControls
{
    public partial class BookItem : UserControl
    {
        #region Global Viarables

        readonly Book _book;
        readonly User _user;
        private readonly BookStoreDB _db;
        public AddUpdateItemDelegate AddUpdateItemCallback { get; internal set; }
        #endregion

        #region Constructors

        public BookItem()
        {
            InitializeComponent();
        }
        public BookItem(int bookId, User user, AddUpdateItemDelegate adddUpdateItemCallback)
        {
            InitializeComponent();
            _user = user;
            _db = new BookStoreDB();
            var bookService = new BookService(_db);
            _book = bookService.GetById(bookId);
            AddUpdateItemCallback = adddUpdateItemCallback;

            lblTitle.Text = _book.Title;
            lblPublisher.Text = _book.Publisher;
            lblYear.Text = _book.Year.ToString();
            lblAuthor.Text = _book.Author?.Title ?? String.Empty;
            lblDescription.Text = _book.Description;

            toolTip1.SetToolTip(lblTitle, _book.Title);
            toolTip1.SetToolTip(lblPublisher, _book.Publisher);
            toolTip1.SetToolTip(lblYear, _book.Year.ToString());
            toolTip1.SetToolTip(lblDescription, _book.Description);

            picCover.SizeMode = PictureBoxSizeMode.StretchImage;
            if (!string.IsNullOrEmpty(_book.Cover) && File.Exists(_book.Cover.GetFullPath(BookStoreConstants.BOOK_DIR_PATH)))
            {
                picCover.Image = Image.FromFile(_book.Cover.GetFullPath(BookStoreConstants.BOOK_DIR_PATH));
            }

        }
        #endregion

        #region Events
        private void lblTitle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var bookDetailDialog = new BookDetail(_book, _user, _db))
            {
                DialogResult dr = bookDetailDialog.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    AddUpdateItemCallback();
                }
            }
        }
        #endregion
    }
}
