using System;

namespace Gestion_bibliotheque
{
    internal class Cd : Ouvrage
    {
        private string titre;
        private string auteur;

        public Cd(string titre, string auteur) : base()
        {
            this.Titre = titre;
            this.Auteur = auteur;
        }

        public string Titre { get => titre; set => titre = value; }
        public string Auteur { get => auteur; set => auteur = value; }
    }
}
