using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Application.Models.Requests;

namespace Unicam.Paradigmi.Application.Validators
{
    public class CreateCorsoRequestValidator : AbstractValidator<CreateCorsoRequest>
    {
        public CreateCorsoRequestValidator()
        {
           
            RuleFor(c => c.NomeCorso)
                .NotEmpty()
                .WithMessage("Il campo NomeCorso è obbligatorio")
                .NotNull()
                .WithMessage("Il campo NomeCorso non può essere nullo")
                .MaximumLength(100)
                .WithMessage("Il campo NomeCorso non può superare i 100 caratteri");

            RuleFor(c => c.NOre)
                .NotEmpty()
                .WithMessage("Il campo NOre è obbligatorio")
                .GreaterThan(0)
                .WithMessage("Il campo NOre deve essere maggiore di 0");
        }
    }
}
