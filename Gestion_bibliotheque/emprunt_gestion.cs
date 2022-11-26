using Gestion_bibliotheque.DB;
using Guna.UI2.WinForms;
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
    public partial class emprunt_gestion : UserControl
    {
        Connection cnx = new Connection();
        MySqlDataAdapter da;
        DataTable dt;

        public emprunt_gestion()
        {
            InitializeComponent();
            GetEmpruntList();
        }

        private void GetEmpruntList()
        {
            cnx.connexion();
            cnx.cnxOpen();
            MySqlCommand Command = new MySqlCommand("select * from emprunt", cnx.connMaster);
            Command.ExecuteNonQuery();
            dt = new DataTable();
            da = new MySqlDataAdapter(Command);
            da.Fill(dt);
            guna2DataGridView1.DataSource = dt;
            cnx.cnxClose();

        }

        private void emprunt_gestion_Load(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int cote_selected = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells[0].Value);
            string cin_selected = Convert.ToString(guna2DataGridView1.SelectedRows[0].Cells[1].Value);
            DateTime date_emprunt = Convert.ToDateTime(Convert.ToString(guna2DataGridView1.SelectedRows[0].Cells[3].Value));
            DateTime date_retourne = Convert.ToDateTime(Convert.ToString(guna2DataGridView1.SelectedRows[0].Cells[4].Value));

            if (date_retourne==Convert.ToDateTime(null))
            {
                date_retourne = DateTime.Now;
            }

            guna2TextBox1.Text = cin_selected;
            guna2TextBox2.Text = cote_selected.ToString();
            guna2DateTimePicker1.Value=date_emprunt;
            guna2DateTimePicker2.Value = date_retourne;
           
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {

            int cote_selected = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells[0].Value);
            string cin_selected = Convert.ToString(guna2DataGridView1.SelectedRows[0].Cells[1].Value);

            if (guna2TextBox1.Text == "" || guna2TextBox2.Text == "")
            {
                DialogResult dialogClose = MessageBox.Show("Veuillez renseigner tous les champs", "Champs requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    cnx.connexion();
                    cnx.cnxOpen();
                    MySqlCommand cmd = new MySqlCommand("update emprunt set cin=@cin ,cote =@cote ,date_emprunt =@date_emprunt ,date_retourne =@date_retourne where cote = @cote and cin = @cin", cnx.connMaster);
                    cmd.Parameters.AddWithValue("@cin", cin_selected);
                    cmd.Parameters.AddWithValue("@cote", cote_selected);
                    cmd.Parameters.AddWithValue("@date_emprunt", guna2DateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@date_retourne", guna2DateTimePicker2.Value);
                    cmd.ExecuteNonQuery();
                    GetEmpruntList();
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
            int cote_selected = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells[0].Value);
            string cin_selected = Convert.ToString(guna2DataGridView1.SelectedRows[0].Cells[1].Value);
            DialogResult dialogDelete = MessageBox.Show("voulez-vous vraiment supprimer ce emprunt", "Supprimer un emprunt", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogDelete == DialogResult.OK)
            {

                cnx.connexion();
                cnx.cnxOpen();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM emprunt WHERE cote = @cote and cin like @cin", cnx.connMaster);
                cmd.Parameters.AddWithValue("@cote", cote_selected);
                cmd.Parameters.AddWithValue("@cin", cin_selected);
                cmd.ExecuteNonQuery();
                GetEmpruntList();
                cnx.cnxClose();

            }
        }

        private void guna2DataGridView1_VisibleChanged(object sender, EventArgs e)
        {
            GetEmpruntList();
        }
    }
}
