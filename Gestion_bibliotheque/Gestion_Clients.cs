using Gestion_bibliotheque.Classes;
using Gestion_bibliotheque.DB;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Gestion_bibliotheque
{
    public partial class Gestion_Clients : UserControl
    {
        Connection cnx = new Connection();
        MySqlDataAdapter da;
        DataTable dt;
        

        public Gestion_Clients()
        {
            InitializeComponent();
            GetClientList();
        }
        private void GetClientList()
        {
            cnx.connexion();
            cnx.cnxOpen();
            MySqlCommand Command = new MySqlCommand("select * from client", cnx.connMaster);
            Command.ExecuteNonQuery();
            dt = new DataTable();
            da = new MySqlDataAdapter(Command);
            da.Fill(dt);
            guna2DataGridView1.DataSource = dt;
            cnx.cnxClose();

        }

        //***
        private void guna2GradientButton5_Click_1(object sender, EventArgs e)
        {

            if (guna2TextBox4.Text == "" || guna2TextBox3.Text == "" || guna2TextBox2.Text == "")
            {
                DialogResult dialogClose = MessageBox.Show("Veuillez renseigner tous les champs", "Champs requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    Client client = new Client(guna2TextBox4.Text, guna2TextBox3.Text, guna2TextBox2.Text);

                    guna2TextBox2.Clear();
                    guna2TextBox4.Clear();
                    guna2TextBox3.Clear();

                    cnx.connexion();
                    cnx.cnxOpen();
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO client (cin,nom,prenom,nombre_emprunt,etat_emprunter,block)" + "VALUES(@cin,@nom,@prenom,@nombre_emprunt,@etat_emprunter,@block)", cnx.connMaster);
                    cmd.Parameters.AddWithValue("@cin", client.Cin);
                    cmd.Parameters.AddWithValue("@nom", client.Nom);
                    cmd.Parameters.AddWithValue("@prenom", client.Prenom);
                    cmd.Parameters.AddWithValue("@nombre_emprunt", 0);
                    cmd.Parameters.AddWithValue("@etat_emprunter", client.Emptunter);
                    cmd.Parameters.AddWithValue("@block", client.Block);
                    cmd.ExecuteNonQuery();
                    GetClientList();
                    cnx.cnxClose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //***
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            string cin_selected = Convert.ToString(guna2DataGridView1.SelectedRows[0].Cells[0].Value);


            DialogResult dialogDelete = MessageBox.Show("voulez-vous vraiment supprimer ce Livre", "Supprimer un Livre", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogDelete == DialogResult.OK)
            {
                cnx.connexion();
                cnx.cnxOpen();

                MySqlCommand cmd = new MySqlCommand("DELETE FROM client WHERE cin like '" + cin_selected + "'", cnx.connMaster);
                cmd.ExecuteNonQuery();
                GetClientList();
                cnx.cnxClose();

            }
        }

        //**
        private void guna2GradientButton6_Click_1(object sender, EventArgs e)
        {
            try
            {
                cnx.connexion();
                cnx.cnxOpen();
                MySqlCommand cmd = new MySqlCommand("update client set block=true where cin = @cin", cnx.connMaster);
                cmd.ExecuteNonQuery();
                GetClientList();
                cnx.cnxClose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //**
        private void guna2GradientButton3_Click(object sender, EventArgs e)
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
                    MySqlCommand cmd = new MySqlCommand("update client set nom=@nom ,prenom =@prenom where cin = @cin", cnx.connMaster);
                    cmd.Parameters.AddWithValue("@cin", guna2TextBox4.Text);
                    cmd.Parameters.AddWithValue("@nom", guna2TextBox3.Text);
                    cmd.Parameters.AddWithValue("@prenom", guna2TextBox2.Text);
                    cmd.ExecuteNonQuery();
                    GetClientList();
                    cnx.cnxClose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string cin_selected = Convert.ToString(guna2DataGridView1.SelectedRows[0].Cells[0].Value);
            guna2TextBox2.Text = Convert.ToString(guna2DataGridView1.SelectedRows[0].Cells[1].Value);
            guna2TextBox4.Text = Convert.ToString(guna2DataGridView1.SelectedRows[0].Cells[0].Value);
            guna2TextBox3.Text = Convert.ToString(guna2DataGridView1.SelectedRows[0].Cells[2].Value);
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            try
            {
                cnx.connexion();
                cnx.cnxOpen();
                MySqlCommand cmd = new MySqlCommand("select * from client where cin = @cin", cnx.connMaster);
                cmd.Parameters.AddWithValue("@cin", guna2TextBox1.Text);
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
                MessageBox.Show("client n'exist pas !!");
                
            }
            if (guna2TextBox1.Text=="")
            {
                GetClientList();
            }
        }

        private void Gestion_Clients_VisibleChanged(object sender, EventArgs e)
        {
            GetClientList();
        }
    }
}
