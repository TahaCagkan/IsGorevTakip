using IsGorevTakip.DAL.Abstract;
using IsGorevTakip.DAL.EntityFramework.Context;
using IsGorevTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IsGorevTakip.DAL.Concrete
{
    public class EfDeclaretionnRepository :EfGenericRepository<Declarationn, IsGorevTakipContext>, IDeclaretionnDal
    {
        private readonly IsGorevTakipContext context;
        public EfDeclaretionnRepository(IsGorevTakipContext context) : base(context)
        {
            this.context = context;
        }

        public List<Declarationn> GetNotReaded(int AppUserId)
        {
            return context.Declarationns.Where(x => x.AppUserId == AppUserId && !x.Is_Active_Status).ToList();
        }
    }
}
