using FIAPPOSTECH_FASE2.DOMAIN.Entities;
using FIAPPOSTECH_FASE2.DOMAIN.Repositories;
using FIAPPOSTECH_FASE2.Infra.Context;

namespace FIAPPOSTECH_FASE2.Infra.Repositories
{
    public class RepositorioNoticia : RepositorioGenerico<Noticia>, IRepositorioNotifica
    {
        public RepositorioNoticia(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
