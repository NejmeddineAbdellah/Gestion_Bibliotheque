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
    public partial class Gestion_Ouvrage : UserControl
    {
        public Gestion_Ouvrage()
        {
            InitializeComponent();

            ouvrage_home1.Show();
            ouvrage_Livre1.Hide();
            ouvrage_Cds1.Hide();
            ouvrage_Periodecite1.Hide();

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ouvrage_Livre1.Show();
            ouvrage_Cds1.Hide();
            ouvrage_Periodecite1.Hide();
            ouvrage_home1.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            ouvrage_Cds1.Show();
            ouvrage_Livre1.Hide();
            ouvrage_Periodecite1.Hide();
            ouvrage_home1.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            ouvrage_Periodecite1.Show();
            ouvrage_Livre1.Hide();
            ouvrage_Cds1.Hide();
            ouvrage_home1.Hide();
        }
    }
}
