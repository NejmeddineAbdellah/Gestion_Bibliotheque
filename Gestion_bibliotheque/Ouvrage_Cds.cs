using Gestion_bibliotheque.DB;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Gestion_bibliotheque
{
    public partial class Ouvrage_Cds : UserControl
    {
        Connection cnx = new Connection();
        MySqlDataAdapter da;
        DataTable dt;
        public Ouvrage_Cds()
        {
            InitializeComponent();
            GetCdsList();
        }
        private void GetCdsList()
        {
            cnx.connexion();
            cnx.cnxOpen();
            MySqlCommand Command = new MySqlCommand("select * from cds", cnx.connMaster);
            Command.ExecuteNonQuery();
            dt = new DataTable();
            da = new MySqlDataAdapter(Command);
            da.Fill(dt);
            guna2DataGridView1.DataSource = dt;
            cnx.cnxClose();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {

            if (guna2TextBox4.Text == "" || guna2TextBox2.Text == "")
            {
                DialogResult dialogClose = MessageBox.Show("Veuillez renseigner tous les champs", "Champs requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    cnx.connexion();
                    cnx.cnxOpen();

                    Ouvrage cds = new Cd(guna2TextBox2.Text, guna2TextBox4.Text);
                    MySqlCommand comd = new MySqlCommand("insert into ouvrage (cote)" + "VALUES(@cote)", cnx.connMaster);
                    comd.Parameters.AddWithValue("@cote", cds.Cote);
                    comd.ExecuteNonQuery();

                    MySqlCommand cmd = new MySqlCommand("insert into cds (titre,auteur,cote)" + "VALUES(@titre,@auteur,@cote)", cnx.connMaster);
                    cmd.Parameters.AddWithValue("@titre", guna2TextBox4.Text);
                    cmd.Parameters.AddWithValue("@auteur", guna2TextBox2.Text);
                    cmd.Parameters.AddWithValue("@cote", cds.Cote);

                    cmd.ExecuteNonQuery();
                    GetCdsList();
                    cnx.cnxClose();
                    guna2TextBox2.Clear();
                    guna2TextBox4.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            int cote = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells[0].Value);
            DialogResult dialogDelete = MessageBox.Show("voulez-vous vraiment supprimer ce Livre", "Supprimer un Livre", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogDelete == DialogResult.OK)
            {
                cnx.connexion();
                cnx.cnxOpen();

                MySqlCommand cmd = new MySqlCommand("DELETE FROM cds WHERE cote = ;DELETE FROM ouvrage WHERE cote =@cote ;", cnx.connMaster);
                cmd.Parameters.AddWithValue("@cote", cote);
                cmd.ExecuteNonQuery();
                GetCdsList();
                cnx.cnxClose();

            }
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            if (guna2TextBox4.Text == "" || guna2TextBox2.Text == "")
            {
                DialogResult dialogClose = MessageBox.Show("Veuillez renseigner tous les champs", "Champs requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    cnx.connexion();
                    cnx.cnxOpen();
                    int cote = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells[0].Value);
                    MySqlCommand cmd = new MySqlCommand("update cds set titre=@titre ,editeur =@editeur where cote = @cote", cnx.connMaster);
                    cmd.Parameters.AddWithValue("@titre", guna2TextBox4.Text);
                    cmd.Parameters.AddWithValue("@auteur", guna2TextBox2.Text);
                    cmd.Parameters.AddWithValue("@cote", cote);
                    cmd.ExecuteNonQuery();
                    GetCdsList();
                    cnx.cnxClose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "")
            {
                GetCdsList();

            }
            else
            {
                try
                {
                    cnx.connexion();
                    cnx.cnxOpen();
                    MySqlCommand cmd = new MySqlCommand("select from cds where cote = @cote", cnx.connMaster);
                    cmd.Parameters.AddWithValue("@cote", guna2TextBox1.Text);
                    cmd.ExecuteNonQuery();
                    dt = new DataTable();
                    da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    BindingSource bs = new BindingSource();
                    bs.DataSource = dt;
                    guna2DataGridView1.DataSource = dt;
                    cnx.cnxClose();
                }
                catch (Exception)
                {
                    MessageBox.Show("le Cds n'exist pas");
                }
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int cote = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells[0].Value);
            guna2TextBox4.Text = Convert.ToString(guna2DataGridView1.SelectedRows[0].Cells[1].Value);
            guna2TextBox2.Text = Convert.ToString(guna2DataGridView1.SelectedRows[0].Cells[2].Value);

        }
    }
}
