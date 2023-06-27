using Core.DomainLayer.Data;
using Data.RepositoryLayer.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.RepositoryLayer.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        AppDbContext _dbContext;
        DbSet<TEntity> _entities;
        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _entities = _dbContext.Set<TEntity>();
        }

        public virtual async Task<TEntity> FindByIdAsync(int id)
        {
            return await _entities.FindAsync(id);
        }

        public Task InsertAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteByIdAsync(int id)
        {
            //throw new NotImplementedException();
            var entity = await _entities.FindAsync(id);

            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _entities.Remove(entity);

            _dbContext.SaveChanges();
        }
    }
}
