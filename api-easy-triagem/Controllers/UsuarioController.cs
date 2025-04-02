using Models;
using Services;
using Microsoft.AspNetCore.Mvc; //PACOTE DO ASP.NET QUE FORNECE FUNCIONALIDADES PARA CONSTRUIR APIs E APLICAÇÕES MVC

namespace Controllers
{
    //O "ControllerBase" É A CLASSE BASE PARA APIs NO ASP.NET CORE
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarUsuario([FromBody] Usuario usuario) //O "[FromBody]" É UM DECORADOR QUE IRÁ PEGAR O JSON E CONVERTER OS DADOS EM UM OBJETO "Usuario"
        {
            var cadastro = await _usuarioService.InserirUsuarioAsync(usuario);

            if (!cadastro)
            {
                return Unauthorized("EMAIL JÁ ESTÁ EM USO");
            }

            return Ok("USUÁRIO CADASTRADO COM SUCESSO");
        }

        [HttpGet]
        public async Task<IActionResult> ListaUsuarios() //O "IActionResult" PERMITE QUE O MÉTODO RETORNE DIFERENTES TIPOS DE RESPOSTAS HTTP
        {
            var usuarios = await _usuarioService.ListaUsuarios();
            return Ok(usuarios);
        }
    }
}
