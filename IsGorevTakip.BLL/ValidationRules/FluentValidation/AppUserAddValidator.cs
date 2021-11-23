using FluentValidation;
using IsGorevTakip.DTO.DTos.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsGorevTakip.BLL.ValidationRules.FluentValidation
{
    public class AppUserAddValidator: AbstractValidator<AppUserAddDto>
    {
        public AppUserAddValidator()
        {
            RuleFor(x => x.UserName).NotNull().WithMessage("Kullanıcı Adı boş geçilemez.");

            RuleFor(x => x.Password).NotNull().WithMessage("Parola alanı boş geçilemez.");

            RuleFor(x => x.ConfirmPassword).NotNull().WithMessage("Parolanız eşleşmiyor.");

            RuleFor(x => x.Email).NotNull().WithMessage("Email alanı boş geçilemez.").EmailAddress().WithMessage("Geçersiz email adresi");

            RuleFor(x => x.Name).NotNull().WithMessage("Ad alanı boş geçilemez");

            RuleFor(x => x.LastName).NotNull().WithMessage("Soyad alanı boş geçilemez");
        }
    }
}
