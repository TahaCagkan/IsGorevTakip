using IsGorevTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsGorevTakip.WebUI.Areas.Admin.Models
{
    public class JobWorkListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Is_Active_Status { get; set; }
        public DateTime CreateDate { get; set; }

        public int UrgencyId { get; set; }
        public virtual Urgency Urgency { get; set; }
    }
}
