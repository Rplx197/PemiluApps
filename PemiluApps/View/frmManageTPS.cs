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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PemiluApps
{
    public partial class frmManageTPS : Form
    {
        public frmManageTPS()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            frmOfficer frmOfficer = new frmOfficer();
            frmOfficer.Show();
            this.Hide();
        }

        private void frmManageTPS_Load(object sender, EventArgs e)
        {
            using (DBContext context = new DBContext())
            {
                TPSRepo tpsRepo = new TPSRepo(context);
                tpsRepo.RefreshData(grdTPS);
            }
        }

        private void grdTPS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TPSController tpsController = new TPSController();
            tpsController.grdClick(e, grdTPS,txtTPSID, txtNamaTPS, txtPetugas);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            TPSController tpsController = new TPSController();
            tpsController.ClearData(txtTPSID, txtNamaTPS, txtPetugas);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                string tpsid = txtTPSID.Text;
                string name = txtNamaTPS.Text;
                string officer = txtPetugas.Text;

                TPS insertTPS = new TPS { TPSID = tpsid, Name_TPS = name, Officer_TPS = officer };

                using (DBContext context = new DBContext())
                {
                    int idToAdd = int.Parse(txtTPSID.Text);
                    TPSController tpsController = new TPSController();

                    tpsController.Insert(insertTPS, grdTPS);
                    tpsController.ClearData(txtTPSID, txtNamaTPS, txtPetugas);
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
                string tpsid = txtTPSID.Text;
                string name = txtNamaTPS.Text;
                string officer = txtPetugas.Text;

                TPS updateTPS = new TPS { TPSID = tpsid, Name_TPS = name, Officer_TPS = officer };

                using (DBContext context = new DBContext())
                {
                    TPSController tpsController = new TPSController();
                    tpsController.Update(updateTPS, grdTPS);
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
                string tpsid = txtTPSID.Text;

                TPS deleteTPS = new TPS { TPSID = tpsid };

                using (DBContext context = new DBContext())
                {
                    TPSController tpsController = new TPSController();
                    tpsController.Delete(deleteTPS, grdTPS);
                    tpsController.ClearData(txtTPSID, txtNamaTPS, txtPetugas);
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
                    TPSController tpsController = new TPSController();
                    tpsController.Search(txtSearch, grdTPS);
                    tpsController.ClearData(txtTPSID, txtNamaTPS, txtPetugas);
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
                TPSRepo tpsRepo = new TPSRepo(context);
                tpsRepo.RefreshData(grdTPS);
            }
        }
    }
}
