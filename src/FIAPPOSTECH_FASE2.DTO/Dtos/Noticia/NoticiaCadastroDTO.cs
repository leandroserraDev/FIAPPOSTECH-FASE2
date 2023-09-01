using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAPPOSTECH_FASE2.DTO.Dtos.Noticia
{
    public record NoticiaCadastroDTO(string titulo, string conteudo)
    {
        public DOMAIN.Entities.Noticia ToDomain()
        {
            var noticia = new DOMAIN.Entities.Noticia(titulo, conteudo);
            return noticia;
        }
    }
}
