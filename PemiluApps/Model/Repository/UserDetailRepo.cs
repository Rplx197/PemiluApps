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
    public class UserDetailRepo
    {
        private SqlConnection _conn;

        public UserDetailRepo(DBContext context)
        {
            _conn = context.Conn;
        }

        public bool IsIDExists(int id)
        {
            using (DBContext context = new DBContext())
            {
                string query = "SELECT COUNT(*) FROM [tbUserDetail] WHERE No_KTP = @ID";
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
                    string query = "SELECT * FROM tbUserDetail";
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

        public int Insert(UserDetail userdetail)
        {
            int result = 0;
            string sql = @"INSERT INTO [tbUserDetail] (No_KTP, Name_User, Address_User, Gender_User, DateOfBorn_User, Religion_User, Married, Job_User, Nationality_User)
                            VALUES (@noktp, @name, @address, @gender, @dateofborn, @religion, @married, @job, @nationality)";
            using (SqlCommand command = new SqlCommand(sql, _conn))
            {
                command.Parameters.AddWithValue("@noktp", userdetail.No_KTP);
                command.Parameters.AddWithValue("@name", userdetail.Name_User);
                command.Parameters.AddWithValue("@address", userdetail.Address_User);
                command.Parameters.AddWithValue("@gender", userdetail.Gender_User);
                command.Parameters.AddWithValue("@dateofborn", userdetail.DateOfBorn_User);
                command.Parameters.AddWithValue("@religion", userdetail.Religion_User);
                command.Parameters.AddWithValue("@married", userdetail.Married);
                command.Parameters.AddWithValue("@job", userdetail.Job_User);
                command.Parameters.AddWithValue("@nationality", userdetail.Nationality_User);
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

        public int Update(UserDetail userdetail)
        {
            int result = 0;
            string sql = @"UPDATE [tbUserDetail] SET No_KTP = @noktp, Name_User = @name, Address_User = @address, Gender_User = @gender, 
DateOfBorn_User = @dateofborn, Religion_User = @religion, Married = @married, Job_User = @job, Nationality_User = @nationality WHERE No_KTP = @noktp";
            using (SqlCommand command = new SqlCommand(sql, _conn))
            {
                command.Parameters.AddWithValue("@noktp", userdetail.No_KTP);
                command.Parameters.AddWithValue("@name", userdetail.Name_User);
                command.Parameters.AddWithValue("@address", userdetail.Address_User);
                command.Parameters.AddWithValue("@gender", userdetail.Gender_User);
                command.Parameters.AddWithValue("@dateofborn", userdetail.DateOfBorn_User);
                command.Parameters.AddWithValue("@religion", userdetail.Religion_User);
                command.Parameters.AddWithValue("@married", userdetail.Married);
                command.Parameters.AddWithValue("@job", userdetail.Job_User);
                command.Parameters.AddWithValue("@nationality", userdetail.Nationality_User);
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

        public int Delete(UserDetail userdetail)
        {
            int result = 0;
            string sql = @"DELETE FROM [tbUserDetail] WHERE No_KTP = @noktp";
            using (SqlCommand command = new SqlCommand(sql, _conn))
            {
                command.Parameters.AddWithValue("@noktp", userdetail.No_KTP);
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
