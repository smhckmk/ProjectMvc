using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator() 
        {
            RuleFor(x => x.receiverMail).NotEmpty().WithMessage("alıcı mailini boş geçemezsiniz"); //alici
            RuleFor(x => x.subject).NotEmpty().WithMessage("konuyu boş geçemezsiniz");
            RuleFor(x => x.messageContent).NotEmpty().WithMessage("mesajı boş geçemezsiniz");
            RuleFor(x => x.subject).MaximumLength(50).WithMessage("lütfen en fazla 50 karakter giriniz");
        }
    }
}
