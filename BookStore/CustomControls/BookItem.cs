using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookStore.Model.Generated;
using BookStore.Services.Services;
using System.IO;
using static BookStore.Deletgates;

namespace BookStore.CustomControls
{
    public partial class BookItem : UserControl
    {
        #region Global Viarables
        Book _book = null;
        User _user = null;
        public AddItemDelegate AddUpdateItemCallback { get; internal set; }
        #endregion

        #region Constructors

        public BookItem()
        {
            InitializeComponent();
        }
        public BookItem(Book book, User user, AddItemDelegate adddUpdateItemCallback)
        {
            InitializeComponent();
            _user = user;
            _book = book;
            AddUpdateItemCallback = adddUpdateItemCallback;

            lblTitle.Text = book.Title;
            lblPublisher.Text = book.Publisher;
            lblYear.Text = book.Year.ToString();
            lblAuthor.Text = book.Author.Title;
            lblDescription.Text = book.Description;

            toolTip1.SetToolTip(lblTitle, book.Title);
            toolTip1.SetToolTip(lblPublisher, book.Publisher);
            toolTip1.SetToolTip(lblYear, book.Year.ToString());
            toolTip1.SetToolTip(lblDescription, book.Description);

            picCover.SizeMode = PictureBoxSizeMode.StretchImage;
            if (!string.IsNullOrEmpty(book.Cover))
            {
                picCover.Image = Image.FromFile(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())) + book.Cover);
            }

        }
        #endregion

        #region Events
        private void lblTitle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var bookDetailDialog =
                new BookDetail(_book, _user) { AddUpdateItemCallback = AddUpdateItemCallbackFn };
            bookDetailDialog.ShowDialog();
        }
        #endregion

        #region Private Methods
        private void AddUpdateItemCallbackFn(string strValue)
        {
            AddUpdateItemCallback("");
        }
        #endregion
    }
}
