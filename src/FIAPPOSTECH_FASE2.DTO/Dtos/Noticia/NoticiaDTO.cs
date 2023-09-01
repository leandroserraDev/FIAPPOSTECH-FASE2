using FIAPPOSTECH_FASE2.DTO.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAPPOSTECH_FASE2.DTO.Dtos.Noticia
{
    public record  NoticiaDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public UsuarioDTO Autor{ get; set; }
        public NoticiaDTO(DOMAIN.Entities.Noticia noticia)
        {
            Id = noticia.Id;
            Titulo = noticia.Titulo;
            Conteudo = noticia.Conteudo;
            Autor = new UsuarioDTO(noticia.Autor.Id, noticia.Autor.Nome, noticia.Autor.Email);

        }
    }
}
