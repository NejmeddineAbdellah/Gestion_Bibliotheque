using MySql.Data.MySqlClient;

namespace Gestion_bibliotheque.DB
{
    internal class Connection
    {
        public MySqlConnection connMaster;
        public void connexion()
        {
            connMaster = new MySqlConnection($"datasource=localhost;port=3306;username=root;password=;database=gestion_bilbiotheque");
        }
        public void cnxOpen()
        {
            connMaster.Open();
        }
        public void cnxClose()
        {
            connMaster.Close();
        }
    }
}
