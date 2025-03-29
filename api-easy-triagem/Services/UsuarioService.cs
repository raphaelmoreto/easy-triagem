using Models;
using Repository;
using System.Data;
using Dapper;

namespace api_easy_triagem.Services
{
    public class UsuarioService
    {
        private readonly DBConnection _dBConnection;

        public UsuarioService()
        {
            _dBConnection = new DBConnection();
        }


    }
}
