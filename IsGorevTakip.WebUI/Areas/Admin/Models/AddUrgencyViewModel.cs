using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IsGorevTakip.WebUI.Areas.Admin.Models
{
    public class AddUrgencyViewModel
    {
        [Display(Name ="Tanım :")]
        [Required(ErrorMessage ="Tanım alanı boş geçilemez")]
        public string Definition { get; set; }
    }
}
