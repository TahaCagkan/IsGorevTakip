using IsGorevTakip.Core.Enitiy.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsGorevTakip.Entities.Concrete
{
    public class Urgency:IBaseEntity
    {
        public int Id { get; set; }
        public string Definition { get; set; }

        public virtual List<JobWork> JobWork { get; set; }
    }
}
