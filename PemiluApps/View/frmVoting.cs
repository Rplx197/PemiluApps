using PemiluApps.Controller;
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
using PemiluApps.Model.Entity;

namespace PemiluApps
{
    public partial class frmVoting : Form
    {
        int userid, tpsid;
        string noktp;
        
        private void imgCapres1_Click(object sender, EventArgs e)
        {
            Voting voting = new Voting();
            voting.UserID = userid;
            voting.TPSID = tpsid;
            voting.Vote = 1;

            VotingController votingController = new VotingController();
            votingController.voting(voting, this);
        }

        private void imgCawapres1_Click(object sender, EventArgs e)
        {
            Voting voting = new Voting();
            voting.UserID = userid;
            voting.TPSID = tpsid;
            voting.Vote = 1;

            VotingController votingController = new VotingController();
            votingController.voting(voting, this);
        }

        private void lblCapres1_Click(object sender, EventArgs e)
        {
            Voting voting = new Voting();
            voting.UserID = userid;
            voting.TPSID = tpsid;
            voting.Vote = 1;

            VotingController votingController = new VotingController();
            votingController.voting(voting, this);
        }
        private void lblCawapres1_Click(object sender, EventArgs e)
        {
            Voting voting = new Voting();
            voting.UserID = userid;
            voting.TPSID = tpsid;
            voting.Vote = 1;

            VotingController votingController = new VotingController();
            votingController.voting(voting, this);
        }

        private void imgCapres2_Click(object sender, EventArgs e)
        {
            Voting voting = new Voting();
            voting.UserID = userid;
            voting.TPSID = tpsid;
            voting.Vote = 2;

            VotingController votingController = new VotingController();
            votingController.voting(voting, this);
        }

        private void imgCawapres2_Click(object sender, EventArgs e)
        {
            Voting voting = new Voting();
            voting.UserID = userid;
            voting.TPSID = tpsid;
            voting.Vote = 2;

            VotingController votingController = new VotingController();
            votingController.voting(voting, this);
        }

        private void lblCapres2_Click(object sender, EventArgs e)
        {
            Voting voting = new Voting();
            voting.UserID = userid;
            voting.TPSID = tpsid;
            voting.Vote = 2;

            VotingController votingController = new VotingController();
            votingController.voting(voting, this);
        }

        private void lblCawapres2_Click(object sender, EventArgs e)
        {
            Voting voting = new Voting();
            voting.UserID = userid;
            voting.TPSID = tpsid;
            voting.Vote = 2;

            VotingController votingController = new VotingController();
            votingController.voting(voting, this);
        }

        private void imgCapres3_Click(object sender, EventArgs e)
        {
            Voting voting = new Voting();
            voting.UserID = userid;
            voting.TPSID = tpsid;
            voting.Vote = 3;

            VotingController votingController = new VotingController();
            votingController.voting(voting, this);
        }

        private void imgCawapres3_Click(object sender, EventArgs e)
        {
            Voting voting = new Voting();
            voting.UserID = userid;
            voting.TPSID = tpsid;
            voting.Vote = 3;

            VotingController votingController = new VotingController();
            votingController.voting(voting, this);
        }

        private void lblCapres3_Click(object sender, EventArgs e)
        {
            Voting voting = new Voting();
            voting.UserID = userid;
            voting.TPSID = tpsid;
            voting.Vote = 3;

            VotingController votingController = new VotingController();
            votingController.voting(voting, this);
        }

        private void lblCawapres3_Click(object sender, EventArgs e)
        {
            Voting voting = new Voting();
            voting.UserID = userid;
            voting.TPSID = tpsid;
            voting.Vote = 3;

            VotingController votingController = new VotingController();
            votingController.voting(voting, this);
        }

        public frmVoting(int userID, string noKTP, int tpsID)
        {
            InitializeComponent();
            labelDataPemilih.Text = $"UserID: {userID}, No. KTP: {noKTP}, TPS ID: {tpsID}";
            userid = userID;
            tpsid = tpsID;
            noktp = noKTP;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Voting voting = new Voting();
            voting.UserID = userid;
            voting.TPSID = tpsid;
            voting.Vote = 1;

            VotingController votingController = new VotingController();
            votingController.voting(voting, this);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Voting voting = new Voting();
            voting.UserID = userid;
            voting.TPSID = tpsid;
            voting.Vote = 2;

            VotingController votingController = new VotingController();
            votingController.voting(voting, this);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Voting voting = new Voting();
            voting.UserID = userid;
            voting.TPSID = tpsid;
            voting.Vote = 3;

            VotingController votingController = new VotingController();
            votingController.voting(voting, this);
        }

        private void frmVoting_Load(object sender, EventArgs e)
        {
            VotingController votingController = new VotingController();
            votingController.LoadCandidatesFromDatabase(this);
        }
    }
}
