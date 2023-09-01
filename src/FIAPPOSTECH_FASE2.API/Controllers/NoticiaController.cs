using FIAPPOSTECH_FASE2.DTO.Dtos.Noticia;
using FIAPPOSTECH_FASE2.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace FIAPPOSTECH_FASE2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NoticiaController : ControllerBase
    {
        private readonly IServicoNoticia  _servicoNoticia;

        public NoticiaController(IServicoNoticia servicoNoticia)
        {
            _servicoNoticia = servicoNoticia;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] NoticiaCadastroDTO noticiaCadastroDTO)
        {
            var result = await _servicoNoticia.Add(noticiaCadastroDTO.ToDomain());

            if (result == null) return BadRequest();

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var noticias = new List<NoticiaListaDTO>();
            var result = await _servicoNoticia.GetAll(obj => obj.Id > 0);

            if (result == null) return NotFound();

            result.ToList().ForEach(x =>
            {
                var entity = new NoticiaListaDTO(x.Id,x.Titulo,x.Conteudo, string.Concat(x.Autor.Nome, " ", x.Autor.Sobrenome), x.DataPublicacao);
                noticias.Add(entity);
            });

            return Ok(noticias);

        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _servicoNoticia.Get(obj => obj.Id.Equals(id));

            if (result == null) return NotFound();

            var noticia = new NoticiaDTO(result);

            return Ok(noticia);

        }

        [HttpGet("autor/{id}")]
        public async Task<IActionResult> ObterPorAutor(int id)
        {
            var noticias = new List<NoticiaListaDTO>();
            var result = await _servicoNoticia.ObterPorAutor(id);


            if (result == null) return NotFound();

            result.ToList().ForEach(x =>
            {
                var entity = new NoticiaListaDTO(x.Id,x.Titulo, x.Conteudo, string.Concat(x.Autor.Nome, " ", x.Autor.Sobrenome),x.DataPublicacao);
                noticias.Add(entity);
            });

            return Ok(noticias);

        }

    }
}
