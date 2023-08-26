using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAPPOSTECH_FASE2.DOMAIN.Entities
{
    public class Noticia
    {
        public Noticia(string titulo, 
            string conteudo, 
            int autorId, 
            DateTime dataPublicacao)
        {
            Titulo = titulo;
            Conteudo = conteudo;
            DataPublicacao = dataPublicacao;
            AutorId = autorId;
        }

        public Noticia(int id, 
            string titulo, 
            string conteudo, 
            Usuario autor, 
            DateTime dataPublicacao)
        {
            Id = id;
            Titulo = titulo;
            Conteudo = conteudo;
            DataPublicacao = dataPublicacao;
            AutorId = autor.Id;
            Autor = autor;
        }

        protected Noticia()
        {
                
        }

        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Conteudo { get; private set; }
        public DateTime DataPublicacao { get; private set; }
        public int AutorId { get; private set; }
        public virtual Usuario Autor { get; private set; }
    }
}
