using MySql.Data.MySqlClient;

namespace project_conventions.Models
{
    public class DB
    {
        private static MySqlConnection Conn = new MySqlConnection("server=localhost;port=3306;database=conventions;user=root;password=");

        public static MySqlConnection GetConnection()
        {
            return Conn;
        }
    }
}
