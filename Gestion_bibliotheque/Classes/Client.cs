using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_bibliotheque.Classes
{
    internal class Client
    {
        private int id;
        private string cin;
        private string nom;
        private string prenom;
        private bool emptunter;
        private int nombre_emprunt;
        private bool block;
        private static int c = 0;

        public Client(string cin, string nom, string prenom)
        {
            this.id = ++c;
            this.Cin = cin;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Nombre_emprunt = 0;
            this.emptunter = false;
            this.Block = false;
        }

        public int Id { get => id; }
        public string Cin { get => cin; set => cin = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public bool Emptunter { get => emptunter; set => emptunter = value; }
        public int Nombre_emprunt { get => nombre_emprunt; set => nombre_emprunt = value; }
        public bool Block { get => block; set => block = value; }
    }
}
