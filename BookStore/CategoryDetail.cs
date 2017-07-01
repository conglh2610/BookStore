using BookStore.Model.Generated;
using BookStore.Services.Services;
using BookStote.Helpers;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using static BookStore.Deletgates;

namespace BookStore
{
    public partial class CategoryDetail : Form
    {
        #region Global Variables
        public AddItemDelegate AddUpdateItemCallback { get; internal set; }
        private readonly CategoryService _categoryService;
        private Category _category;

        #endregion

        #region Constructors

        public CategoryDetail()
        {
            InitializeComponent();
        }

        public CategoryDetail(User user, Category category)
        {
            InitializeComponent();
            _category = category;
            _categoryService = new CategoryService(new BookStoreDB());
            if (category != null && category.Id > 0)
            {
                _category = category;
                this.btnSave.Text = "Update";
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
                btnSave.Text = "Insert";
                btnSave.Location = btnDelete.Location;
                btnDelete.Visible = false;
            }

        }
        #endregion

        #region Events

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren(ValidationConstraints.Enabled))
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
                    _categoryService.Delete(_category.Id);
                    AddUpdateItemCallback("");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(BookStoreConstants.MSG_DB_ERROR + ex.Message);
                }

                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            TextBox objTextBox = (TextBox)sender;

            if (objTextBox.Text.Trim() == string.Empty)
            {
                errorProvider1.SetError(objTextBox, BookStoreConstants.MSG_REQUIRED_FIELD);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(objTextBox, null);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            AddUpdateItemCallback("");
        }
        #endregion
    }
}
