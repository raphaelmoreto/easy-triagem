using Models;
using Repositories;
using System.Data;
using Dapper;
using System.Text;

namespace Services
{
    public class UsuarioService
    {
        private readonly DBConnection _dbConnection;

        public UsuarioService()
        {
            _dbConnection = new DBConnection();
        }

        private async Task<bool> InserirEnderecoUsuarioAsync(Endereco endereco, int idUsuario)
        {
            using IDbConnection db = _dbConnection.GetConnection();

            var sb = new StringBuilder();
            sb.AppendLine("INSERT INTO endereco (fk_usuario, fk_logradouro, endereco, numero, complemento, bairro, cidade, fk_estadoUF, cep)");
            sb.AppendLine("                      VALUES (@p_idUsuario, @p_logradouro, @p_endereco, @p_numero, @p_complemento, @p_bairro, @p_cidade, @p_estadoUF, @p_cep)");

            var parametrosEndereco = new DynamicParameters(new
            {
                p_idUsuario = idUsuario,
                p_logradouro = endereco.Logradouro,
                p_endereco = endereco._Endereco,
                p_numero = endereco.Numero,
                p_complemento = endereco.Complemento,
                p_bairro = endereco.Bairro,
                p_cidade = endereco.Cidade,
                p_estadoUF = endereco.EstadoUF,
                p_cep = endereco.CEP
            });

            int retorno = await db.ExecuteAsync(sb.ToString(), parametrosEndereco);
            return retorno > 0;
        }

        public async Task<bool> InserirUsuarioAsync(Usuario usuario)
        {
            using IDbConnection db = _dbConnection.GetConnection();

            var parametrosUsuario = new DynamicParameters(new
            {
                p_nome = usuario.Nome,
                p_dataNascimento = usuario.DataNascimento,
                p_sexo_biologico = usuario.SexoBiologico,
                p_cpf = usuario.CPF,
                p_email = usuario.Email,
                p_dataCadastro = usuario.DataCadastro
            });

            parametrosUsuario.Add("@msg", dbType: DbType.Byte, direction: ParameterDirection.Output); //DEFINE O PARÂMETRO DE SAÍDA

            //INFORMA AO DAPPER QUE ESTÁ EXECUTANDO UMA "Stored Procedure" E NÃO UMA QUERY COMUM
            await db.ExecuteAsync("cadastroUsuario", parametrosUsuario, commandType: CommandType.StoredProcedure);
            int idUsuario = parametrosUsuario.Get<byte>("@msg"); //OBTEM O VALOR DO PARÂMETRO OUT

            if (idUsuario == 0)
            {
                return false;
            }

            var resultado = await InserirEnderecoUsuarioAsync(usuario.Endereco, idUsuario);
            return resultado;
        }

        public async Task<IEnumerable<Usuario>> ListaUsuarios()
        {
            using IDbConnection db = _dbConnection.GetConnection();

            return await db.QueryAsync<Usuario>("SELECT *" +
                                                                     "FROM usuario");
        }
    }
}
