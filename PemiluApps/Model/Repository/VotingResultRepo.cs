using PemiluApps.Model.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PemiluApps.Model.Repository
{
    public class VotingResultRepo
    {
        public void RefreshData(DataGridView dataGrid)
        {
            try
            {
                string connectionString = "Data Source=MSI;Initial Catalog=Pemilu;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM tbLogVoting";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    connection.Close();
                    dataGrid.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        public void ShowChart(Chart chart)
        {
            try
            {
                string connectionString = "Data Source=MSI;Initial Catalog=Pemilu;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT CandidateID, COUNT(*) AS VoteCount FROM tbLogVoting GROUP BY CandidateID";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        chart.Series.Clear();
                        chart.Series.Add("Votes");
                        chart.Series["Votes"].ChartType = SeriesChartType.Bar;
                        chart.Series["Votes"].XValueMember = "CandidateId";
                        chart.Series["Votes"].YValueMembers = "VoteCount";
                        chart.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
