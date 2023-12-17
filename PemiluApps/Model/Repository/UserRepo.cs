using PemiluApps.Model.Context;
using PemiluApps.Model.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PemiluApps.Model.Repository
{
    public class UserRepo
    {
        private SqlConnection _conn;

        public UserRepo(DBContext context)
        {
            _conn = context.Conn;
        }

        public bool IsIDExists(int id)
        {
            using (DBContext context = new DBContext())
            {
                string query = "SELECT COUNT(*) FROM [tbUser] WHERE UserID = @ID";
                SqlCommand command = new SqlCommand(query, context.Conn);
                command.Parameters.AddWithValue("@ID", id);
                int count = (int)command.ExecuteScalar();

                return count > 0;
            }
        }

        public void RefreshData(DataGridView dataGrid)
        {
            try
            {
                string connectionString = "Data Source=MSI;Initial Catalog=Pemilu;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM tbUser";
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

        public int Insert(User user)
        {
            int result = 0;

            string sql = @"INSERT INTO [tbUser] (UserID, No_KTP, Password, TPSID, Status) VALUES (@userid, @noktp, @password, @tpsid, @status)";
            using (SqlCommand command = new SqlCommand(sql, _conn))
            {
                command.Parameters.AddWithValue("@userid", user.UserID);
                command.Parameters.AddWithValue("@noktp", user.No_KTP);
                command.Parameters.AddWithValue("@password", user.Password);
                command.Parameters.AddWithValue("@tpsid", user.TPSID);
                command.Parameters.AddWithValue("@status", user.Status);
                try
                {
                    result = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return result;
        }

        public int Update(User user)
        {
            int result = 0;
            string sql = @"UPDATE [tbUser] SET UserID = @userid, No_KTP = @noktp, Password = @password, TPSID = @tpsid WHERE UserID = @userid";
            using (SqlCommand command = new SqlCommand(sql, _conn))
            {
                command.Parameters.AddWithValue("@userid", user.UserID);
                command.Parameters.AddWithValue("@noktp", user.No_KTP);
                command.Parameters.AddWithValue("@password", user.Password);
                command.Parameters.AddWithValue("@tpsid", user.TPSID);
                try
                {
                    result = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return result;
        }

        public int Delete(User user)
        {
            int result = 0;
            string sql = @"DELETE FROM [tbUser] WHERE UserID = @userid";
            using (SqlCommand command = new SqlCommand(sql, _conn))
            {
                command.Parameters.AddWithValue("@userid", user.UserID);
                try
                {
                    result = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return result;
        }
    }
}
