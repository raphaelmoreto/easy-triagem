using Models;
using Repositories;
using System.Data;
using Dapper;

namespace Services
{
    public class UsuarioService
    {
        private readonly DBConnection _dbConnection;

        public UsuarioService()
        {
            _dbConnection = new DBConnection();
        }

        public async Task<IEnumerable<Usuario>> ListaUsuarios()
        {
            using IDbConnection db = _dbConnection.GetConnection();

            return await db.QueryAsync<Usuario>("SELECT *" +
                                                                     "FROM usuario");
        }
    }
}
