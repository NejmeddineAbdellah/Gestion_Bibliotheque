using System;

namespace Gestion_bibliotheque
{
    internal class Periodique : Ouvrage
    {
        private string nom;
        private int numero;
        private int periodicite;

        public Periodique(string nom, int numero, int periodicite) : base()
        {
            this.Nom = nom;
            this.Numero = numero;
            this.Periodicite = periodicite;
        }

        public string Nom { get => nom; set => nom = value; }
        public int Numero { get => numero; set => numero = value; }
        public int Periodicite { get => periodicite; set => periodicite = value; }

    }
}
