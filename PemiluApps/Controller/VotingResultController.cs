using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PemiluApps.Controller
{
    public class VotingResultController
    {
        private DataTable GetUserID(string userId)
        {
            DataTable dataTabel = new DataTable();

            try
            {
                string connectionString = "Data Source=MSI;Initial Catalog=Pemilu;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM tbLogVoting WHERE UserID = @userId";
                    using (SqlCommand perintah = new SqlCommand(query, connection))
                    {
                        perintah.Parameters.AddWithValue("@userid", userId);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(perintah))
                        {
                            adapter.Fill(dataTabel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dataTabel;
        }

        public void Search(TextBox textBox, DataGridView dataGrid)
        {
            if (!string.IsNullOrEmpty(textBox.Text))
            {
                // Masukkan data dari fungsi GetUserID
                DataTable dataTpsIdTable = GetUserID(textBox.Text);

                // Menampilkan hasilnya di DataGridView
                dataGrid.DataSource = dataTpsIdTable;

                if (dataTpsIdTable.Rows.Count == 0)
                {
                    MessageBox.Show("Pengguna tidak ditemukan.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Silakan masukkan TPSID untuk dicari.", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void IsiLabelTotalSuara(Label lblCandidate1, Label lblCandidate2, Label lblCandidate3)
        {
            try
            {
                string connectionString = "Data Source=MSI;Initial Catalog=Pemilu;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string queryCandidate1 = "SELECT COUNT(*) FROM tbLogVoting WHERE CandidateID = 1";
                    using (SqlCommand commandCandidate1 = new SqlCommand(queryCandidate1, connection))
                    {
                        int jumlahSuaraCandidate1 = (int)commandCandidate1.ExecuteScalar();
                        lblCandidate1.Text = $"Total Suara Candidate 1: {jumlahSuaraCandidate1}";
                    }

                    string queryCandidate2 = "SELECT COUNT(*) FROM tbLogVoting WHERE CandidateID = 2";
                    using (SqlCommand commandCandidate2 = new SqlCommand(queryCandidate2, connection))
                    {
                        int jumlahSuaraCandidate2 = (int)commandCandidate2.ExecuteScalar();
                        lblCandidate2.Text = $"Total Suara Candidate 2: {jumlahSuaraCandidate2}";
                    }

                    string queryCandidate3 = "SELECT COUNT(*) FROM tbLogVoting WHERE CandidateID = 3";
                    using (SqlCommand commandCandidate3 = new SqlCommand(queryCandidate3, connection))
                    {
                        int jumlahSuaraCandidate3 = (int)commandCandidate3.ExecuteScalar();
                        lblCandidate3.Text = $"Total Suara Candidate 3: {jumlahSuaraCandidate3}";
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
