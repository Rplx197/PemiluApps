using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PemiluApps.Model.Context
{
    public class DBContext : IDisposable
    {
        private SqlConnection _conn;
        
        public SqlConnection Conn
        {
            get { return _conn ?? (_conn = GetOpenConnection()); }
        }
        private SqlConnection GetOpenConnection()
        {
            SqlConnection conn = null; 
            try 
            {
                string connectionString = @"Data Source=MSI;Initial Catalog=Pemilu;Integrated Security=True;MultipleActiveResultSets=true";
                conn = new SqlConnection(connectionString); 
                conn.Open();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("Open Connection Error: {0}", ex.Message);
            }
            return conn;
        }

        public void Dispose()
        {
            if (_conn != null)
            {
                try
                {
                    if (_conn.State != ConnectionState.Closed) _conn.Close();
                }
                finally
                {
                    _conn.Dispose();
                }
            }
            GC.SuppressFinalize(this);
        }
    }
}
