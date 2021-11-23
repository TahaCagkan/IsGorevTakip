using IsGorevTakip.Core.DAL;
using IsGorevTakip.DAL.Abstract;
using IsGorevTakip.DAL.EntityFramework.Context;
using IsGorevTakip.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IsGorevTakip.DAL.Concrete
{
    public class EfJobWorkRepository : EfGenericRepository<JobWork, IsGorevTakipContext>, IJobWorkDAL
    {
        private readonly IsGorevTakipContext context;
        public EfJobWorkRepository(IsGorevTakipContext context) : base(context)
        {
            this.context = context;
        }

        public List<JobWork> GetUrgencyNotOK()
        {
            //acil olan gorevler icerisinden durumu tamamlanmayanları olusturma tarihine gore listele getir
            var result = context.JobWork.Include(x => x.Urgency).Where(x => x.Is_Active_Status == false).OrderBy(x => x.CreateDate).ToList();
            return result;
        }
        public List<JobWork> GetAllTable()
        {
            var resultGelAllTable = context.JobWork.Include(x => x.Urgency).Include(x => x.Report).Include(x => x.AppUser).Where(x => x.Is_Active_Status == false).OrderBy(x => x.CreateDate).ToList();
            return resultGelAllTable;
        }
        public List<JobWork> GetAllTable(Expression<Func<JobWork, bool>> filter)
        {
            var resultGetAllTableFilter = context.JobWork.Include(x => x.Urgency).Include(x => x.Report).Include(x => x.AppUser).Where(filter).OrderByDescending(x => x.CreateDate).ToList();
            return resultGetAllTableFilter;
        }
        public JobWork GetUrgencyId(int id)
        {
            var getUrgencyId = context.JobWork.Include(x => x.Urgency).FirstOrDefault(x => !x.Is_Active_Status && x.Id == id);
            return getUrgencyId;
        }

        public List<JobWork> GetAppUserId(int appUserId)
        {
            var getAppUserId = context.JobWork.Where(x => x.AppUserId == appUserId).ToList();
            return getAppUserId;
        }

        public JobWork GetReportId(int id)
        {
            var getReportId = context.JobWork.Include(x => x.Report).Include(x => x.AppUser).Where(x => x.Id == id).FirstOrDefault();
            return getReportId;

        }

        public List<JobWork> GetAllTableNotOk(out int totalPage, int userId,int activePage = 1)
        {
            var resultGetAllTableNotOk = context.JobWork.Include(x => x.Urgency).Include(x => x.Report).Include(x => x.AppUser).Where(x => x.AppUserId == userId && x.Is_Active_Status).OrderByDescending(x => x.CreateDate).Skip((1 - activePage) * 3 ).Take(3);

            totalPage = (int)Math.Ceiling((double)resultGetAllTableNotOk.Count() / 3);

            return resultGetAllTableNotOk.ToList();
        }
    }
}
