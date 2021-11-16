using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IsGorevTakip.WebUI.Areas.Admin.Models
{
    public class UpdateUrgencyViewModel
    {
        public int Id { get; set; }
        [Display(Name="Tanım :")]
        [Required(ErrorMessage ="Tanım alanı gereklidir.")]
        public string Definition { get; set; }
    }
}
