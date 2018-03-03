using System.Collections.Generic;
using System.Linq;

namespace Service.Repositories.Abstract
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        TEntity GetById(int id);
        TEntity Insert(TEntity entity);
        void Delete(int id);
        void Update(TEntity entity, int id);
    }
}