using BookStore.CustomControls;
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
    public partial class frmCategoryMngt : BookStore.frmMain
    {
        #region Global Variables

        BookStoreDB _db = null;
        CategoryService _caregoryService = null;
        DataGridView grvCategory = null;        
        #endregion

        #region Constructors
        public frmCategoryMngt(BookStoreDB db, User user) : base(db, user)
        {
            _db = db;
            _caregoryService = new CategoryService(_db);
            InitializeComponent();
            initGridView(user);
            SearchCategory(txtFilter.Text);
        }

        #endregion

        #region Events Handler

        /// <summary>
        /// On Button Add Category Clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            var caregoryFrom = new frmCategoryDetail(_caregoryService);
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
            SearchCategory(txtFilter.Text);
        }

        /// <summary>
        /// Handle clicking on row Edit or row Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grvCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == grvCategory.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                var currentRow = grvCategory.Rows[e.RowIndex];
                Category categoryUpdate = new Category();
                categoryUpdate.Id = Convert.ToInt32(currentRow.Cells["Id"].Value);
                categoryUpdate.Title = currentRow.Cells["Title"].Value.ToString();
                var descriptionValue = currentRow.Cells["Description"].Value;
                categoryUpdate.Description = descriptionValue?.ToString() ?? string.Empty;
                var caregoryFrom = new frmCategoryDetail(_caregoryService, categoryUpdate);
                caregoryFrom.AddUpdateItemCallback = new AddItemDelegate(this.AddUpdateItemCallbackFn);
                caregoryFrom.ShowDialog();

            }

            else if (e.ColumnIndex == grvCategory.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                DialogResult result = MessageBox.Show(BookStoreConstants.MSG_CONFIRM_DELETE, BookStoreConstants.CONFIRM_DIALOG_NAME, MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    _caregoryService.Delete(Convert.ToInt32(grvCategory.Rows[e.RowIndex].Cells["Id"].Value));
                    SearchCategory(txtFilter.Text);
                }
            }
        }

        #endregion

        #region Private Methods

        private void initGridView(User user)
        {
            // Initialize the DataGridView.
            grvCategory = new DataGridView();
            grvCategory.AutoGenerateColumns = false;
            grvCategory.AutoSize = false;
            grvCategory.Dock = DockStyle.Fill;
            grvCategory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //grvCategory.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            grvCategory.CellContentClick += grvCategory_CellContentClick;

            DataGridViewCellStyle style = grvCategory.ColumnHeadersDefaultCellStyle;
            style.BackColor = Color.Navy;
            style.ForeColor = Color.White;
            style.Font = new Font(grvCategory.Font, FontStyle.Bold);

            DataGridViewColumn colId = new DataGridViewTextBoxColumn();
            colId.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colId.DataPropertyName = "Id";
            colId.Name = "Id";
            colId.Visible = false;
            grvCategory.Columns.Add(colId);

            DataGridViewColumn colTitle = new DataGridViewTextBoxColumn();
            colTitle.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colTitle.DataPropertyName = "Title";
            colTitle.Name = "Title";
            grvCategory.Columns.Add(colTitle);

            DataGridViewColumn colDescription = new DataGridViewTextBoxColumn();
            colDescription.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colDescription.Name = "Description";
            colDescription.DataPropertyName = "Description";
            grvCategory.Columns.Add(colDescription);

            DataGridViewImageColumn colEdit = new DataGridViewImageColumn();
            colEdit.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colEdit.Name = "Edit";
            colEdit.Width = 60;
            colEdit.Image = new Bitmap(Properties.Resources.edit_24);
            colEdit.DataPropertyName = "Edit";
            grvCategory.Columns.Add(colEdit);

            if (user.Role.RoleType == BookStoreConstants.ADMIN_ROLE_TYPE)
            {
                DataGridViewImageColumn colDel = new DataGridViewImageColumn();
                colDel.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colDel.Name = "Delete";
                colEdit.Width = 60;
                colDel.Image = new Bitmap(Properties.Resources.del_24);
                colDel.DataPropertyName = "Delete";
                grvCategory.Columns.Add(colDel);
            }

            pnlGrid.Controls.Add(grvCategory);
        }

        private void SearchCategory(string strText)
        {
            var lstCategories = _caregoryService.SearchCategory(strText);
            txtTotalRecord.Text = lstCategories.Count().ToString();
            grvCategory.DataSource = lstCategories.ToList();
        }

        private void AddUpdateItemCallbackFn(string item)
        {
            SearchCategory(txtFilter.Text);
        }

        #endregion

        private void btnBack_Click(object sender, EventArgs e)
        {

        }

    }
}
