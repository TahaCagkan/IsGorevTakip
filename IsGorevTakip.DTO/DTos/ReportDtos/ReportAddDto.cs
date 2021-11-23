using System;
using System.Collections.Generic;
using System.Text;

namespace IsGorevTakip.DTO.DTos.ReportDtos
{
    public class ReportAddDto
    {
        //[Display(Name = "Tanım :")]
        //[Required(ErrorMessage = "Tanım alanı bol geçilemez")]
        public string Definition { get; set; }
        //[Display(Name = "Detay")]
        //[Required(ErrorMessage = "Detay alanı bol geçilemez")]
        public string Detail { get; set; }
        public int JobWorkId { get; set; }

        //public JobWork JobWorks { get; set; }
    }
}
