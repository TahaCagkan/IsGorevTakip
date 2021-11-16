using IsGorevTakip.Core.DAL;
using IsGorevTakip.Entities.Concrete;
using System.Collections.Generic;

namespace IsGorevTakip.DAL.Abstract
{
    public interface IJobWorkDAL : IGenericRepository<JobWork>
    {
        List<JobWork> GetUrgencyNotOK();
        List<JobWork> GetAllTable();
        JobWork GetUrgencyId(int id);
        List<JobWork> GetAppUserId(int appUserId);
    }
}
