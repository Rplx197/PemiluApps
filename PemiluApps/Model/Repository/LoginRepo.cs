using PemiluApps.Model.Context;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PemiluApps.Model.Repository
{
    public class LoginRepo
    {
        private SqlConnection _conn;

        public LoginRepo(DBContext context)
        {
            _conn = context.Conn;
        }

        public void Login(TextBox NoKTP, TextBox Password, Form form)
        {
            string noKTP = NoKTP.Text;
            string password = Password.Text;

            // Login for regular users
            string queryUser = "SELECT * FROM tbUser WHERE No_KTP = @noktp AND Password = @password";
            using (SqlCommand commandUser = new SqlCommand(queryUser, _conn))
            {
                commandUser.Parameters.AddWithValue("@noktp", noKTP);
                commandUser.Parameters.AddWithValue("@password", password);

                using (SqlDataReader readerUser = commandUser.ExecuteReader())
                {
                    if (readerUser.Read())
                    {
                        string status = readerUser["Status"].ToString();
                        int userID = GetUserID(noKTP, password);

                        // Checking user status
                        if (status == "B")
                        {
                            string userNoKTP = GetNoKTP(userID);
                            int tpsID = GetTPSID(userID);

                            frmVoting frmVoting = new frmVoting(userID, userNoKTP, tpsID);
                            frmVoting.ShowDialog();
                            form.Hide();
                        }
                        else if (status == "S")
                        {
                            MessageBox.Show("Maaf, Anda sudah memakai hak pilih Anda.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            MessageBox.Show("Maaf, status pengguna tidak valid.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        // Login for officers
                        string queryOfficer = "SELECT * FROM tbTPS WHERE TPSID + Name_TPS = @username AND Officer_TPS = @officername";

                        using (SqlCommand commandOfficer = new SqlCommand(queryOfficer, _conn))
                        {
                            commandOfficer.Parameters.AddWithValue("@username", noKTP);
                            commandOfficer.Parameters.AddWithValue("@officername", password);

                            using (SqlDataReader readerOfficer = commandOfficer.ExecuteReader())
                            {
                                if (readerOfficer.Read())
                                {
                                    frmOfficer frmOfficer = new frmOfficer();
                                    frmOfficer.Show();
                                    form.Hide();
                                }
                                else
                                {
                                    MessageBox.Show("Login Gagal. Periksa kembali username dan password Anda.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                    }
                }
            }
        }

        public int GetUserID(string username, string password)
        {
            int userID = -1;

            using (SqlConnection connection = new SqlConnection(@"Data Source=MSI;Initial Catalog=Pemilu;Integrated Security=True"))
            {
                connection.Open();

                string query = "SELECT UserID FROM tbUser WHERE No_KTP = @noktp AND Password = @password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@noktp", username);
                    command.Parameters.AddWithValue("@password", password);

                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        userID = Convert.ToInt32(result);
                    }
                }
            }
            return userID;
        }

        public string GetNoKTP(int userID)
        {
            string noKTP = "";

            using (SqlConnection connection = new SqlConnection(@"Data Source=MSI;Initial Catalog=Pemilu;Integrated Security=True"))
            {
                connection.Open();

                string query = "SELECT No_KTP FROM tbUser WHERE UserID = @UserID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userID);

                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        noKTP = result.ToString();
                    }
                }
            }
            return noKTP;
        }

        public int GetTPSID(int userID)
        {
            int tpsID = -1;

            using (SqlConnection connection = new SqlConnection(@"Data Source=MSI;Initial Catalog=Pemilu;Integrated Security=True"))
            {
                connection.Open();

                string query = "SELECT TPSID FROM tbUser WHERE UserID = @UserID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userID);

                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        tpsID = Convert.ToInt32(result);
                    }
                }
            }
            return tpsID;
        }
    }
}
