using System.Data;
using MySql.Data.MySqlClient;

namespace Repository
{
    public class DBConnection
    {
        public readonly string _connection;

        public DBConnection()
        {
            _connection = "Server=localhost;Database=DbEasyTriagem;User=root;Password='';";
        }

        public IDbConnection GetConnection()
        {
            return new MySqlConnection(_connection);
        }
    }
}
