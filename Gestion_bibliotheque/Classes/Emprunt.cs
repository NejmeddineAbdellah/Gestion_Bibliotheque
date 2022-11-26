using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_bibliotheque.Classes
{
    internal class Emprunt
    {
        private int id;
        private Client client;
        private Ouvrage ouvrage;
        private DateTime date_empr;
        private DateTime date_retour;
        //private string etat;
        private static int c = 0; 

        public Emprunt(int id, Client client, Ouvrage ouvrage, DateTime date_empr, DateTime date_retour)
        {
            this.id = ++c;
            this.client = client;
            this.ouvrage = ouvrage;
            this.date_empr = date_empr;
            this.date_retour = date_retour;
        }
    }
}
