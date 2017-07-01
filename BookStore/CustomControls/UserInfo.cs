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

namespace BookStore.CustomControls
{
    public partial class UserInfo : UserControl
    {
        #region Constructors
        public UserInfo()
        {
            InitializeComponent();
        }
        public UserInfo(User user)
        {
            InitializeComponent();
            lblDisplayName.Text = $@"{user.FirstName} {user.LastName}";
        }
        #endregion

        #region Events
        private void btnLogout_Click(object sender, EventArgs e)
        {
            var loginForm = new Login();
            var parentForm = this.FindForm();
            parentForm.Close();
            loginForm.Show();
        }
        #endregion
    }
}
