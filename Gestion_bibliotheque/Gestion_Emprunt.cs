using Gestion_bibliotheque.DB;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Gestion_bibliotheque
{
    public partial class Gestion_Emprunt : UserControl
    {
        public Gestion_Emprunt()
        {
            InitializeComponent();
            

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            emprunt_add1.Show();
            emprunt_gestion1.Hide();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            emprunt_gestion1.Show();
            emprunt_add1.Hide();
        }
    }
}
