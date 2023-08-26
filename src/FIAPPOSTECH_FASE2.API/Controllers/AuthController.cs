using FIAPPOSTECH_FASE2.API.JWT;
using FIAPPOSTECH_FASE2.DTO.Dtos.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FIAPPOSTECH_FASE2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> Login([FromQuery] UsuarioLoginDTO usuarioLoginDTO) {

            var user = new UsuarioDTO(1, "leandro", "email@gmail.com");
            var token =await  GerarJWTOKEN.GerarToken(user, _configuration);
            return Ok(token);
        }
    }
}
