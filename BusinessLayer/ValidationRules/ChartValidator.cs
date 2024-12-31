using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class ChartValidator : AbstractValidator<Chart>
    {
        public ChartValidator()
        {
            RuleFor(x => x.ChartName).NotEmpty().WithMessage("İsim Boş Geçilemez");
            RuleFor(x => x.ChartName).MaximumLength(50).WithMessage("İsim 50 Karekterden Fazla Olamaz!");
            RuleFor(x => x.ChartName).MinimumLength(3).WithMessage("İsim  3 Karekterden Az Olamaz!");
            RuleFor(x => x.ChartCount).NotEmpty().WithMessage("Sayısı İçeriği Boş Geçilemez");


        }
    }
}
