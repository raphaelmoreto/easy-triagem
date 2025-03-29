using System.Data;
using MySql.Data.MySqlClient;

namespace Repositories
{
    public class DBConnection
    {
        public readonly string _connection;

        public DBConnection()
        {
            _connection = "Server=localhost;Database=easy_triagem;User=root;Password=''";
        }

        public IDbConnection GetConnection()
        {
            return new MySqlConnection(_connection);
        }
    }
}
