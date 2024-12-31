using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message2>
    {
        public MessageValidator()
        {
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Mesaj Başlığı Boş Geçilemez");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Mesaj Başlığı 50 Karekterden Fazla Olamaz!");
            RuleFor(x => x.Subject).MinimumLength(5).WithMessage("Mesaj Başlığı 5 Karekterden Az Olamaz!");
            RuleFor(x => x.MessageDetails).NotEmpty().WithMessage("Mesaj İçeriği Boş Geçilemez");
            RuleFor(x => x.MessageDetails).MaximumLength(2000).WithMessage("Mesaj İçeriği 2000 Karekterden Fazla Olamaz!");
            RuleFor(x => x.MessageDetails).MinimumLength(5).WithMessage("Mesaj İçeriği 5 Karekterden Az Olamaz!");
        }
    }
}
