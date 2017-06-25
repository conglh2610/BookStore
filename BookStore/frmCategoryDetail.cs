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
using System.Threading.Tasks;
using System.Windows.Forms;
using static BookStore.Deletgates;

namespace BookStore
{
    public partial class frmCategoryDetail : Form
    {
        public AddItemDelegate AddUpdateItemCallback { get; internal set; }
        private CategoryService _categoryService = null;
        private Category _categoryUpdate = null;

        public frmCategoryDetail(User user, Category categoryUpdate)
        {
            InitializeComponent();
            _categoryUpdate = categoryUpdate;
            _categoryService = new CategoryService(new BookStoreDB());
            if (categoryUpdate != null && categoryUpdate.Id > 0)
            {
                _categoryUpdate = categoryUpdate;
                this.btnSave.Text = "Update";
                txtTitle.Text = categoryUpdate.Title;
                rtbDesription.Text = categoryUpdate.Description;

                if (user.Role.RoleType != BookStoreConstants.ADMIN_ROLE_TYPE)
                {
                    btnSave.Location = btnDelete.Location;
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

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            AddUpdateItemCallback("");
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren(ValidationConstraints.Enabled))
            {
                if (_categoryUpdate != null && _categoryUpdate.Id > 0)
                {
                    _categoryUpdate = _categoryService.GetById(_categoryUpdate.Id);
                    _categoryUpdate.Title = txtTitle.Text;
                    _categoryUpdate.Description = rtbDesription.Text;
                    _categoryUpdate.LastUpdateTime = DateTime.Now;
                    _categoryService.Update(_categoryUpdate);
                }

                else
                {
                    var newCategory = new Category();
                    newCategory.Title = txtTitle.Text;
                    newCategory.Description = rtbDesription.Text;
                    newCategory.CreateTime = DateTime.Now;

                    _categoryService.Insert(newCategory);
                }

                this.Close();
            }
            
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(BookStoreConstants.MSG_CONFIRM_DELETE, BookStoreConstants.CONFIRM_DIALOG_NAME, MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    _categoryService.Delete(_categoryUpdate.Id);
                    AddUpdateItemCallback("");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(BookStoreConstants.MSG_DB_ERROR + ex.Message);
                }

                this.Close();
            }
        }
    }
}
