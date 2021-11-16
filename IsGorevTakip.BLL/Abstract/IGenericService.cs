using IsGorevTakip.Core.Enitiy.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsGorevTakip.BLL.Abstract
{
    public interface IGenericService<TEntity> where TEntity : class, IBaseEntity, new()
    {
        TEntity GetId(int id);
        List<TEntity> GetAll();
        void Save(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}
