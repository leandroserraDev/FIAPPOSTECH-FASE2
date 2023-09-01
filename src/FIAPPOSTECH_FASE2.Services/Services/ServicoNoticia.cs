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
    public class ServicoNoticia : ServicoGenerico<Noticia>, IServicoNoticia
    {
        private readonly IRepositorioNoticia _repositorioNoticia;
        private readonly Usuario _usuarioLogado;
        public ServicoNoticia(IRepositorioGenerico<Noticia> repositorioGenerico, IRepositorioNoticia repositorioNoticia,
            IServicoUsuarioLogado servicoUsuarioLogado) : base(repositorioGenerico)
        {
            _repositorioNoticia = repositorioNoticia;
            _usuarioLogado = servicoUsuarioLogado.Get().Result;
        }

        public override Task<Noticia> Add(Noticia entity)
        {
            entity.AdicionarAutor(_usuarioLogado.Id);
            return base.Add(entity);
        }

        public async Task<IList<Noticia>> ObterPorAutor(int id)
        {
            var result = await _repositorioNoticia.ObterPorAutor(id);

            return await Task.FromResult(result);
        }
        public override async Task<Noticia> Get(Func<Noticia, bool> func = null)
        {
            var result = await _repositorioNoticia.Get(func);
            
            return await Task.FromResult(result);
        }

        public override async Task<IEnumerable<Noticia>> GetAll(Func<Noticia, bool> func = null)
        {
            return await Task.FromResult(await _repositorioNoticia.GetAll(func));
        }
    }
}
