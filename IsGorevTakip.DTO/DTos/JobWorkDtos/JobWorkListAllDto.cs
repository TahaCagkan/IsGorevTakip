using IsGorevTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsGorevTakip.DTO.DTos.JobWorkDtos
{
    public class JobWorkListAllDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual Urgency Urgency { get; set; }
        public virtual AppUser AppUser { get; set; }
        public virtual List<Report> Report { get; set; }
    }
}
