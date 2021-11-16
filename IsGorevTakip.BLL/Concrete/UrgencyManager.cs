using IsGorevTakip.BLL.Abstract;
using IsGorevTakip.DAL.Abstract;
using IsGorevTakip.DAL.Concrete;
using IsGorevTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsGorevTakip.BLL.Concrete
{
    public class UrgencyManager : IUrgencyService
    {
        private readonly IUrgencyDal _urgencyDal;
        public UrgencyManager(IUrgencyDal urgencyDal)
        {
            _urgencyDal = urgencyDal;
        }   

        public List<Urgency> GetAll()
        {
            return _urgencyDal.GetAll();
        }

        public Urgency GetId(int id)
        {
            return _urgencyDal.GetId(id);
        }

        public void Save(Urgency entity)
        {
            _urgencyDal.Save(entity);
        }
        public void Delete(Urgency entity)
        {
            _urgencyDal.Delete(entity);
        }

        public void Update(Urgency entity)
        {
            _urgencyDal.Update(entity);
        }
    }
}
