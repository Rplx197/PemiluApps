namespace PemiluApps
{
    partial class frmOfficer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnManageUserDetail = new System.Windows.Forms.Button();
            this.btnManageTPS = new System.Windows.Forms.Button();
            this.btnVotingResullt = new System.Windows.Forms.Button();
            this.btnManageUser = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnManageUserDetail
            // 
            this.btnManageUserDetail.Location = new System.Drawing.Point(79, 27);
            this.btnManageUserDetail.Name = "btnManageUserDetail";
            this.btnManageUserDetail.Size = new System.Drawing.Size(116, 61);
            this.btnManageUserDetail.TabIndex = 0;
            this.btnManageUserDetail.Text = "Manage User Detail";
            this.btnManageUserDetail.UseVisualStyleBackColor = true;
            this.btnManageUserDetail.Click += new System.EventHandler(this.btnManageUserDetail_Click);
            // 
            // btnManageTPS
            // 
            this.btnManageTPS.Location = new System.Drawing.Point(79, 140);
            this.btnManageTPS.Name = "btnManageTPS";
            this.btnManageTPS.Size = new System.Drawing.Size(116, 40);
            this.btnManageTPS.TabIndex = 1;
            this.btnManageTPS.Text = "Manage TPS";
            this.btnManageTPS.UseVisualStyleBackColor = true;
            this.btnManageTPS.Click += new System.EventHandler(this.btnManageTPS_Click);
            // 
            // btnVotingResullt
            // 
            this.btnVotingResullt.Location = new System.Drawing.Point(79, 186);
            this.btnVotingResullt.Name = "btnVotingResullt";
            this.btnVotingResullt.Size = new System.Drawing.Size(116, 40);
            this.btnVotingResullt.TabIndex = 2;
            this.btnVotingResullt.Text = "Voting Result";
            this.btnVotingResullt.UseVisualStyleBackColor = true;
            this.btnVotingResullt.Click += new System.EventHandler(this.btnVotingResullt_Click);
            // 
            // btnManageUser
            // 
            this.btnManageUser.Location = new System.Drawing.Point(79, 94);
            this.btnManageUser.Name = "btnManageUser";
            this.btnManageUser.Size = new System.Drawing.Size(116, 40);
            this.btnManageUser.TabIndex = 3;
            this.btnManageUser.Text = "Manage User";
            this.btnManageUser.UseVisualStyleBackColor = true;
            this.btnManageUser.Click += new System.EventHandler(this.btnManageUser_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(217, 241);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmOfficer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 276);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnManageUser);
            this.Controls.Add(this.btnVotingResullt);
            this.Controls.Add(this.btnManageTPS);
            this.Controls.Add(this.btnManageUserDetail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmOfficer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form Officer";
            this.Load += new System.EventHandler(this.frmOfficer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnManageUserDetail;
        private System.Windows.Forms.Button btnManageTPS;
        private System.Windows.Forms.Button btnVotingResullt;
        private System.Windows.Forms.Button btnManageUser;
        private System.Windows.Forms.Button btnExit;
    }
}