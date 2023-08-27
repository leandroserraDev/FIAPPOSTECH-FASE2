using FIAPPOSTECH_FASE2.DTO.AppServices;
using FIAPPOSTECH_FASE2.DTO.Dtos.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FIAPPOSTECH_FASE2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IAppServicoUsuario _appServicoUsuario;
public UsuarioController(IAppServicoUsuario appServicoUsuario)
        {
            _appServicoUsuario = appServicoUsuario;
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _appServicoUsuario.Get(obj => obj.Id.Equals(id));
            return Ok(result);  
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _appServicoUsuario.GetAll(obj => obj.Id > 0);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UsuarioCadastroDTO usuarioCadastroDTO)
        {
            var result = await _appServicoUsuario.Add(usuarioCadastroDTO.ToDomain());

            if(result == null) return BadRequest();

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult>Update (UsuarioEdicaoDTO usuarioAtualizacaoDto)
        {
            var result = await _appServicoUsuario.Update(usuarioAtualizacaoDto.ToDomain());

            if(result == null) return BadRequest(); return Ok(result);
        }

    }
}
