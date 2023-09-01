using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAPPOSTECH_FASE2.DTO.Dtos.Noticia
{
    public record NoticiaListaDTO(int id, string titulo, string conteudo, string nomeAutor, DateTime dataPublicacao)
    {
    }
}
