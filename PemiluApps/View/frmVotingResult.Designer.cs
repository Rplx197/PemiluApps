namespace PemiluApps
{
    partial class frmVotingResult
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label10 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.grdVotingResult = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblCandidate1 = new System.Windows.Forms.Label();
            this.lblCandidate2 = new System.Windows.Forms.Label();
            this.lblCandidate3 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.grdVotingResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(259, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(219, 29);
            this.label10.TabIndex = 44;
            this.label10.Text = "VOTING RESULT";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(614, 49);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(124, 23);
            this.btnRefresh.TabIndex = 57;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(663, 583);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 58;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // grdVotingResult
            // 
            this.grdVotingResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdVotingResult.Location = new System.Drawing.Point(12, 78);
            this.grdVotingResult.Name = "grdVotingResult";
            this.grdVotingResult.RowHeadersWidth = 51;
            this.grdVotingResult.RowTemplate.Height = 24;
            this.grdVotingResult.Size = new System.Drawing.Size(726, 297);
            this.grdVotingResult.TabIndex = 59;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 16);
            this.label1.TabIndex = 60;
            this.label1.Text = "User ID";
            // 
            // txtSearch
            // 
            this.txtSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtSearch.Location = new System.Drawing.Point(72, 49);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(406, 22);
            this.txtSearch.TabIndex = 61;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(484, 49);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(124, 23);
            this.btnSearch.TabIndex = 62;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblCandidate1
            // 
            this.lblCandidate1.AutoSize = true;
            this.lblCandidate1.Location = new System.Drawing.Point(383, 466);
            this.lblCandidate1.Name = "lblCandidate1";
            this.lblCandidate1.Size = new System.Drawing.Size(150, 16);
            this.lblCandidate1.TabIndex = 63;
            this.lblCandidate1.Text = "Total Vote Candidate 1 :";
            // 
            // lblCandidate2
            // 
            this.lblCandidate2.AutoSize = true;
            this.lblCandidate2.Location = new System.Drawing.Point(383, 432);
            this.lblCandidate2.Name = "lblCandidate2";
            this.lblCandidate2.Size = new System.Drawing.Size(150, 16);
            this.lblCandidate2.TabIndex = 64;
            this.lblCandidate2.Text = "Total Vote Candidate 2 :";
            // 
            // lblCandidate3
            // 
            this.lblCandidate3.AutoSize = true;
            this.lblCandidate3.Location = new System.Drawing.Point(383, 397);
            this.lblCandidate3.Name = "lblCandidate3";
            this.lblCandidate3.Size = new System.Drawing.Size(150, 16);
            this.lblCandidate3.TabIndex = 65;
            this.lblCandidate3.Text = "Total Vote Candidate 3 :";
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(12, 381);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(365, 225);
            this.chart1.TabIndex = 66;
            this.chart1.Text = "chart1";
            // 
            // frmVotingResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 618);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.lblCandidate3);
            this.Controls.Add(this.lblCandidate2);
            this.Controls.Add(this.lblCandidate1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grdVotingResult);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label10);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmVotingResult";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form Voting Result";
            this.Load += new System.EventHandler(this.frmVotingResult_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdVotingResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView grdVotingResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblCandidate1;
        private System.Windows.Forms.Label lblCandidate2;
        private System.Windows.Forms.Label lblCandidate3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}