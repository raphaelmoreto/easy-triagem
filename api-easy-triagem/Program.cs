using Services;
using Repositories;

namespace api_easy_triagem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args); //INICIALIZA O APLICATIVO E CONFIGURA SERVIÇOS

            //A CADA REQUISIÇÃO DA API RECEBE UMA NOVA CONEXÃO COM O BANCO
            builder.Services.AddScoped<DBConnection>();
            builder.Services.AddScoped<UsuarioService>();

            builder.Services.AddControllers(); //ADICIONA SERVIÇOS NECESSÁRIOS DE SUPORTE PARA "controllers" DA API
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.AddSwaggerGen(); //HABILITA O SWAGGER PARA DOCUMENTAÇÃO DA API

            var app = builder.Build(); //CONSTRÓI A APLICAÇÃO

            //ATIVA O SWAGGER APENAS NO AMBIENTE DE DESENVOLVIMENTO
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger(); app.UseSwaggerUI();
            }

            app.UseHttpsRedirection(); //REDIRECIONA HTTP PARA HTTPS

            app.UseAuthorization(); //HABILITA AUTENTICAÇÃO/AUTORIZAÇÃO

            app.MapControllers(); //MAPEIA OS ENDPOINTS DOS "controllers"

            app.Run(); //EXECUTA A APLICAÇÃO
        }
    }
}
