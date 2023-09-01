using FIAPPOSTECH_FASE2.DOMAIN.Entities;
using FIAPPOSTECH_FASE2.DOMAIN.Repositories;
using FIAPPOSTECH_FASE2.Services.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FIAPPOSTECH_FASE2.Services.Services
{
    public class ServicoUsuarioLogado : IServicoUsuarioLogado
    {
        private readonly IHttpContextAccessor _context;
        private readonly IRepositorioUsuario _repositorioUsuario;

        public ServicoUsuarioLogado(IHttpContextAccessor context, IRepositorioUsuario repositorioUsuario)
        {
            _context = context;
            _repositorioUsuario = repositorioUsuario;
        }

        public async Task<Usuario> Get()
        {
            var idUserLogged = _context.HttpContext.User.Claims
                .FirstOrDefault(obj =>
            obj.Type.Equals("sid")

            ) ;

            if( idUserLogged == null ) { return null; }

            var user = await _repositorioUsuario.Get(obj => obj.Id.Equals(Convert.ToInt32(idUserLogged.Value)));
        return await Task.FromResult(user);
        }
    }
}
