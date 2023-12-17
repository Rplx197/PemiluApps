using PemiluApps.Model.Context;
using PemiluApps.Model.Entity;
using PemiluApps.Model.Repository;
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
    public class TPSController
    {
        private TPSRepo _repo;

        public int Insert(TPS tps, DataGridView dataGrid)
        {
            int result = 0;
            if (string.IsNullOrEmpty(tps.TPSID))
            {
                MessageBox.Show("TPSID harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(tps.Name_TPS))
            {
                MessageBox.Show("Nama harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(tps.Officer_TPS))
            {
                MessageBox.Show("Officer harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            using (DBContext context = new DBContext())
            {
                int idToAdd = int.Parse(tps.TPSID);
                _repo = new TPSRepo(context);

                if (_repo.IsIDExists(idToAdd))
                {
                    MessageBox.Show("ID sudah ada dalam database. Silakan gunakan ID yang berbeda.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    _repo.Insert(tps);
                    _repo.RefreshData(dataGrid);
                }
            }
            return result;
        }

        public int Update(TPS tps, DataGridView dataGrid)
        {
            int result = 0;
            if (string.IsNullOrEmpty(tps.TPSID))
            {
                MessageBox.Show("TPSID harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(tps.Name_TPS))
            {
                MessageBox.Show("Nama harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(tps.Officer_TPS))
            {
                MessageBox.Show("Officer harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            using (DBContext context = new DBContext())
            {
                _repo = new TPSRepo(context);
                result = _repo.Update(tps);
                _repo.RefreshData(dataGrid);
            }
            return result;
        }

        public int Delete(TPS tps, DataGridView dataGrid)
        {
            int result = 0;
            if (string.IsNullOrEmpty(tps.TPSID))
            {
                MessageBox.Show("TPSID harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            using (DBContext context = new DBContext())
            {
                _repo = new TPSRepo(context);
                result = _repo.Delete(tps);
                _repo.RefreshData(dataGrid);
            }
            return result;
        }

        private DataTable GetTPSID(string tpsId)
        {
            DataTable dataTabel = new DataTable();

            try
            {
                string connectionString = "Data Source=MSI;Initial Catalog=Pemilu;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM tbTPS WHERE TPSID = @tpsid";
                    using (SqlCommand perintah = new SqlCommand(query, connection))
                    {
                        perintah.Parameters.AddWithValue("@tpsid", tpsId);

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
                DataTable dataTpsIdTable = GetTPSID(textBox.Text);

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

        public void ClearData(TextBox txtID, TextBox txtNama, TextBox txtPetugas)
        {
            txtID.Text = "";
            txtNama.Text = "";
            txtPetugas.Text = "";
        }

        public void grdClick(DataGridViewCellEventArgs e, DataGridView dataGrid, TextBox txtID, TextBox txtNama, TextBox txtPetugas)
        {
            if (e.RowIndex >= 0)
            {
                // Mengambil nilai dari sel pada baris yang diklik
                DataGridViewRow row = dataGrid.Rows[e.RowIndex];
                string nilaiTpsid = row.Cells["TPSID"].Value.ToString();
                string nilaiName = row.Cells["Name_TPS"].Value.ToString();
                string nilaiOfficer = row.Cells["Officer_TPS"].Value.ToString();

                // Menampilkan nilai pada TextBox (TextView)
                txtID.Text = nilaiTpsid;
                txtNama.Text = nilaiName;
                txtPetugas.Text = nilaiOfficer;
            }
        }
    }
}
