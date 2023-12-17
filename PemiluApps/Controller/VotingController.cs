using PemiluApps.Model.Context;
using PemiluApps.Model.Entity;
using PemiluApps.Model.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PemiluApps.Controller
{
    public class VotingController
    {
        private VotingRepo _repo;
        public void voting(Voting voting, Form form)
        {
            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin memberikan suara untuk kandidat ini?", "Konfirmasi Voting", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                using (DBContext context = new DBContext())
                {
                    _repo = new VotingRepo(context);
                    _repo.Insert(voting);
                }
                using (DBContext context = new DBContext())
                {
                    _repo = new VotingRepo(context);
                    _repo.Update(voting);

                }

                MessageBox.Show("Berhasil Voting! Terima kasih sudah berpartisipasi dalam pemilihan periode ini", "Terima Kasih!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmLogin frmLogin = new frmLogin();
                frmLogin.Show();
                form.Hide();
            }
            else
            {
                MessageBox.Show("Voting dibatalkan", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DisplayImage(PictureBox pictureBox, string imagePath)
        {
            try
            {
                pictureBox.Image = Image.FromFile(imagePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}");
            }
        }

        public void LoadCandidatesFromDatabase(Form form)
        {
            try
            {
                string connectionString = "Data Source=MSI;Initial Catalog=Pemilu;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT CandidateID, Capres_Image, Cawapres_Image, Capres_Name, Cawapres_Name FROM tbCandidate";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            int candidateNumber = 1;

                            //Perulangan untuk nama picturebox dan textbox ke berapa
                            while (reader.Read() && candidateNumber <= 6)
                            {
                                string capresImage = reader["Capres_Image"].ToString();
                                string cawapresImage = reader["Cawapres_Image"].ToString();
                                string capresName = reader["Capres_Name"].ToString();
                                string cawapresName = reader["Cawapres_Name"].ToString();

                                // Dengan asumsi Anda memiliki kontrol PictureBox bernama imgCapres1 hingga imgCapres6, imgCawapres1 hingga imgCawapres6
                                PictureBox capresPictureBox = (PictureBox)form.Controls.Find($"imgCapres{candidateNumber}", true).FirstOrDefault();
                                PictureBox cawapresPictureBox = (PictureBox)form.Controls.Find($"imgCawapres{candidateNumber}", true).FirstOrDefault();
                                Label capresLabel = (Label)form.Controls.Find($"lblCapres{candidateNumber}", true).FirstOrDefault();
                                Label cawapresLabel = (Label)form.Controls.Find($"lblCawapres{candidateNumber}", true).FirstOrDefault();

                                // Display images
                                DisplayImage(capresPictureBox, capresImage);
                                DisplayImage(cawapresPictureBox, cawapresImage);

                                // Display names
                                capresLabel.Text = capresName;
                                cawapresLabel.Text = cawapresName;

                                candidateNumber++;
                            }
                        }
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
