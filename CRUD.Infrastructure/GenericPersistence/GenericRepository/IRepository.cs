using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Infrastructure.GenericPersistence.GenericRepository
{
    public interface IRepository<TEntity>
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetByIdAsync(int id);
        void MassDelete(List<TEntity> entities);
        void MassDelete(ICollection<TEntity> entities);
        void MassDelete(IQueryable<TEntity> entities);
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Attach(TEntity entity);
        void Edit(TEntity entity, string propertyName);
        void Edit(TEntity entity, string[] propertysName);
    }
}
