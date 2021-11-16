using IsGorevTakip.Core.Enitiy.Abstract;
using System.Collections.Generic;

namespace IsGorevTakip.Core.DAL
{
    public interface IGenericRepository<TEntity> where TEntity : class, IBaseEntity, new()
    {
        TEntity GetId(int id);
        List<TEntity> GetAll();
        void Save(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }

}
