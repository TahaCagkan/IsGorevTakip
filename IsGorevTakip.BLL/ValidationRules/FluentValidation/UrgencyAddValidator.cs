using FluentValidation;
using IsGorevTakip.DTO.DTos.UrgencyDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsGorevTakip.BLL.ValidationRules.FluentValidation
{
    public class UrgencyAddValidator : AbstractValidator<UrgencyAddDto>
    {
        public UrgencyAddValidator()
        {
            RuleFor(x => x.Definition).NotNull().WithMessage("Tanım alanı bol geçilemez");
        }
    }
}
