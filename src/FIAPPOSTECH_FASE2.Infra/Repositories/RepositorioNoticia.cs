using FIAPPOSTECH_FASE2.DOMAIN.Entities;
using FIAPPOSTECH_FASE2.DOMAIN.Repositories;
using FIAPPOSTECH_FASE2.Infra.Context;

namespace FIAPPOSTECH_FASE2.Infra.Repositories
{
    public class RepositorioNoticia : RepositorioGenerico<Noticia>, IRepositorioNoticia
    {
        public RepositorioNoticia(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IList<Noticia>> ObterPorAutor(int autorId)
        {
            var noticias = _dbContext.Noticias
               .Where(nt => nt.AutorId.Equals(autorId))

                .Select(nt => new Noticia(nt.Id, nt.Titulo, nt.Conteudo, new Usuario(nt.Autor.Nome, nt.Autor.Sobrenome, nt.Autor.Email,""), nt.DataPublicacao))
                .ToList();

            return await Task.FromResult(noticias);
        }

        public override async Task<Noticia> Get(Func<Noticia, bool> func = null)
        {
            var result = _dbContext.Noticias
                .Select(nt => new Noticia(nt.Id, nt.Titulo, nt.Conteudo, new Usuario(nt.Id, nt.Autor.Nome, nt.Autor.Sobrenome, nt.Autor.Email, "", null), nt.DataPublicacao))
                .FirstOrDefault(func);


            return await Task.FromResult(result);
        }

        public override async Task<IEnumerable<Noticia>> GetAll(Func<Noticia, bool> func = null)
        {
            var result = _dbContext.Noticias
                .Select(nt => new Noticia(nt.Id, nt.Titulo, nt.Conteudo, new Usuario(nt.Id,nt.Autor.Nome, nt.Autor.Sobrenome, "", "", null), nt.DataPublicacao))
                .Where(func)
                .ToList();
            return await Task.FromResult(result);
        }


    }
}
