using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.userMail).NotEmpty().WithMessage("mail adresini boş bırakamazsınız");
            RuleFor(x => x.subject).NotEmpty().WithMessage("konu adını boş bırakamazsınız");
            RuleFor(x => x.userName).NotEmpty().WithMessage("kullanıcı adını boş bırakamazsınız");
            RuleFor(x => x.subject).NotEmpty().WithMessage("lutfen en az üç karakter giriniz");
            RuleFor(x => x.userMail).MinimumLength(3).WithMessage("lutfen en fazla 20 karakter giriniz");
            RuleFor(x => x.subject).MaximumLength(50).WithMessage("lutfen en fazla 50 karakter giriniz");


        }
    }
}
