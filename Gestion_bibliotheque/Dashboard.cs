using System;
using System.Windows.Forms;

namespace Gestion_bibliotheque
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            dashboard_Home1.Show();
            gestion_Clients1.Hide();
            gestion_Ouvrage1.Hide();
            gestion_Emprunt1.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogClose = MessageBox.Show("Voulez vous vraiment fermer l'application ?", "Quitter le programme", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogClose == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            gestion_Ouvrage1.Show();
            gestion_Clients1.Hide();
            gestion_Emprunt1.Hide();
            dashboard_Home1.Hide();

        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            gestion_Clients1.Show();
            gestion_Ouvrage1.Hide();
            gestion_Emprunt1.Hide();
            dashboard_Home1.Hide();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            gestion_Emprunt1.Show();
            gestion_Clients1.Hide();
            gestion_Ouvrage1.Hide();
            dashboard_Home1.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            dashboard_Home1.Show();
            gestion_Emprunt1.Hide();
            gestion_Clients1.Hide();
            gestion_Ouvrage1.Hide();

        }
    }
}
