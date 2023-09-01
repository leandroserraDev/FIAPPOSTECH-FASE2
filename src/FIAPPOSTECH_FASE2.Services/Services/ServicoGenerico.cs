using FIAPPOSTECH_FASE2.DOMAIN.Repositories;
using FIAPPOSTECH_FASE2.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAPPOSTECH_FASE2.Services.Services
{
    public class ServicoGenerico<TEntity> : IServicoGenerico<TEntity> where TEntity : class
    {
        protected readonly IRepositorioGenerico<TEntity> _repositorioGenerico;

        public ServicoGenerico(IRepositorioGenerico<TEntity> repositorioGenerico)
        {
            _repositorioGenerico = repositorioGenerico;
        }

        public virtual async Task<TEntity> Add(TEntity entity)
        {
            return await Task.FromResult(await _repositorioGenerico.Add(entity));
        }

        public async Task<bool> Delete(int id)
        {
            return await Task.FromResult(await _repositorioGenerico.Delete(id));
        }

        public virtual async Task<TEntity> Get(Func<TEntity, bool> func = null)
        {
          return await Task.FromResult(await _repositorioGenerico.Get(func));
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll(Func<TEntity, bool> func = null)
        {
            return await Task.FromResult(await _repositorioGenerico.GetAll(func));
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            return await Task.FromResult(await _repositorioGenerico.Update(entity));
        }
    }
}
