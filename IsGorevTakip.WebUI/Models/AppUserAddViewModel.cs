using System.ComponentModel.DataAnnotations;

namespace IsGorevTakip.WebUI.Models
{
    public class AppUserAddViewModel
    {
        [Required(ErrorMessage = "Kullanıcı Adı boş geçilemez")]
        [Display(Name = "Kullanıcı Adı :")]
        public string UserName { get; set; }

        [Display(Name = "Parola :")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Parola alanı boş geçilemez")]
        public string Password { get; set; }

        [Display(Name = "Parola Tekrar Giriniz :")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Parolalar eşleşmiyor")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Email :")]
        [EmailAddress(ErrorMessage = "Geçersiz Email")]
        [Required(ErrorMessage = "Email alanı boş geçilemez")]
        public string Email { get; set; }

        [Display(Name = "Adınız :")]
        [Required(ErrorMessage = "Ad alanı boş geçilemez")]
        public string Name { get; set; }

        [Display(Name = "Soyadınız :")]
        [Required(ErrorMessage = "Soyad alanı boş geçilemez")]
        public string LastName { get; set; }
    }
}
