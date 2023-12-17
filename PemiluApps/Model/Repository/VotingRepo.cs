using PemiluApps.Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PemiluApps.Model.Entity;
using PemiluApps.Model.Context;

namespace PemiluApps.Model.Repository
{
    public class VotingRepo
    {
        private SqlConnection _conn;

        public VotingRepo(DBContext context)
        {
            _conn = context.Conn;
        }

        public int Insert(Voting voting)
        {
            int result = 0;

            string query = "INSERT INTO [tbLogVoting] (Date_Log, CandidateID, UserID, Place_Log) VALUES (@datelog, @candidateid, @userid, @placelog)";
            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                command.Parameters.AddWithValue("@datelog", DateTime.Now);
                command.Parameters.AddWithValue("@candidateid", voting.Vote);
                command.Parameters.AddWithValue("@userid", voting.UserID);
                command.Parameters.AddWithValue("@placelog", voting.TPSID);
                command.ExecuteNonQuery();
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

        public int Update(Voting voting)
        {
            int result = 0;

            string query = "UPDATE [tbUser] SET Status = @status WHERE UserID = @ID";
            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                command.Parameters.AddWithValue("@status", "S");
                command.Parameters.AddWithValue("@ID", voting.UserID);
                command.ExecuteNonQuery();
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
