using BookStore.Model.Generated;
using BookStore.Services.Services;
using BookStote.Helpers;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BookStore
{
    public partial class AuthorManagement : Main
    {
        #region Global Variables

        private readonly User _user;
        private AuthorService _authorService;
        #endregion

        #region Constructors
        public AuthorManagement()
        {
            InitializeComponent();
        }

        public AuthorManagement(User user) : base(user)
        {
            InitializeComponent();
            _user = user;
            _authorService = new AuthorService(new BookStoreDB());
            InitGridView(user);
            SearchAuthor(txtFilter.Text);
        }

        #endregion

        #region Events Handler
        private void btnAddAuthor_Click(object sender, EventArgs e)
        {
            using (var caregoryFrom = new AuthorDetail(_user, null, _authorService))
            {
                DialogResult dr = caregoryFrom.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    SearchAuthor(txtFilter.Text);
                }
            }
        }
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            SearchAuthor(txtFilter.Text);
        }

        private void grvAuthor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            // get current Category
            var author = _authorService.GetById(Convert.ToInt32(gridViewAuthor.Rows[e.RowIndex].Cells["Id"].Value));

            // for Editing
            if (e.ColumnIndex == gridViewAuthor.Columns["Edit"].Index)
            {
                using (var authorFrom = new AuthorDetail(_user, author, _authorService))
                {
                    var dr = authorFrom.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        _authorService = new AuthorService(new BookStoreDB());
                        SearchAuthor(txtFilter.Text);
                    }
                }
            }

            // for Deleting
            else
            {
                var deleteColumn = gridViewAuthor.Columns["Delete"];
                if (deleteColumn != null && e.ColumnIndex == deleteColumn.Index)
                {
                    DialogResult result = MessageBox.Show(BookStoreConstants.MSG_CONFIRM_DELETE, BookStoreConstants.CONFIRM_DIALOG_NAME, MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            if (author.Books != null && author.Books.Count > 0)
                            {
                                var dr = MessageBox.Show(BookStoreConstants.MSG_AUTHOR_CONFIRM_DELETE, BookStoreConstants.CONFIRM_DIALOG_NAME, MessageBoxButtons.YesNo);
                                if (dr == DialogResult.No)
                                {
                                    return;
                                }

                                foreach (Book book in author.Books)
                                {
                                    book.AuthorId = null;
                                }
                            }
                            _authorService.Delete(author);
                            SearchAuthor(txtFilter.Text);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show(BookStoreConstants.MSG_DB_ERROR);
                        }
                    }
                }
            }
        }

        #endregion

        #region Private Methods

        private void InitGridView(User user)
        {
            gridViewAuthor.AutoGenerateColumns = false;
            gridViewAuthor.AutoSize = false;
            DataGridViewCellStyle style = gridViewAuthor.ColumnHeadersDefaultCellStyle;
            style.BackColor = Color.Navy;
            style.ForeColor = Color.White;
            style.Font = new Font(gridViewAuthor.Font, FontStyle.Bold);

            DataGridViewColumn colId = new DataGridViewTextBoxColumn();
            colId.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colId.DataPropertyName = "Id";
            colId.Name = "Id";
            colId.Visible = false;
            gridViewAuthor.Columns.Add(colId);

            DataGridViewColumn colTitle = new DataGridViewTextBoxColumn();
            colTitle.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colTitle.DataPropertyName = "Title";
            colTitle.Name = "Title";
            gridViewAuthor.Columns.Add(colTitle);

            DataGridViewColumn colDescription = new DataGridViewTextBoxColumn();
            colDescription.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colDescription.Name = "Description";
            colDescription.DataPropertyName = "Description";
            gridViewAuthor.Columns.Add(colDescription);

            DataGridViewImageColumn colEdit = new DataGridViewImageColumn();
            colEdit.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colEdit.Name = "Edit";
            colEdit.Width = 60;
            colEdit.Image = new Bitmap(Properties.Resources.edit_24);
            colEdit.DataPropertyName = "Edit";
            gridViewAuthor.Columns.Add(colEdit);

            if (user.Role.RoleType == BookStoreConstants.ADMIN_ROLE_TYPE)
            {
                DataGridViewImageColumn colDel = new DataGridViewImageColumn();
                colDel.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colDel.Name = "Delete";
                colEdit.Width = 60;
                colDel.Image = new Bitmap(Properties.Resources.del_24);
                colDel.DataPropertyName = "Delete";
                gridViewAuthor.Columns.Add(colDel);
            }

            gridViewAuthor.CellContentClick += grvAuthor_CellContentClick;
        }

        private void SearchAuthor(string strText)
        {
            var lstAuthors = _authorService.SearchAuthor(strText).ToList();
            txtTotalRecord.Text = lstAuthors.Count.ToString();
            gridViewAuthor.DataSource = lstAuthors.OrderBy(t=>t.Title).ToList();
        }

        #endregion
    }
}
