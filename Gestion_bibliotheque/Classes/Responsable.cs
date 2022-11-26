using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_bibliotheque.Classes
{
    internal class Responsable
    {
        private int id;
        private string nomUser;
        private string motDePasse;
        private static int c = 0;
        public Responsable(string nomUser, string motDePasse)
        {
            this.id = ++c;
            this.NomUser = nomUser;
            this.MotDePasse = motDePasse;
        }

        public string NomUser { get => nomUser; set => nomUser = value; }
        public string MotDePasse { get => motDePasse; set => motDePasse = value; }
    }
}
