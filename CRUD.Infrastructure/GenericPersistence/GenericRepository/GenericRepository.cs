using CRUD.Infrastructure.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Infrastructure.GenericPersistence.GenericRepository
{
    public class GenericRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class
        where TContext : AppDataContext
    {
        protected readonly TContext _context;

        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(TContext context)
        {
            _dbSet = context.Set<TEntity>();
            _context = context;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public IQueryable<TEntity> GetAllReadOnly()
        {
            return _dbSet.AsNoTracking();
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<TEntity> GetByIdAsync(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual void MassDelete(List<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public virtual void MassDelete(ICollection<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public virtual void MassDelete(IQueryable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public virtual void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }


        public void Edit(TEntity entity, string propertyName)
        {
            _context.Entry(entity).Property(propertyName).IsModified = true;
        }

        public void Edit(TEntity entity, string[] propertysName)
        {
            if (propertysName != null && propertysName.Any())
            {
                foreach (var property in propertysName)
                    Edit(entity, property);
            }
        }

        public void Attach(TEntity entity)
        {
            _dbSet.Attach(entity);
        }

        public void MassAdd(List<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }
    }
}
