using PemiluApps.Model.Context;
using PemiluApps.Model.Entity;
using PemiluApps.Model.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PemiluApps.Controller
{
    public class UserController
    { 
        private UserRepo _repo;

        public int Insert(User user, DataGridView dataGrid)
        {
            int result = 0;
            if (string.IsNullOrEmpty(user.UserID))
            {
                MessageBox.Show("UserID harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(user.No_KTP))
            {
                MessageBox.Show("No KTP harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(user.Password))
            {
                MessageBox.Show("Password harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(user.TPSID))
            {
                MessageBox.Show("TPSID harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            using (DBContext context = new DBContext())
            {
                int idToAdd = int.Parse(user.UserID);
                _repo = new UserRepo(context);

                if (_repo.IsIDExists(idToAdd))
                {
                    MessageBox.Show("ID sudah ada dalam database. Silakan gunakan ID yang berbeda.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    result = _repo.Insert(user);
                    _repo.RefreshData(dataGrid);
                }
            }
            return result;
        }

        public int Update(User user, DataGridView dataGrid)
        {
            int result = 0;
            if (string.IsNullOrEmpty(user.UserID))
            {
                MessageBox.Show("UserID harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(user.No_KTP))
            {
                MessageBox.Show("No KTP harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(user.Password))
            {
                MessageBox.Show("Password harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(user.TPSID))
            {
                MessageBox.Show("TPSID harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            using (DBContext context = new DBContext())
            {
                _repo = new UserRepo(context);
                result = _repo.Update(user);
                _repo.RefreshData(dataGrid);
            }
            return result;
        }

        public int Delete(User user, DataGridView dataGrid)
        {
            int result = 0;
            if (string.IsNullOrEmpty(user.UserID))
            {
                MessageBox.Show("UserID harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            using (DBContext context = new DBContext())
            {
                _repo = new UserRepo(context);
                result = _repo.Delete(user);
                _repo.RefreshData(dataGrid);
            }
            return result;
        }

        private DataTable GetNoKTP(string noKtp)
        {
            DataTable dataTabel = new DataTable();

            try
            {
                string connectionString = "Data Source=MSI;Initial Catalog=Pemilu;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM tbUser WHERE No_KTP = @noktp";
                    using (SqlCommand perintah = new SqlCommand(query, connection))
                    {
                        perintah.Parameters.AddWithValue("@noktp", noKtp);

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
                DataTable dataTpsIdTable = GetNoKTP(textBox.Text);

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

        public void ClearData(TextBox txtID, TextBox txtNoKtp, TextBox txtPassword, TextBox txtTps)
        {
            txtID.Text = "";
            txtNoKtp.Text = "";
            txtPassword.Text = "";
            txtTps.Text = "";
        }

        public void grdClick(DataGridViewCellEventArgs e, DataGridView dataGrid, TextBox txtID, TextBox txtNoKtp, TextBox txtPassword, TextBox txtTps)
        {
            if (e.RowIndex >= 0)
            {
                // Mengambil nilai dari sel pada baris yang diklik
                DataGridViewRow row = dataGrid.Rows[e.RowIndex];
                string nilaiUserId = row.Cells["UserID"].Value.ToString();
                string nilaiNoKtp = row.Cells["No_KTP"].Value.ToString();
                string nilaiPassword = row.Cells["Password"].Value.ToString();
                string nilaiTpsId = row.Cells["TPSID"].Value.ToString();

                // Menampilkan nilai pada TextBox (TextView)
                txtID.Text = nilaiUserId;
                txtNoKtp.Text = nilaiNoKtp;
                txtPassword.Text = nilaiPassword;
                txtTps.Text = nilaiTpsId;
            }
        }

        public string GeneratePassword(int length)
        {
            const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            char[] password = new char[length];

            for (int i = 0; i < length; i++)
            {
                password[i] = characters[random.Next(characters.Length)];
            }

            return new string(password);
        }
    }
}
