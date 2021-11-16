using IsGorevTakip.Core.DAL;
using IsGorevTakip.DAL.Abstract;
using IsGorevTakip.DAL.EntityFramework.Context;
using IsGorevTakip.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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
    }
}
