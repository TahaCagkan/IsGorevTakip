using IsGorevTakip.Core.Enitiy.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IsGorevTakip.Entities.Concrete
{
    public class JobWork:IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Is_Active_Status { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public int UrgencyId { get; set; }
        public virtual Urgency Urgency { get; set; }

        public int? AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }

        public virtual List<Report> Report { get; set; }

    }
}
