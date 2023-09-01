using FIAPPOSTECH_FASE2.DOMAIN.Entities;
using FIAPPOSTECH_FASE2.DOMAIN.Repositories;
using FIAPPOSTECH_FASE2.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAPPOSTECH_FASE2.Infra.Repositories
{
    public class RepositorioUsuario : RepositorioGenerico<Usuario>, IRepositorioUsuario
    {
        public RepositorioUsuario(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Usuario> Get(Func<Usuario, bool> func = null)
        {
            var user = _dbContext.Usuarios
                .AsNoTracking()
                .Where(func)
                .Select(us => new Usuario(us.Id, us.Nome, us.Sobrenome, us.Email, us.Password, us.SaltHash))
                .FirstOrDefault();
            return await Task.FromResult(user);
        }

  
    }
}
