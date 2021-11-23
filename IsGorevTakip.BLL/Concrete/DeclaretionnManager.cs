using IsGorevTakip.BLL.Abstract;
using IsGorevTakip.DAL.Abstract;
using IsGorevTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsGorevTakip.BLL.Concrete
{
    public class DeclaretionnManager : IDeclaretionnService
    {
        public readonly IDeclaretionnDal _declaretionnDal;
        public DeclaretionnManager(IDeclaretionnDal declaretionnDal)
        {
            _declaretionnDal = declaretionnDal;
        }
        public void Delete(Declarationn entity)
        {
            _declaretionnDal.Delete(entity);
        }

        public List<Declarationn> GetAll()
        {
            return _declaretionnDal.GetAll();
        }

        public Declarationn GetId(int id)
        {
            return _declaretionnDal.GetId(id);
        }

        public List<Declarationn> GetNotReaded(int AppUserId)
        {
            return _declaretionnDal.GetNotReaded(AppUserId);
        }

        public void Save(Declarationn entity)
        {
            _declaretionnDal.Save(entity);
        }

        public void Update(Declarationn entity)
        {
            _declaretionnDal.Update(entity);
        }
    }
}
