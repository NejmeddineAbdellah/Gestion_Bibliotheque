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
    public partial class Ouvrage_home : UserControl
    {
        Connection cnx = new Connection();
        MySqlDataAdapter da;
        DataTable dt;

        public Ouvrage_home()
        {
            InitializeComponent();
            statistiqueOuvrage();
        }

        private void Ouvrage_home_Load(object sender, EventArgs e)
        {
            statistiqueOuvrage();
        }

        private void statistiqueOuvrage()
        {   
                cnx.connexion();
                cnx.cnxOpen();
                MySqlCommand cmd1 = new MySqlCommand("select * from livre", cnx.connMaster);
                dt = new DataTable();
                da = new MySqlDataAdapter(cmd1);
                da.Fill(dt);
                int total_client = dt.Rows.Count;
                label7.Text = Convert.ToString(total_client);

                MySqlCommand cmd2 = new MySqlCommand("select * from cds", cnx.connMaster);
                dt = new DataTable();
                da = new MySqlDataAdapter(cmd2);
                da.Fill(dt);
                int total_ouvrage = dt.Rows.Count;
                label9.Text = Convert.ToString(total_ouvrage);

                MySqlCommand cmd3 = new MySqlCommand("select * from periodique", cnx.connMaster);
                dt = new DataTable();
                da = new MySqlDataAdapter(cmd3);
                da.Fill(dt);
                int total_emprunt = dt.Rows.Count;
                label12.Text = Convert.ToString(total_emprunt);
                cnx.cnxClose();
        }

        private void Ouvrage_home_VisibleChanged(object sender, EventArgs e)
        {
            statistiqueOuvrage();
        }
    }
}
