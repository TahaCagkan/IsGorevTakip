using System;
using System.ComponentModel.DataAnnotations;

namespace IsGorevTakip.WebUI.Areas.Admin.Models
{
    public class AddJobWorkViewModel
    {
        [Required(ErrorMessage ="Ad alanı gereklidir.")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(0, int.MaxValue,ErrorMessage ="Lütfen bir aciliyet durumu seçiniz.")]
        public int UrgencyId { get; set; }
    }
}
