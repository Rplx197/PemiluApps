using PemiluApps.Controller;
using PemiluApps.Model.Context;
using PemiluApps.Model.Entity;
using PemiluApps.Model.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PemiluApps
{
    public partial class frmManageUser : Form
    {
        private UserController userController;
        public frmManageUser()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            frmOfficer frmOfficer = new frmOfficer();
            frmOfficer.Show();
            this.Hide();
        }

        private void frmManageUser_Load(object sender, EventArgs e)
        {
            using (DBContext context = new DBContext())
            {
                UserRepo userRepo = new UserRepo(context);
                userRepo.RefreshData(grdUser);
            }
        }

        private void grdUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            userController = new UserController();
            userController.grdClick(e, grdUser, txtUserID, txtNoKTP, txtPassword, txtTPSID);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            using (DBContext context = new DBContext())
            {
                UserRepo userRepo = new UserRepo(context);
                userRepo.RefreshData(grdUser);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                string userid = txtUserID.Text;
                string noktp = txtNoKTP.Text;
                string password = txtPassword.Text;
                string tpsid = txtTPSID.Text;
                string status = "B";

                User insertUser = new User { UserID =  userid, No_KTP = noktp, Password = password,TPSID = tpsid, Status = status};

                using (DBContext context = new DBContext())
                {
                    int idToAdd = int.Parse(txtUserID.Text);
                    userController = new UserController();

                    userController.Insert(insertUser, grdUser);
                    userController.ClearData(txtUserID, txtNoKTP, txtPassword, txtTPSID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string userid = txtUserID.Text;
                string noktp = txtNoKTP.Text;
                string password = txtPassword.Text;
                string tpsid = txtTPSID.Text;

                User updateUser = new User { UserID = userid, No_KTP = noktp, Password = password, TPSID = tpsid};

                using (DBContext context = new DBContext())
                {
                    userController = new UserController();
                    userController.Update(updateUser, grdUser);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string userid = txtUserID.Text;

                User deleteUser = new User { UserID = userid };

                using (DBContext context = new DBContext())
                {
                    userController = new UserController();
                    userController.Delete(deleteUser, grdUser);
                    userController.ClearData(txtUserID, txtNoKTP, txtPassword, txtTPSID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGeneratePassword_Click(object sender, EventArgs e)
        {
            userController = new UserController();
            int passwordLength = 8;
            string password = userController.GeneratePassword(passwordLength);
            txtPassword.Text = password;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                using (DBContext context = new DBContext())
                {
                    userController = new UserController();
                    userController.Search(txtSearch, grdUser);
                    userController.ClearData(txtUserID, txtNoKTP, txtPassword, txtTPSID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            userController = new UserController();
            userController.ClearData(txtUserID, txtNoKTP, txtPassword, txtTPSID);
        }
    }
}
