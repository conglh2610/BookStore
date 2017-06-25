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

namespace BookStore.CustomControls
{
    public partial class BookItem : UserControl
    {
        Book _book = null;
        public BookItem(Book book)
        {
            InitializeComponent();
            _book = book;
            lblTitle.Text = book.Title;
            lblPublisher.Text = book.Publisher;
            lblYear.Text = book.Year.ToString();
            lblDescription.Text = book.Description;

            picCover.SizeMode = PictureBoxSizeMode.StretchImage;
            if (!string.IsNullOrEmpty(book.Cover))
            {
                picCover.Image = Image.FromFile(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())) + book.Cover);
            }

        }

        private void lblTitle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var db = new BookStoreDB();
            var bookDetailDialog = new frmBookDetail(_book);
            bookDetailDialog.ShowDialog();
        }
    }
}
