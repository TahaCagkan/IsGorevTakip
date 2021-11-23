using FluentValidation;
using IsGorevTakip.DTO.DTos.JobWorkDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsGorevTakip.BLL.ValidationRules.FluentValidation
{
    public class JobWorkAddValidator:AbstractValidator<JobWorkAddDto>
    {
        public JobWorkAddValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Ad alanı gereklidir.");
            RuleFor(x => x.UrgencyId).ExclusiveBetween(0, int.MaxValue).WithMessage("Lütfen bir aciliyet durumu seçiniz.");
        }
    }
}
