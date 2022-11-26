using System;

namespace Gestion_bibliotheque
{
    internal class Livre : Ouvrage
    {

        private string auteur;
        private string titre;
        private string editeur;
        


        public Livre(string auteur, string titre, string editeur) : base()
        {
            this.Auteur = auteur;
            this.Titre = titre;
            this.Editeur = editeur;
            
        }
        public string getAuteur()
        {
            return auteur;
        }
        public string Auteur { get => auteur; set => auteur = value; }
        public string Titre { get => titre; set => titre = value; }
        public string Editeur { get => editeur; set => editeur = value; }

    }
}
