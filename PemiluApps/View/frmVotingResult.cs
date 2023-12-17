using PemiluApps.Controller;
using PemiluApps.Model.Context;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace PemiluApps
{
    public partial class frmVotingResult : Form
    {
        public frmVotingResult()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            frmOfficer frmOfficer = new frmOfficer();
            frmOfficer.Show();
            this.Hide();
        }

        private void frmVotingResult_Load(object sender, EventArgs e)
        {
            VotingResultController votingResultController = new VotingResultController();
            votingResultController.IsiLabelTotalSuara(lblCandidate1, lblCandidate2, lblCandidate3);

            VotingResultRepo votingResult = new VotingResultRepo();
            votingResult.RefreshData(grdVotingResult);
            votingResult.ShowChart(chart1);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            VotingResultRepo votingResult = new VotingResultRepo();
            votingResult.RefreshData(grdVotingResult);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                using (DBContext context = new DBContext())
                {
                    VotingResultController votingResultController = new VotingResultController();
                    votingResultController.Search(txtSearch, grdVotingResult);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
