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
    public partial class frmCategoryDetail : Form
    {
        public AddItemDelegate AddUpdateItemCallback { get; internal set; }
        private readonly CategoryService _categoryService = null;
        private Category _updateCategory = null;

        public frmCategoryDetail(CategoryService categoryService)
        {
            InitializeComponent();
            _categoryService = categoryService;
            btnSave.Text = "Insert";
        }

        public frmCategoryDetail(CategoryService categoryService, Category categoryUpdate)
        {
            InitializeComponent();
            _updateCategory = categoryUpdate;
            this.btnSave.Text = "Update";
            _categoryService = categoryService;
            txtTitle.Text = categoryUpdate.Title;
            rtbDesription.Text = categoryUpdate.Description;
        }      

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            AddUpdateItemCallback("");
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_updateCategory != null && _updateCategory.Id > 0)
            {
                _updateCategory = _categoryService.GetById(_updateCategory.Id);
                _updateCategory.Title = txtTitle.Text;
                _updateCategory.Description = rtbDesription.Text;
                _updateCategory.LastUpdateTime = DateTime.Now;
                _categoryService.Update(_updateCategory);
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
