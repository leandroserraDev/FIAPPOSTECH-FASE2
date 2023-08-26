using FIAPPOSTECH_FASE2.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAPPOSTECH_FASE2.DOMAIN.Repositories
{
    public interface IAutenticacaoRepositorio
    {
        Task<Usuario> Login(string email, string password);
        Task<Usuario> GetUserByEmail(string email);
    }
}
