using System;
using System.Collections.Generic;
using System.Text;

namespace IsGorevTakip.DTO.DTos.JobWorkDtos
{
    public class JobWorkUpdateDto
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "Ad alanı gereklidir.")]
        public string Name { get; set; }
        public string Description { get; set; }
        //[Range(0, int.MaxValue, ErrorMessage = "Lütfen bir aciliyet durumu seçiniz.")]
        public int UrgencyId { get; set; }
    }
}
