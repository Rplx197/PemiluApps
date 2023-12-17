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
    public class TPSRepo
    {
        private SqlConnection _conn;

        public TPSRepo(DBContext context)
        {
            _conn = context.Conn;
        }

        public bool IsIDExists(int id)
        {
            using (DBContext context = new DBContext())
            {
                string query = "SELECT COUNT(*) FROM [tbTPS] WHERE TPSID = @ID";
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
                    string query = "SELECT * FROM tbTPS";
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

        public int Insert(TPS tps)
        {
            int result = 0;

            string sql = @"INSERT INTO [tbTPS] (TPSID, Name_TPS, Officer_TPS) VALUES (@tpsid, @name, @officer)";
            using (SqlCommand command = new SqlCommand(sql, _conn))
            {
                command.Parameters.AddWithValue("@tpsid", tps.TPSID);
                command.Parameters.AddWithValue("@name", tps.Name_TPS);
                command.Parameters.AddWithValue("@officer", tps.Officer_TPS);
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

        public int Update(TPS tps)
        {
            int result = 0;
            string sql = @"UPDATE [tbTPS] SET TPSID = @tpsid, Name_TPS = @name, Officer_TPS = @officer WHERE TPSID = @tpsid";
            using (SqlCommand command = new SqlCommand(sql, _conn))
            {
                command.Parameters.AddWithValue("@tpsid", tps.TPSID);
                command.Parameters.AddWithValue("@name", tps.Name_TPS);
                command.Parameters.AddWithValue("@officer", tps.Officer_TPS);
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

        public int Delete(TPS tps)
        {
            int result = 0;
            string sql = @"DELETE FROM [tbTPS] WHERE TPSID = @tpsid";
            using (SqlCommand command = new SqlCommand(sql, _conn))
            {
                command.Parameters.AddWithValue("@tpsid", tps.TPSID);
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
