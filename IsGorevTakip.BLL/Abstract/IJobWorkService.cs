using IsGorevTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace IsGorevTakip.BLL.Abstract
{
    public interface IJobWorkService : IGenericService<JobWork>
    {
        List<JobWork> GetUrgencyNotOK();
        List<JobWork> GetAllTable();
        List<JobWork> GetAllTable(Expression<Func<JobWork, bool>> filter);
        List<JobWork> GetAllTableNotOk(out int totalPage, int userId, int activePage=1);
        JobWork GetUrgencyId(int id);
        List<JobWork> GetAppUserId(int appUserId);
        JobWork GetReportId(int id);
    }
}
