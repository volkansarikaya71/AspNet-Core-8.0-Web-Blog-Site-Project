using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName)
                .NotEmpty().WithMessage("Kullanıcı adı kısmı boş geçilemez.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.WriterName)
                        .MinimumLength(2).WithMessage("Kullanıcı adı kısmı en az 2 karakter olmalıdır.")
                        .MaximumLength(50).WithMessage("Kullanıcı adı kısmı en fazla 50 karakter olmalıdır.");
                });

            RuleFor(x => x.WriterMail)
                .NotEmpty().WithMessage("Kullanıcı mail kısmı boş geçilemez.")
                .EmailAddress().WithMessage("Geçerli bir mail adresi giriniz.");

            RuleFor(x => x.WriterPassword)
                .NotEmpty().WithMessage("Kullanıcı şifre kısmı boş geçilemez.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.WriterPassword)
                .Matches(@"[A-Z]+").WithMessage("Sifre en az bir Büyük harf içermelidir.")
                .Matches(@"[a-z]+").WithMessage("Sifre en az bir kücük harf içermelidir.")
                .Matches(@"[0-9]+").WithMessage("Sifre en az bir Rakam içermelidir.");
                });
            RuleFor(x => x.WriterImage)
            .NotEmpty().WithMessage("Kullanıcı resmi kısmı boş geçilemez.Lütfen resim ekleyiniz.");

        }

    }
}
