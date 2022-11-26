using Gestion_bibliotheque.DB;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_bibliotheque
{
    public partial class emprunt_add : UserControl
    {
        Connection cnx = new Connection();
        MySqlDataAdapter da;
        DataTable dt;
        string nom_client;

        public emprunt_add()
        {
            InitializeComponent();
            GetLivreList();
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

        private void GetLivreList()
        {
            cnx.connexion();
            cnx.cnxOpen();
            MySqlCommand Command = new MySqlCommand("select * from livre", cnx.connMaster);
            Command.ExecuteNonQuery();
            dt = new DataTable();
            da = new MySqlDataAdapter(Command);
            da.Fill(dt);
            guna2DataGridView2.DataSource = dt;
            cnx.cnxClose();

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
            guna2DataGridView2.DataSource = dt;
            cnx.cnxClose();
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
            guna2DataGridView2.DataSource = dt;
            cnx.cnxClose();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "")
            {
                DialogResult dialogClose = MessageBox.Show("Voulez vous vraiment fermer l'application ?", "Quitter le programme", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dialogClose == DialogResult.OK)
                {
                    Gestion_Clients g = new Gestion_Clients();

                    g.Show();
                    this.Hide();
                }
            }
        }
        private bool verifierClient()
        {
            cnx.connexion();
            cnx.cnxOpen();
            MySqlCommand cmd = new MySqlCommand("select * from client where cin like @cin", cnx.connMaster);
            cmd.Parameters.AddWithValue("@cin", guna2TextBox1.Text);
            MySqlDataReader rdr = cmd.ExecuteReader();
            int nb_emprunt;
            bool block;

            while (rdr.Read())
            {
                nb_emprunt = Convert.ToInt32(rdr["nombre_emprunt"]);
                if (nb_emprunt > 3) {
                    MessageBox.Show("Ce client deja 3 emprunt !!");
                    return false;
                        }
                block = Convert.ToBoolean(rdr["block"]);
                if (block == true)
                {
                    MessageBox.Show("Ce client est blocker !!");
                    return false;

                }
            }
            cnx.cnxClose();
            return true;
        }


        private void guna2GradientButton6_Click_1(object sender, EventArgs e)
        {
            GetLivreList();
        }

        private void guna2GradientButton5_Click_1(object sender, EventArgs e)
        {
            GetCdsList();
        }

        private void guna2GradientButton4_Click_1(object sender, EventArgs e)
        {
            GetPeriodiqueList();

        }

        private void guna2DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            string cin_selected = Convert.ToString(guna2DataGridView1.SelectedRows[0].Cells[0].Value);
            guna2TextBox1.Text = Convert.ToString(guna2DataGridView1.SelectedRows[0].Cells[0].Value);
        }

        private void guna2DataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int cote_selected = Convert.ToInt32(guna2DataGridView2.SelectedRows[0].Cells[0].Value);

        }

        private void guna2GradientButton2_Click_1(object sender, EventArgs e)
        {
            
            if (verifierClient() == true)
            {
                try
                {

                    int cote_selected = Convert.ToInt32(guna2DataGridView2.SelectedRows[0].Cells[0].Value);
                    string cin_selected = Convert.ToString(guna2DataGridView1.SelectedRows[0].Cells[0].Value);

                    if (guna2TextBox1.Text == "")
                    {
                        DialogResult dialogClose = MessageBox.Show("Veuillez renseigner tous les champs", "Champs requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        try
                        {
                            cnx.cnxOpen();

                            MySqlCommand cmd1 = new MySqlCommand("insert into emprunt (cote,cin,nom,date_emprunt,date_retourne)" + "VALUES(@cote,@cin,@nom,@date_emprunt,@date_retourne); update client set nombre_emprunt=nombre_emprunt+1 where cin like @cin ;", cnx.connMaster);
                            cmd1.Parameters.AddWithValue("@cote", cote_selected);
                            cmd1.Parameters.AddWithValue("@cin", cin_selected);
                            cmd1.Parameters.AddWithValue("@nom", guna2DataGridView1.SelectedRows[0].Cells[1].Value);
                            cmd1.Parameters.AddWithValue("@date_emprunt", guna2DateTimePicker1.Value);
                            cmd1.Parameters.AddWithValue("@date_retourne", Convert.ToDateTime(null));
                            cmd1.ExecuteNonQuery();

                            MessageBox.Show("Bien ajouter !");

                            cnx.cnxClose();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        cnx.cnxClose();
                    }
                }
                catch (Exception)
                {

                }
            }
            GetLivreList();
            GetClientList();

        }

        private void emprunt_add_VisibleChanged(object sender, EventArgs e)
        {
            GetLivreList();
            GetClientList();
        }
    }
}
