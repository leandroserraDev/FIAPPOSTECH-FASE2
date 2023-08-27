using FIAPPOSTECH_FASE2.DOMAIN.Repositories;
using FIAPPOSTECH_FASE2.DOMAIN.ValueObjects;
using FIAPPOSTECH_FASE2.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAPPOSTECH_FASE2.Infra.Repositories
{
    public class RepositorioGenerico<TEntity> : IRepositorioGenerico<TEntity> where TEntity : class
    
    {
        protected readonly ApplicationDbContext _dbContext;

        public RepositorioGenerico(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            _dbContext.Add<TEntity>(entity);
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = _dbContext.Find<TEntity>(id);
            if (entity == null)
            {
                return false;
            }

            _dbContext.Remove<TEntity>(entity);

            return await Task.FromResult(true);
        }

        public async Task<TEntity> Get(Func<TEntity, bool> func = null)
        {
            var result = _dbContext.Set<TEntity>()
                .FirstOrDefault(func);

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<TEntity>> GetAll(Func<TEntity, bool> func = null)
        {
            var result = _dbContext.Set<TEntity>()
                .Where(func)
                .ToList();

            return await Task.FromResult(result);

        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Attach(entity);
            _dbContext.Entry<TEntity>( entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            return await Task.FromResult(entity);
        }
    }
}
