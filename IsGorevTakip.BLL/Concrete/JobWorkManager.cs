using IsGorevTakip.BLL.Abstract;
using IsGorevTakip.DAL.Abstract;
using IsGorevTakip.DAL.Concrete;
using IsGorevTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsGorevTakip.BLL.Concrete
{
    public class JobWorkManager : IJobWorkService
    {
        private readonly IJobWorkDAL _jobWorkDAL;

        public JobWorkManager(IJobWorkDAL jobWorkDAL)
        {
            _jobWorkDAL = jobWorkDAL;
        }

        public List<JobWork> GetAll()
        {
            return _jobWorkDAL.GetAll();
        }

        public JobWork GetId(int id)
        {
            return _jobWorkDAL.GetId(id);
        }

        public void Delete(JobWork entity)
        {
            _jobWorkDAL.Delete(entity);
        }

        public void Save(JobWork entity)
        {
            _jobWorkDAL.Save(entity);
        }

        public void Update(JobWork entity)
        {
            _jobWorkDAL.Update(entity);
        }

        public List<JobWork> GetUrgencyNotOK()
        {
            return _jobWorkDAL.GetUrgencyNotOK();
        }

        public List<JobWork> GetAllTable()
        {
            return _jobWorkDAL.GetAllTable();
        }

        public JobWork GetUrgencyId(int id)
        {
            return _jobWorkDAL.GetUrgencyId(id);
        }

        public List<JobWork> GetAppUserId(int appUserId)
        {
            return _jobWorkDAL.GetAppUserId(appUserId);
        }
    }
}
