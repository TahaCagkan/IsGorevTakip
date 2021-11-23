using System;
using System.Collections.Generic;
using System.Text;

namespace IsGorevTakip.DTO.DTos.AppUserDtos
{
    public class AppUserSignInDto
    {
        //[Required(ErrorMessage = "Kullanıcı Adı boş geçilemez")]
        //[Display(Name = "Kullanıcı Adı :")]
        public string UserName { get; set; }

        //[Display(Name = "Parola :")]
        //[DataType(DataType.Password)]
        //[Required(ErrorMessage = "Parola alanı boş geçilemez")]
        public string Password { get; set; }

        //[Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }

    }
}
