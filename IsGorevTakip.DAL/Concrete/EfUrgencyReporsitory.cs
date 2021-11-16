using IsGorevTakip.DAL.Abstract;
using IsGorevTakip.DAL.EntityFramework.Context;
using IsGorevTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsGorevTakip.DAL.Concrete
{
    public class EfUrgencyReporsitory:EfGenericRepository<Urgency, IsGorevTakipContext >,IUrgencyDal
    {
        private readonly IsGorevTakipContext context;
        public EfUrgencyReporsitory(IsGorevTakipContext context) : base(context)
        {
            this.context = context;
        }
    }
}
