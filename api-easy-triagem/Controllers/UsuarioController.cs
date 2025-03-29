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

        [HttpGet]
        public async Task<IActionResult> ListaUsuarios() //O "IActionResult" PERMITE QUE O MÉTODO RETORNE DIFERENTES TIPOS DE RESPOSTAS HTTP
        {
            var usuarios = await _usuarioService.ListaUsuarios();
            return Ok(usuarios);
        }
    }
}
