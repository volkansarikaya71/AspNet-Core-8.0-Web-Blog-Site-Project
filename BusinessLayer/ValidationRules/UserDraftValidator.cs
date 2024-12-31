using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class UserDraftValidator : AbstractValidator<UserDraft>
    {
        public UserDraftValidator()
        {
            RuleFor(x => x.DraftSubject).NotEmpty().WithMessage("Kategori İsmi Boş Geçilemez");
            RuleFor(x => x.DraftSubject).MaximumLength(50).WithMessage("Kategori İsmi 50 Karekterden Fazla Olamaz!");
            RuleFor(x => x.DraftSubject).MinimumLength(2).WithMessage("Kategori İsmi  2 Karekterden Az Olamaz!");
            RuleFor(x => x.DraftMessageDetails).NotEmpty().WithMessage("Kategori İsmi Boş Geçilemez");
            RuleFor(x => x.DraftMessageDetails).MaximumLength(2000).WithMessage("Kategori İsmi 2000 Karekterden Fazla Olamaz!");
            RuleFor(x => x.DraftMessageDetails).MinimumLength(10).WithMessage("Kategori İsmi  10 Karekterden Az Olamaz!");

        }
    }
}
