using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml;
using PemiluApps.Model.Repository;
using PemiluApps.Model.Context;
using PemiluApps.Model.Entity;
using PemiluApps.Controller;

namespace PemiluApps
{
    public partial class frmLogin : Form
    {
        private LoginRepo _repo;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (DBContext context = new DBContext())
            {
                _repo = new LoginRepo(context);
                _repo.Login(txtNoKTP, txtPassword, this);
            }
            txtNoKTP.Clear();
            txtPassword.Clear();
            txtNoKTP.Focus();
        }

        private void chkTogglePassword_CheckedChanged(object sender, EventArgs e)
        {
            LoginController loginController = new LoginController();
            loginController.TogglePasswordVisibility(txtPassword, chkTogglePassword);
        }
    }
}
