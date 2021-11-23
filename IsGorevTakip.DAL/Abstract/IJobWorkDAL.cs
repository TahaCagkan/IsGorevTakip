using IsGorevTakip.Core.DAL;
using IsGorevTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace IsGorevTakip.DAL.Abstract
{
    public interface IJobWorkDAL : IGenericRepository<JobWork>
    {
        List<JobWork> GetUrgencyNotOK();
        List<JobWork> GetAllTable();
        List<JobWork> GetAllTable(Expression<Func<JobWork,bool>> filter);
        List<JobWork> GetAllTableNotOk(out int totalPage, int userId,int activePage);
        JobWork GetUrgencyId(int id);
        List<JobWork> GetAppUserId(int appUserId);
        JobWork GetReportId(int id);
    }
}
