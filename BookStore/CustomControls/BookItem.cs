using System.Drawing;
using System.Windows.Forms;
using BookStore.Model.Generated;
using System.IO;
using BookStote.Helpers;
using static BookStore.Deletgates;
using System;

namespace BookStore.CustomControls
{
    public partial class BookItem : UserControl
    {
        #region Global Viarables

        readonly Book _book;
        readonly User _user;
        public AddUpdateItemDelegate AddUpdateItemCallback { get; internal set; }
        #endregion

        #region Constructors

        public BookItem()
        {
            InitializeComponent();
        }
        public BookItem(Book book, User user, AddUpdateItemDelegate adddUpdateItemCallback)
        {
            InitializeComponent();
            _user = user;
            _book = book;
            AddUpdateItemCallback = adddUpdateItemCallback;

            lblTitle.Text = book.Title;
            lblPublisher.Text = book.Publisher;
            lblYear.Text = book.Year.ToString();
            lblAuthor.Text = book.Author?.Title ?? String.Empty;
            lblDescription.Text = book.Description;

            toolTip1.SetToolTip(lblTitle, book.Title);
            toolTip1.SetToolTip(lblPublisher, book.Publisher);
            toolTip1.SetToolTip(lblYear, book.Year.ToString());
            toolTip1.SetToolTip(lblDescription, book.Description);

            picCover.SizeMode = PictureBoxSizeMode.StretchImage;
            if (!string.IsNullOrEmpty(book.Cover) && File.Exists(book.Cover.GetFullPath(BookStoreConstants.BOOK_DIR_PATH)))
            {
                picCover.Image = Image.FromFile(book.Cover.GetFullPath(BookStoreConstants.BOOK_DIR_PATH));
            }

        }
        #endregion

        #region Events
        private void lblTitle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var bookDetailDialog = new BookDetail(_book, _user))
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
