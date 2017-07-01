using BookStore.Model.Generated;
using BookStore.Services.Services;
using BookStote.Helpers;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BookStore
{
    public partial class CategoryManagement : Main
    {
        #region Global Variables

        readonly User _user;
        CategoryService _caregoryService;
        #endregion

        #region Constructors
        public CategoryManagement(User user) : base(user)
        {
            _user = user;
            _caregoryService = new CategoryService(new BookStoreDB());
            InitializeComponent();
            InitGridView(user);
            SearchCategory(txtFilter.Text);
        }
        #endregion

        #region Events
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            using (var caregoryFrom = new CategoryDetail(_user, null, _caregoryService))
            {
                var dr = caregoryFrom.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    SearchCategory(txtFilter.Text);
                }
            }
        }
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            SearchCategory(txtFilter.Text);
        }
        private void grvCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            // get current Category
            var category = _caregoryService.GetById(Convert.ToInt32(gridViewCategory.Rows[e.RowIndex].Cells["Id"].Value));

            // for Editing
            if (e.ColumnIndex == gridViewCategory.Columns["Edit"].Index)
            {
                using (var categoryFrom = new CategoryDetail(_user, category, _caregoryService))
                {
                    var dr = categoryFrom.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        _caregoryService = new CategoryService(new BookStoreDB());
                        SearchCategory(txtFilter.Text);
                    }
                }
            }

            // for Deleting
            else
            {
                var deleteColumn = gridViewCategory.Columns["Delete"];
                if (deleteColumn != null && e.ColumnIndex == deleteColumn.Index)
                {
                    DialogResult result = MessageBox.Show(BookStoreConstants.MSG_CONFIRM_DELETE, BookStoreConstants.CONFIRM_DIALOG_NAME, MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            if (category.Books != null && category.Books.Count > 0)
                            {
                                var dr = MessageBox.Show(BookStoreConstants.MSG_CATEGORY_CONFIRM_DELETE, BookStoreConstants.CONFIRM_DIALOG_NAME, MessageBoxButtons.YesNo);
                                if (dr == DialogResult.No)
                                {
                                    return;
                                }

                                foreach (Book book in category.Books)
                                {
                                    book.CategoryId = null;
                                }
                            }
                            _caregoryService.Delete(category);
                            SearchCategory(txtFilter.Text);
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
            gridViewCategory.AutoGenerateColumns = false;
            gridViewCategory.AutoSize = false;
            DataGridViewCellStyle style = gridViewCategory.ColumnHeadersDefaultCellStyle;
            style.BackColor = Color.Navy;
            style.ForeColor = Color.White;
            style.Font = new Font(gridViewCategory.Font, FontStyle.Bold);

            DataGridViewColumn colId = new DataGridViewTextBoxColumn();
            colId.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colId.DataPropertyName = "Id";
            colId.Name = "Id";
            colId.Visible = false;
            gridViewCategory.Columns.Add(colId);

            DataGridViewColumn colTitle = new DataGridViewTextBoxColumn();
            colTitle.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colTitle.DataPropertyName = "Title";
            colTitle.Name = "Title";
            gridViewCategory.Columns.Add(colTitle);

            DataGridViewColumn colDescription = new DataGridViewTextBoxColumn();
            colDescription.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colDescription.Name = "Description";
            colDescription.DataPropertyName = "Description";
            gridViewCategory.Columns.Add(colDescription);

            DataGridViewImageColumn colEdit = new DataGridViewImageColumn();
            colEdit.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colEdit.Name = "Edit";
            colEdit.Width = 60;
            colEdit.Image = new Bitmap(Properties.Resources.edit_24);
            colEdit.DataPropertyName = "Edit";
            gridViewCategory.Columns.Add(colEdit);

            if (user.Role.RoleType == BookStoreConstants.ADMIN_ROLE_TYPE)
            {
                DataGridViewImageColumn colDel = new DataGridViewImageColumn();
                colDel.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colDel.Name = "Delete";
                colEdit.Width = 60;
                colDel.Image = new Bitmap(Properties.Resources.del_24);
                colDel.DataPropertyName = "Delete";
                gridViewCategory.Columns.Add(colDel);
            }

            gridViewCategory.CellContentClick += grvCategory_CellContentClick;
        }

        private void SearchCategory(string strText)
        {
            var lstCategories = _caregoryService.SearchCategory(strText).ToList();
            txtTotalRecord.Text = lstCategories.Count.ToString();
            gridViewCategory.DataSource = lstCategories.OrderBy(t=>t.Title).ToList();
        }
        #endregion
    }
}
