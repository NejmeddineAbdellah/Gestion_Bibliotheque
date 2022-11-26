using System;

namespace Gestion_bibliotheque
{
    internal class Ouvrage
    {
        private static int c = 0;
        private int cote;

        public Ouvrage()
        {
            this.cote = ++c;
        }

        public int Cote { get => cote;}
    }

}
