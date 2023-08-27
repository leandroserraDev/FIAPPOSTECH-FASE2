using FIAPPOSTECH_FASE2.DOMAIN.Entities;
using FIAPPOSTECH_FASE2.DOMAIN.Repositories;
using FIAPPOSTECH_FASE2.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAPPOSTECH_FASE2.Services.Services
{
    public class ServicoUsuario : ServicoGenerico<Usuario>, IServicoUsuario
    {
        public ServicoUsuario(IRepositorioGenerico<Usuario> repositorioGenerico) : base(repositorioGenerico)
        {
        }
    }
}
