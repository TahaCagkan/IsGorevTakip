using IsGorevTakip.Core.Enitiy.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsGorevTakip.Entities.Concrete
{
    public class Report: IBaseEntity
    {
        public int Id { get; set; }
        public string Definition { get; set; }
        public string Detail { get; set; }

        public int JobWorkId { get; set; }
        public virtual JobWork JobWork { get; set; }
    }
}
