using BookStore.Model.Generated;
using BookStore.Services.Services;
using BookStote.Helpers;
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
    public partial class frmAuthorMngt : BookStore.frmMain
    {
        #region Global Variables

        BookStoreDB _db = null;
        AuthorService _authorService = null;
        DataGridView grvAuthor = null;
        #endregion

        #region Constructors

        public frmAuthorMngt()
        {
            InitializeComponent();
        }

        public frmAuthorMngt(BookStoreDB db, User user) : base(db, user)
        {
            _db = db;
            _authorService = new AuthorService(_db);
            InitializeComponent();
            initGridView(user);
            SearchAuthor(txtFilter.Text);
        }

        #endregion

        #region Events Handler

        /// <summary>
        /// On Button Add Author Clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddAuthor_Click(object sender, EventArgs e)
        {
            var caregoryFrom = new frmAuthorDetail(_authorService);
            caregoryFrom.AddUpdateItemCallback = new AddItemDelegate(this.AddUpdateItemCallbackFn);
            caregoryFrom.ShowDialog();
        }

        /// <summary>
        /// On the filter textbox changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            SearchAuthor(txtFilter.Text);
        }

        /// <summary>
        /// Handle clicking on row Edit or row Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grvAuthor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == grvAuthor.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                var currentRow = grvAuthor.Rows[e.RowIndex];
                Author authorUpdate = new Author();
                authorUpdate.Id = Convert.ToInt32(currentRow.Cells["Id"].Value);
                authorUpdate.Title = currentRow.Cells["Title"].Value.ToString();
                var descriptionValue = currentRow.Cells["Description"].Value;
                authorUpdate.Description = descriptionValue?.ToString() ?? string.Empty;
                var coverValue = currentRow.Cells["Cover"].Value;
                authorUpdate.Cover = coverValue?.ToString() ?? string.Empty;
                var caregoryFrom = new frmAuthorDetail(_authorService, authorUpdate);
                caregoryFrom.AddUpdateItemCallback = new AddItemDelegate(this.AddUpdateItemCallbackFn);
                caregoryFrom.ShowDialog();

            }

            else if (e.ColumnIndex == grvAuthor.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                DialogResult result = MessageBox.Show(BookStoreConstants.MSG_CONFIRM_DELETE, BookStoreConstants.CONFIRM_DIALOG_NAME, MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    _authorService.Delete(Convert.ToInt32(grvAuthor.Rows[e.RowIndex].Cells["Id"].Value));
                    SearchAuthor(txtFilter.Text);
                }
            }
        }

        #endregion

        #region Private Methods

        private void initGridView(User user)
        {
            // Initialize the DataGridView.
            grvAuthor = new DataGridView();
            grvAuthor.AutoGenerateColumns = false;
            grvAuthor.AutoSize = false;
            grvAuthor.Dock = DockStyle.Fill;
            grvAuthor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //grvAuthor.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            grvAuthor.CellContentClick += grvAuthor_CellContentClick;

            DataGridViewCellStyle style = grvAuthor.ColumnHeadersDefaultCellStyle;
            style.BackColor = Color.Navy;
            style.ForeColor = Color.White;
            style.Font = new Font(grvAuthor.Font, FontStyle.Bold);

            DataGridViewColumn colId = new DataGridViewTextBoxColumn();
            colId.DataPropertyName = "Id";
            colId.Name = "Id";
            colId.Visible = false;
            grvAuthor.Columns.Add(colId);

            DataGridViewColumn colCover = new DataGridViewTextBoxColumn();
            colCover.DataPropertyName = "Cover";
            colCover.Name = "Cover";
            colCover.Visible = false;
            grvAuthor.Columns.Add(colCover);

            DataGridViewColumn colTitle = new DataGridViewTextBoxColumn();
            colTitle.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colTitle.DataPropertyName = "Title";
            colTitle.Name = "Title";
            grvAuthor.Columns.Add(colTitle);

            DataGridViewColumn colDescription = new DataGridViewTextBoxColumn();
            colDescription.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colDescription.Name = "Description";
            colDescription.DataPropertyName = "Description";
            grvAuthor.Columns.Add(colDescription);

            DataGridViewImageColumn colEdit = new DataGridViewImageColumn();
            colEdit.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colEdit.Name = "Edit";
            colEdit.Width = 60;
            colEdit.Image = new Bitmap(Properties.Resources.edit_24);
            colEdit.DataPropertyName = "Edit";
            grvAuthor.Columns.Add(colEdit);

            if (user.Role.RoleType == BookStoreConstants.ADMIN_ROLE_TYPE)
            {
                DataGridViewImageColumn colDel = new DataGridViewImageColumn();
                colDel.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colDel.Name = "Delete";
                colEdit.Width = 60;
                colDel.Image = new Bitmap(Properties.Resources.del_24);
                colDel.DataPropertyName = "Delete";
                grvAuthor.Columns.Add(colDel);
            }

            pnlGrid.Controls.Add(grvAuthor);
        }

        private void SearchAuthor(string strText)
        {
            var lstAuthors = _authorService.SearchAuthor(strText);
            txtTotalRecord.Text = lstAuthors.Count().ToString();
            grvAuthor.DataSource = lstAuthors.ToList();
        }

        private void AddUpdateItemCallbackFn(string item)
        {
            SearchAuthor(txtFilter.Text);
        }

        #endregion

        private void btnBack_Click(object sender, EventArgs e)
        {

        }
    }
}
