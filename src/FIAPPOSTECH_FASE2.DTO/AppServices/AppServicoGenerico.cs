using FIAPPOSTECH_FASE2.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAPPOSTECH_FASE2.DTO.AppServices
{
    public class AppServicoGenerico<TEntity> : IAppServicoGenerico<TEntity> where TEntity : class
    {
        protected readonly ServicoGenerico<TEntity> _servicoGenerico;

        public AppServicoGenerico(ServicoGenerico<TEntity> servicoGenerico)
        {
            _servicoGenerico = servicoGenerico;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            return await Task.FromResult(await _servicoGenerico.Add(entity));
        }

        public async Task<bool> Delete(int id)
        {
            return await Task.FromResult(await _servicoGenerico.Delete(id));
        }

        public async Task<TEntity> Get(Func<TEntity, bool> func = null)
        {
         return await Task.FromResult(await _servicoGenerico.Get(func));
            
        }

        public async Task<IEnumerable<TEntity>> GetAll(Func<TEntity, bool> func = null)
        {
            return await Task.FromResult(await _servicoGenerico.GetAll(func));
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            return await Task.FromResult(await _servicoGenerico.Update(entity));
        }
    }
}
