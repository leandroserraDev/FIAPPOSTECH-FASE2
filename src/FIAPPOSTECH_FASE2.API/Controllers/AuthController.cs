using FIAPPOSTECH_FASE2.API.JWT;
using FIAPPOSTECH_FASE2.DTO.Dtos.User;
using FIAPPOSTECH_FASE2.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace FIAPPOSTECH_FASE2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly IServicoUsuario _servicoUsuario;
        public AuthController(IConfiguration configuration, IServicoUsuario servicoUsuario)
        {
            _configuration = configuration;
            _servicoUsuario = servicoUsuario;
        }

        [HttpGet]
        public async Task<IActionResult> Login([FromQuery] UsuarioLoginDTO usuarioLoginDTO)
        {

            var user = await _servicoUsuario.Login(usuarioLoginDTO.email, usuarioLoginDTO.password);
            if (user == null) { return BadRequest(new { mensagem = "Usuário ou senha inválidos" });  }

            var token = await GerarJWTOKEN.GerarToken(new(user.Id, user.Nome, user.Email), _configuration);

            return Ok(token);
        }
        [HttpPost]
        public async Task<IActionResult> L1ogin([FromBody] UsuarioLoginDTO usuarioLoginDTO)
        {

            var user = await _servicoUsuario.Login(usuarioLoginDTO.email, usuarioLoginDTO.password);
            if (user == null) { return BadRequest(new { mensagem = "Usuário ou senha inválidos" }); }

            var token = await GerarJWTOKEN.GerarToken(new(user.Id, user.Nome, user.Email), _configuration);

            return Ok(token);
        }
    }
}
