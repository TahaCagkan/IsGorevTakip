using FluentValidation;
using IsGorevTakip.DTO.DTos.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsGorevTakip.BLL.ValidationRules.FluentValidation
{
    public class AppUserSignInValidator:AbstractValidator<AppUserSignInDto>
    {
        public AppUserSignInValidator()
        {
            RuleFor(x => x.UserName).NotNull().WithMessage("Kullanıcı Adı boş geçilemez.");

            RuleFor(x => x.Password).NotNull().WithMessage("Parola alanı boş geçilemez.");
        }
    }
}
