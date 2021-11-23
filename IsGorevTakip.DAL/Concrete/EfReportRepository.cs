using IsGorevTakip.DAL.Abstract;
using IsGorevTakip.DAL.EntityFramework.Context;
using IsGorevTakip.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace IsGorevTakip.DAL.Concrete
{
    public class EfReportRepository: EfGenericRepository<Report, IsGorevTakipContext>, IReportatDal
    {
        private readonly IsGorevTakipContext context;
        public EfReportRepository(IsGorevTakipContext context) : base(context)
        {
            this.context = context;
        }

        public Report GetReportJobWorkId(int id)
        {
            return context.Report.Include(x => x.JobWork).ThenInclude(x => x.Urgency).Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
