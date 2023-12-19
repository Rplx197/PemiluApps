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
    public partial class frmManageUserDetail : Form
    {
        private UserDetailController userDetailController;
        public frmManageUserDetail()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            frmOfficer frmOfficer = new frmOfficer();
            frmOfficer.Show();
            this.Hide();
        }

        private void frmManageUserDetail_Load(object sender, EventArgs e)
        {
            using (DBContext context = new DBContext())
            {
                UserDetailRepo userDetailRepo = new UserDetailRepo(context);
                userDetailRepo.RefreshData(grdUserDetail);
            }
        }

        private void grdUserDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            userDetailController = new UserDetailController();
            userDetailController.grdClick(e, grdUserDetail, txtNoKtp, txtNama, txtAlamat, cmbKelamin, dtpTanggalLahir
                        , cmbAgama, cmbStatusMenikah, txtPekerjaan, cmbKewarganegaraan);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            userDetailController = new UserDetailController();
            userDetailController.ClearData(txtNoKtp, txtNama, txtAlamat, cmbKelamin, dtpTanggalLahir
                , cmbAgama, cmbStatusMenikah, txtPekerjaan, cmbKewarganegaraan);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                string noktp = txtNoKtp.Text;
                string name = txtNama.Text;
                string address = txtAlamat.Text;
                string gender = cmbKelamin.Text;
                string date = dtpTanggalLahir.Text;
                string religion = cmbAgama.Text;
                string married = cmbStatusMenikah.Text;
                string job = txtPekerjaan.Text;
                string nationality = cmbKewarganegaraan.Text;

                UserDetail insertUserDetail = new UserDetail {
                    No_KTP = noktp, 
                    Name_User = name,
                    Address_User = address,
                    Gender_User = gender,
                    DateOfBorn_User = date, 
                    Religion_User = religion, 
                    Married = married, 
                    Job_User = job, 
                    Nationality_User = nationality };

                using (DBContext context = new DBContext())
                {
                    int idToAdd = int.Parse(txtNoKtp.Text);
                    userDetailController = new UserDetailController();

                    userDetailController.Insert(insertUserDetail, grdUserDetail);
                    userDetailController.ClearData(txtNoKtp, txtNama, txtAlamat, cmbKelamin, dtpTanggalLahir
                        , cmbAgama, cmbStatusMenikah, txtPekerjaan, cmbKewarganegaraan);
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
                string noktp = txtNoKtp.Text;
                string name = txtNama.Text;
                string address = txtAlamat.Text;
                string gender = cmbKelamin.Text;
                string date = dtpTanggalLahir.Text;
                string religion = cmbAgama.Text;
                string married = cmbStatusMenikah.Text;
                string job = txtPekerjaan.Text;
                string nationality = cmbKewarganegaraan.Text;

                UserDetail updateUserDetail = new UserDetail
                {
                    No_KTP = noktp,
                    Name_User = name,
                    Address_User = address,
                    Gender_User = gender,
                    DateOfBorn_User = date,
                    Religion_User = religion,
                    Married = married,
                    Job_User = job,
                    Nationality_User = nationality
                };

                using (DBContext context = new DBContext())
                {
                    userDetailController = new UserDetailController();
                    userDetailController.Update(updateUserDetail, grdUserDetail);
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
                string noktp = txtNoKtp.Text;

                UserDetail deleteUserDetail = new UserDetail { No_KTP = noktp };

                using (DBContext context = new DBContext())
                {
                    userDetailController = new UserDetailController();
                    userDetailController.Delete(deleteUserDetail, grdUserDetail);
                    userDetailController.ClearData(txtNoKtp, txtNama, txtAlamat, cmbKelamin, dtpTanggalLahir
                        , cmbAgama, cmbStatusMenikah, txtPekerjaan, cmbKewarganegaraan);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                using (DBContext context = new DBContext())
                {
                    userDetailController = new UserDetailController();
                    userDetailController.Search(txtSearch, grdUserDetail);
                    userDetailController.ClearData(txtNoKtp, txtNama, txtAlamat, cmbKelamin, dtpTanggalLahir
                        , cmbAgama, cmbStatusMenikah, txtPekerjaan, cmbKewarganegaraan);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            using (DBContext context = new DBContext())
            {
                UserDetailRepo userDetailRepo = new UserDetailRepo(context);
                userDetailRepo.RefreshData(grdUserDetail);
            }
        }
    }
}
