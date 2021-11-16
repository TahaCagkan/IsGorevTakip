using IsGorevTakip.DAL.Abstract;
using IsGorevTakip.DAL.EntityFramework.Context;
using IsGorevTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsGorevTakip.DAL.Concrete
{
    public class EfReportRepository: EfGenericRepository<Report, IsGorevTakipContext>, IReportatDal
    {
        private readonly IsGorevTakipContext context;
        public EfReportRepository(IsGorevTakipContext context) : base(context)
        {
            this.context = context;
        }
    }
}
