using BookStore.Model.Generated;
using BookStore.Services.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        private readonly AuthorService _AuthorService = null;
        private Author _updateAuthor = null;
        public frmAuthorDetail()
        {
            InitializeComponent();
        }
        public frmAuthorDetail(AuthorService AuthorService)
        {
            InitializeComponent();
            _AuthorService = AuthorService;
            btnSave.Text = "Insert";
        }

        public frmAuthorDetail(AuthorService AuthorService, Author AuthorUpdate)
        {
            InitializeComponent();
            _updateAuthor = AuthorUpdate;
            this.btnSave.Text = "Update";
            _AuthorService = AuthorService;
            txtTitle.Text = AuthorUpdate.Title;
            rtbDesription.Text = AuthorUpdate.Description;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            AddUpdateItemCallback("");
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_updateAuthor != null && _updateAuthor.Id > 0)
            {
                _updateAuthor = _AuthorService.GetById(_updateAuthor.Id);
                _updateAuthor.Title = txtTitle.Text;
                _updateAuthor.Description = rtbDesription.Text;
                _updateAuthor.LastUpdateTime = DateTime.Now;
                _AuthorService.Update(_updateAuthor);
            }

            else
            {
                var newAuthor = new Author();
                newAuthor.Title = txtTitle.Text;
                newAuthor.Description = rtbDesription.Text;
                newAuthor.CreateTime = DateTime.Now;

                _AuthorService.Insert(newAuthor);
            }

            this.Close();
        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            TextBox objTextBox = (TextBox)sender;

            if (objTextBox.Text.Trim() == string.Empty)
            {
                errorProvider1.SetError(objTextBox, "Please enter the required filed.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(objTextBox, null);
            }
        }
    }
}
