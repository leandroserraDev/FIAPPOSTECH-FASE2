using FIAPPOSTECH_FASE2.DTO.AppServices;
using FIAPPOSTECH_FASE2.DTO.Dtos.User;
using FIAPPOSTECH_FASE2.Services.Interface;
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
        private readonly IServicoUsuario _servicoUsuario;

        public UsuarioController(IServicoUsuario servicoUsuario)
        {
            _servicoUsuario = servicoUsuario;
        }


        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _servicoUsuario.Get(obj => obj.Id.Equals(id));
            var usuario = new UsuarioDTO(result.Id, result.Nome, result.Email);
            return Ok(usuario);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var listUsuario = new List<UsuarioDTO>();
            var result = await _servicoUsuario.GetAll(obj => obj.Id > 0);

            if (result == null) return NotFound();
            result.ToList().ForEach(us =>
            {
                var entity = new UsuarioDTO(us.Id, us.Nome, us.Email);
                listUsuario.Add(entity);
            });

            return Ok(listUsuario);
        }
        [HttpPost]
        public async Task<IActionResult> Create(UsuarioCadastroDTO usuarioCadastroDTO)
        {
            var result = await _servicoUsuario.Add(usuarioCadastroDTO.ToDomain());

            if (result == null) return BadRequest();

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UsuarioEdicaoDTO usuarioAtualizacaoDto)
        {
            var result = await _servicoUsuario.Update(usuarioAtualizacaoDto.ToDomain());

            if (result == null) return BadRequest(); return Ok(result);
        }

        [HttpPatch("{id}/trocar-senha")]
        public async Task<IActionResult> TrocarSenha(int id, [FromBody] UsuarioTrocarSenhaDTO usuarioTrocarSenhaDTO)
        {
            var result = await _servicoUsuario.TrocarSenha(id, usuarioTrocarSenhaDTO.password);
            if(!result) return BadRequest(new {mensagem= "senha não trocada"});

            return Ok(result);
        }

    }
}
