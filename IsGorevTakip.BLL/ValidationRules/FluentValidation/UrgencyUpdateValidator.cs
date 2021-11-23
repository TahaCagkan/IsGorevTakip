using FluentValidation;
using IsGorevTakip.DTO.DTos.UrgencyDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsGorevTakip.BLL.ValidationRules.FluentValidation
{
    public class UrgencyUpdateValidator: AbstractValidator<UrgencyUpdateDto>
    {
        public UrgencyUpdateValidator()
        {
            RuleFor(x => x.Definition).NotNull().WithMessage("Tanım alanı boş geçilemez");
        }
    }
}
