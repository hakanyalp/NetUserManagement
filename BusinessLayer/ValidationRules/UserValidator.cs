using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Username).NotEmpty().NotNull().WithMessage("Kullanıcı adı boş bırakılamaz ");
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("İsim boş bırakılamaz ");
            RuleFor(x => x.Surname).NotEmpty().NotNull().WithMessage("Soyisim boş bırakılamaz ");
            RuleFor(x => x.Password).NotEmpty().NotNull().WithMessage("Şifre boş bırakılamaz ")
                .MinimumLength(6).WithMessage("En az 6 karakter girmelisiniz ")
                .MaximumLength(12).WithMessage("En fazla 12 karakter girebilirsiniz ");
            RuleFor(x => x.Mail).NotEmpty().NotNull().WithMessage("Mail boş bırakılamaz ")
                .EmailAddress().WithMessage("Mail formatını kontrol ediniz ");
            RuleFor(x => x.PhoneNumber).NotEmpty().NotNull().WithMessage("Telefon numarası boş bırakılamaz ")
                .MinimumLength(9).WithMessage("Telefon numarası en az 9 karakterli olmalıdır ")
                .MaximumLength(11).WithMessage("Telefon numarası 1 karakteri geçemeze ")
                .Matches(@"((\+90)|0)[.\- ]?[0-9][.\- ]?[0-9][.\- ]?[0-9]").WithMessage("Telefon numaranızı boşluksuz, sadece sayı olacak şekilde ve başına 0 ekleyerek giriş yapın ");

        }
    }
}
