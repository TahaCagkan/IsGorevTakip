using IsGorevTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsGorevTakip.BLL.Abstract
{
    public interface IJobWorkService : IGenericService<JobWork>
    {
        List<JobWork> GetUrgencyNotOK();
        List<JobWork> GetAllTable();
        JobWork GetUrgencyId(int id);
        List<JobWork> GetAppUserId(int appUserId);



    }
}
