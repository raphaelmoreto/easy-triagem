using Models;
using Repositories;
using System.Data;
using Dapper;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Services
{
    public class UsuarioService
    {
        private readonly DBConnection _dbConnection;

        public UsuarioService()
        {
            _dbConnection = new DBConnection();
        }

        public async Task<bool> Insert(Usuario usuario)
        {
            using IDbConnection db = _dbConnection.GetConnection();

            var parametros = new DynamicParameters(new
            {
                p_nome = usuario.Nome,
                p_dataNascimento = usuario.DataNascimento,
                p_sexo_biologico = usuario.SexoBiologico,
                p_cpf = usuario.CPF,
                p_email = usuario.Email,
                p_dataCadastro = usuario.DataCadastro,
                p_logradouro = usuario.Endereco.Logradouro,
                p_endereco = usuario.Endereco._Endereco,
                p_numero = usuario.Endereco.Numero,
                p_complemento = usuario.Endereco.Complemento,
                p_bairro = usuario.Endereco.Bairro,
                p_cidade = usuario.Endereco.Cidade,
                p_estadoUF = usuario.Endereco.EstadoUF,
                p_cep = usuario.Endereco.CEP
            });

            parametros.Add("@msg", dbType: DbType.Byte, direction: ParameterDirection.Output); //DEFINE O PARÂMETRO DE SAÍDA

            //INFORMA AO DAPPER QUE ESTÁ EXECUTANDO UMA "Stored Procedure" E NÃO UMA QUERY COMUM
            await db.ExecuteAsync("cadastroCliente", parametros, commandType: CommandType.StoredProcedure);

           int resultado = parametros.Get<byte>("@msg"); //OBTEM O VALOR DO PARÂMETRO OUT
            return resultado == 1;
        }

        public async Task<IEnumerable<Usuario>> ListaUsuarios()
        {
            using IDbConnection db = _dbConnection.GetConnection();

            return await db.QueryAsync<Usuario>("SELECT *" +
                                                                     "FROM usuario");
        }
    }
}
