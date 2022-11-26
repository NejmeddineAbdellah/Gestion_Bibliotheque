using Gestion_bibliotheque.DB;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Gestion_bibliotheque
{
    public partial class Ouvrage_Periodique : UserControl
    {
        Connection cnx = new Connection();
        MySqlDataAdapter da;
        DataTable dt;

        public Ouvrage_Periodique()
        {
            InitializeComponent();
            GetPeriodiqueList();
        }

        private void GetPeriodiqueList()
        {
            cnx.connexion();
            cnx.cnxOpen();
            MySqlCommand Command = new MySqlCommand("select * from periodique", cnx.connMaster);
            Command.ExecuteNonQuery();
            dt = new DataTable();
            da = new MySqlDataAdapter(Command);
            da.Fill(dt);
            guna2DataGridView1.DataSource = dt;
            cnx.cnxClose();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            if (guna2TextBox4.Text == "" || guna2TextBox3.Text == "" || guna2TextBox2.Text == "")
            {
                DialogResult dialogClose = MessageBox.Show("Veuillez renseigner tous les champs", "Champs requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    cnx.connexion();
                    cnx.cnxOpen();
                    //question
                    Ouvrage periodique = new Periodique(guna2TextBox2.Text,int.Parse(guna2TextBox3.Text), int.Parse(guna2TextBox4.Text));
                    MySqlCommand comd = new MySqlCommand("insert into ouvrage (cote)" + "VALUES(@cote)", cnx.connMaster);
                    comd.Parameters.AddWithValue("@cote", periodique.Cote);
                    comd.ExecuteNonQuery();

                    MySqlCommand cmd = new MySqlCommand("insert into periodique (nom,numero,periodicite,cote)" + "VALUES(@nom,@numero,@periodicite,@cote)", cnx.connMaster);
                    cmd.Parameters.AddWithValue("@nom", guna2TextBox2.Text);
                    cmd.Parameters.AddWithValue("@numero", guna2TextBox3.Text);
                    cmd.Parameters.AddWithValue("@periodicite", guna2TextBox4.Text);
                    cmd.Parameters.AddWithValue("@cote", periodique.Cote);

                    cmd.ExecuteNonQuery();
                    GetPeriodiqueList();
                    cnx.cnxClose();
                    guna2TextBox2.Clear();
                    guna2TextBox4.Clear();
                    guna2TextBox3.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {

            if (guna2TextBox4.Text == "" || guna2TextBox3.Text == "" || guna2TextBox2.Text == "")
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
                    MySqlCommand cmd = new MySqlCommand("update livre set nom=@nom ,numero=@numero, periodicite=@periodicite where cote = @cote", cnx.connMaster);
                    cmd.Parameters.AddWithValue("@nom", guna2TextBox4.Text);
                    cmd.Parameters.AddWithValue("@numero", guna2TextBox2.Text);
                    cmd.Parameters.AddWithValue("@periodicite", guna2TextBox3.Text);
                    cmd.Parameters.AddWithValue("@cote", cote);
                    cmd.ExecuteNonQuery();
                    GetPeriodiqueList();
                    cnx.cnxClose();
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
            DialogResult dialogDelete = MessageBox.Show("voulez-vous vraiment supprimer ce Periodique", "Supprimer un Periodique", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogDelete == DialogResult.OK)
            {
                cnx.connexion();
                cnx.cnxOpen();

                MySqlCommand cmd = new MySqlCommand("DELETE FROM Periodique WHERE cote =@cote;DELETE FROM ouvrage WHERE cote =@cote ;", cnx.connMaster);
                cmd.Parameters.AddWithValue("@cote", cote);
                cmd.ExecuteNonQuery();
                GetPeriodiqueList();
                cnx.cnxClose();

            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //int cote = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells[0].Value);
            guna2TextBox2.Text = Convert.ToString(guna2DataGridView1.SelectedRows[0].Cells[1].Value);
            guna2TextBox3.Text = Convert.ToString(guna2DataGridView1.SelectedRows[0].Cells[2].Value);
            guna2TextBox4.Text = Convert.ToString(guna2DataGridView1.SelectedRows[0].Cells[3].Value);
        }

        private void Ouvrage_Periodique_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text=="")
            {
                GetPeriodiqueList();
            }
            else
            {
                try
                {
                    cnx.connexion();
                    cnx.cnxOpen();
                    MySqlCommand cmd = new MySqlCommand("select from periodique where cote = @cote", cnx.connMaster);
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }  
            }
        }
    }
}
