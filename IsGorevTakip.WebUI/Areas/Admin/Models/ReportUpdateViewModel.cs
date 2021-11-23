using IsGorevTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IsGorevTakip.WebUI.Areas.Admin.Models
{
    public class ReportUpdateViewModel
    {
        [Display(Name = "Tanım :")]
        [Required(ErrorMessage = "Tanım alanı bol geçilemez")]
        public string Definition { get; set; }
        [Display(Name = "Detay")]
        [Required(ErrorMessage = "Detay alanı bol geçilemez")]
        public string Detail { get; set; }
        public int JobWorkId { get; set; }
        public JobWork JobWorks { get; set; }
    }
}
