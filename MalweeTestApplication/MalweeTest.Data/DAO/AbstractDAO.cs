using System.Collections.Generic;

namespace MalweeTest.Data.DAO
{
    public abstract class AbstractDAO<TEntity, TKey> where TEntity : class
    {
        public abstract List<TEntity> GetAll();
        public abstract TEntity GetById(TKey id);
        public abstract bool Save(TEntity entity);
        public abstract void Update(TEntity entity);
        public abstract bool Delete(TEntity entity);
        public abstract bool DeleteById(TKey id);
    }
}
