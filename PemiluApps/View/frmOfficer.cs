using PemiluApps.Controller;
using PemiluApps.Model.Context;
using PemiluApps.Model.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PemiluApps
{
    public partial class frmOfficer : Form
    {
        public frmOfficer()
        {
            InitializeComponent();
            
        }

        private void frmOfficer_Load(object sender, EventArgs e)
        {
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnManageUserDetail_Click(object sender, EventArgs e)
        {
            frmManageUserDetail frmManageUser = new frmManageUserDetail();
            frmManageUser.Show();
            this.Hide();
        }

        private void btnManageUser_Click(object sender, EventArgs e)
        {
            frmManageUser frmManageVoter = new frmManageUser();
            frmManageVoter.Show();
            this.Hide();
        }

        private void btnManageTPS_Click(object sender, EventArgs e)
        {
            frmManageTPS frmManageTPS = new frmManageTPS();
            frmManageTPS.Show();
            this.Hide();
        }

        private void btnVotingResullt_Click(object sender, EventArgs e)
        {
            frmVotingResult frmVotingResult = new frmVotingResult();
            frmVotingResult.Show();
            this.Hide();
        }
    }
}
