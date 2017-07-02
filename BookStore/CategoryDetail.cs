using BookStore.Model.Generated;
using BookStore.Services.Services;
using BookStote.Helpers;
using System;
using System.Windows.Forms;

namespace BookStore
{
    public partial class CategoryDetail : Form
    {
        #region Global Variables
        private readonly CategoryService _categoryService;
        private Category _category;

        #endregion

        #region Constructors

        public CategoryDetail()
        {
            InitializeComponent();
        }

        public CategoryDetail(User user, Category category, CategoryService caregoryService)
        {
            InitializeComponent();
            _category = category;
            _categoryService = caregoryService;
            if (category != null && category.Id > 0)
            {
                _category = category;
                this.btnSave.Text = BookStoreConstants.BUTTON_TEXT_UPDATE;
                txtTitle.Text = category.Title;
                rtbDesription.Text = category.Description;

                if (user.Role.RoleType != BookStoreConstants.ADMIN_ROLE_TYPE)
                {
                    this.btnSave.Location = btnDelete.Location;
                    btnDelete.Visible = false;
                }
            }

            else
            {
                btnSave.Text = BookStoreConstants.BUTTON_TEXT_ADD; 
                btnSave.Location = btnDelete.Location;
                btnDelete.Visible = false;
            }

        }
        #endregion

        #region Events

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.OnValidating())
            {
                if (_category != null && _category.Id > 0)
                {
                    _category.LastUpdateTime = DateTime.Now;
                }
                else
                {
                    _category = new Category { CreateTime = DateTime.Now };
                }

                _category.Title = txtTitle.Text;
                _category.Description = rtbDesription.Text;

                _categoryService.Upsert(_category);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(BookStoreConstants.MSG_CONFIRM_DELETE, BookStoreConstants.CONFIRM_DIALOG_NAME, MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    if(_category.Books != null && _category.Books.Count > 0)
                    {
                        var dr = MessageBox.Show(BookStoreConstants.MSG_CATEGORY_CONFIRM_DELETE, BookStoreConstants.CONFIRM_DIALOG_NAME, MessageBoxButtons.YesNo);
                        if (dr == DialogResult.No)
                        {
                            return;
                        }

                        foreach (Book book in _category.Books)
                        {
                            book.CategoryId = null;
                        }
                    }

                    _categoryService.Delete(_category);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(BookStoreConstants.MSG_DB_ERROR + ex.Message);
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool OnValidating()
        {

            if (String.IsNullOrEmpty(txtTitle.Text.Trim()))
            {
                errorProvider1.SetError(txtTitle, BookStoreConstants.MSG_REQUIRED_FIELD);
                return false;
            }
            else
            {
                errorProvider1.SetError(txtTitle, null);
            }

            return true;
        }

        #endregion
    }
}
