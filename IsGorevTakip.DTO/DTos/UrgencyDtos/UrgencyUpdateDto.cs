using System;
using System.Collections.Generic;
using System.Text;

namespace IsGorevTakip.DTO.DTos.UrgencyDtos
{
    public class  UrgencyUpdateDto
    {
        public int Id { get; set; }
        /*[Display(Name = "Tanım :")]
        [Required(ErrorMessage = "Tanım alanı gereklidir.")]*/
        public string Definition { get; set; }
    }
}
