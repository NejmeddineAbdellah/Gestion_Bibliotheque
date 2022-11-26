using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Gestion_bibliotheque
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogClose = MessageBox.Show("Voulez vous vraiment fermer l'application ?", "Quitter le programme", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogClose == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "admin" && guna2TextBox2.Text == "123")
            {
                Dashboard dashboard = new Dashboard();
                dashboard.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Veuillez vérifier vos informations de login ! ", "info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                guna2TextBox2.Text = "";
                guna2TextBox1.Text = "";
            }
            
        }

        private void guna2TextBox1_Click(object sender, EventArgs e)
        {
            guna2TextBox1.Clear();
        }

        private void guna2TextBox2_Click(object sender, EventArgs e)
        {
            guna2TextBox2.Clear();
        }
    }
}
