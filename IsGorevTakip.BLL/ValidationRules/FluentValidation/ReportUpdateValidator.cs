using FluentValidation;
using IsGorevTakip.DTO.DTos.ReportDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsGorevTakip.BLL.ValidationRules.FluentValidation
{
    public class ReportUpdateValidator : AbstractValidator<ReportUpdateDto>
    {
        public ReportUpdateValidator()
        {
            RuleFor(x => x.Definition).NotNull().WithMessage("Tanım alanı boş geçilemez.");
            RuleFor(x => x.Detail).NotNull().WithMessage("Detay alanı boş geçilemez.");
        }
    }
}
