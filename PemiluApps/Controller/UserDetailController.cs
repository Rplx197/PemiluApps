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
    public class UserDetailController
    {
        private UserDetailRepo _repo;

        public int Insert(UserDetail userdetail, DataGridView dataGrid)
        {
            int result = 0;
            if (string.IsNullOrEmpty(userdetail.No_KTP))
            {
                MessageBox.Show("NO KTP harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(userdetail.Name_User))
            {
                MessageBox.Show("Nama harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(userdetail.Address_User))
            {
                MessageBox.Show("Address harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(userdetail.Gender_User))
            {
                MessageBox.Show("Address harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(userdetail.DateOfBorn_User))
            {
                MessageBox.Show("Date Of Born harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(userdetail.Religion_User))
            {
                MessageBox.Show("Religion harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(userdetail.Married))
            {
                MessageBox.Show("Married harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(userdetail.Job_User))
            {
                MessageBox.Show("Married harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(userdetail.Nationality_User))
            {
                MessageBox.Show("Nationality harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            using (DBContext context = new DBContext())
            {
                int idToAdd = int.Parse(userdetail.No_KTP);
                _repo = new UserDetailRepo(context);

                if (_repo.IsIDExists(idToAdd))
                {
                    MessageBox.Show("ID sudah ada dalam database. Silakan gunakan ID yang berbeda.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    result = _repo.Insert(userdetail);
                    _repo.RefreshData(dataGrid);
                }
            }
            return result;
        }

        public int Update(UserDetail userdetail, DataGridView dataGrid)
        {
            int result = 0;
            if (string.IsNullOrEmpty(userdetail.No_KTP))
            {
                MessageBox.Show("NO KTP harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(userdetail.Name_User))
            {
                MessageBox.Show("Nama harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(userdetail.Address_User))
            {
                MessageBox.Show("Address harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(userdetail.Gender_User))
            {
                MessageBox.Show("Address harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(userdetail.DateOfBorn_User))
            {
                MessageBox.Show("Date Of Born harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(userdetail.Religion_User))
            {
                MessageBox.Show("Religion harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(userdetail.Married))
            {
                MessageBox.Show("Married harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(userdetail.Job_User))
            {
                MessageBox.Show("Married harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(userdetail.Nationality_User))
            {
                MessageBox.Show("Nationality harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            using (DBContext context = new DBContext())
            {
                _repo = new UserDetailRepo(context);
                result = _repo.Update(userdetail);
                _repo.RefreshData(dataGrid);
            }
            return result;
        }

        public int Delete(UserDetail userdetail, DataGridView dataGrid)
        {
            int result = 0;
            if (string.IsNullOrEmpty(userdetail.No_KTP))
            {
                MessageBox.Show("UserID harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            using (DBContext context = new DBContext())
            {
                _repo = new UserDetailRepo(context);
                result = _repo.Delete(userdetail);
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
                    string query = "SELECT * FROM tbUserDetail WHERE No_KTP = @noktp";
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

        public void ClearData(TextBox txtNoKtp, TextBox txtNama, RichTextBox txtAlamat, ComboBox cmbKelamin
            , DateTimePicker dtpTanggalLahir, ComboBox cmbAgama, ComboBox cmbStatusMenikah, TextBox txtPekerjaan
            , ComboBox cmbKewarganegaraan)
        {
            txtNoKtp.Clear();
            txtNama.Clear();
            txtAlamat.Clear();
            cmbKelamin.Text = "";
            dtpTanggalLahir.Value = new DateTime(2001, 10, 21);
            cmbAgama.Text = "";
            cmbStatusMenikah.Text = "";
            txtPekerjaan.Clear();
            cmbKewarganegaraan.Text = "";
        }

        public void grdClick(DataGridViewCellEventArgs e, DataGridView dataGrid, TextBox txtNoKtp, TextBox txtNama, RichTextBox txtAlamat, ComboBox cmbKelamin
            , DateTimePicker dtpTanggalLahir, ComboBox cmbAgama, ComboBox cmbStatusMenikah, TextBox txtPekerjaan
            , ComboBox cmbKewarganegaraan)
        {
            if (e.RowIndex >= 0)
            {
                // Mengambil nilai dari sel pada baris yang diklik
                DataGridViewRow row = dataGrid.Rows[e.RowIndex];
                string nilaiNoKtp = row.Cells["No_KTP"].Value.ToString();
                string nilaiNama = row.Cells["Name_User"].Value.ToString();
                string nilaiAlamat = row.Cells["Address_User"].Value.ToString();
                string nilaiKelamin = row.Cells["Gender_User"].Value.ToString();
                string nilaiTanggalLahir = row.Cells["DateOfBorn_User"].Value.ToString();
                string nilaiAgama = row.Cells["Religion_User"].Value.ToString();
                string nilaiStatusPernikahan = row.Cells["Married"].Value.ToString();
                string nilaiPekerjaan = row.Cells["Job_User"].Value.ToString();
                string nilaiKewarganegaraan = row.Cells["Nationality_User"].Value.ToString();

                // Menampilkan nilai pada TextBox (TextView)
                txtNoKtp.Text = nilaiNoKtp;
                txtNama.Text = nilaiNama;
                txtAlamat.Text = nilaiAlamat;
                cmbKelamin.Text = nilaiKelamin;
                dtpTanggalLahir.Text = nilaiTanggalLahir;
                cmbAgama.Text = nilaiAgama;
                cmbStatusMenikah.Text = nilaiStatusPernikahan;
                txtPekerjaan.Text = nilaiPekerjaan;
                cmbKewarganegaraan.Text = nilaiKewarganegaraan;
            }
        }
    }
}
