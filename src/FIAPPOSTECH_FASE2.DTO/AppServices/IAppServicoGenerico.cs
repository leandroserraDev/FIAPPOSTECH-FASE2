using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAPPOSTECH_FASE2.DTO.AppServices
{
    public interface IAppServicoGenerico<TEntity> where TEntity : class
    {
        Task<TEntity> Get(Func<TEntity, bool> func = null);
        Task<IEnumerable<TEntity>> GetAll(Func<TEntity, bool> func = null);
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<bool> Delete(int id);
    }
}
