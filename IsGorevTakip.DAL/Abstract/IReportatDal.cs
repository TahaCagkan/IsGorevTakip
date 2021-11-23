using IsGorevTakip.Core.DAL;
using IsGorevTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsGorevTakip.DAL.Abstract
{
    public interface IReportatDal: IGenericRepository<Report>
    {
        Report GetReportJobWorkId(int id);
    }
}
