using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Application.Extensions;
using Unicam.Paradigmi.Application.Models.Requests;
using Unicam.Paradigmi.Application.Models.Responses;

namespace Unicam.Paradigmi.Application.Validators
{
    public class CreateUtenteRequestValidator : AbstractValidator<CreateUtenteRequest>
    {
        public CreateUtenteRequestValidator()
        {
            RuleFor(r => r.Email)
                .NotEmpty()
                .WithMessage("Il campo username è obbligatorio")
                .NotNull()
                .WithMessage("Il campo username non può essere nullo")
                .EmailAddress()
                .WithMessage("Il campo username deve essere un indirizzo email valido");

            RuleFor(r => r.Password)
                .NotEmpty()
                .WithMessage("Il campo password è obbligatorio")
                .NotNull()
                .WithMessage("Il campo password non può essere nullo")
                .MinimumLength(6)
                .WithMessage("Il campo password deve essere almeno lungo 6 caratteri")
                .RegEx("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)(?=.*[!@#$%^&*()_+{}\\[\\]:;<>,.?~\\\\-]).{6,}$"
                , "Il campo password deve essere lungo almeno 6 caratteri e deve contenere almeno un carattere maiuscolo, uno minuscolo, un numero e un carattere speciale"
                );
            
            RuleFor(r => r.Nome)
                .NotEmpty()
                .WithMessage("Il campo nome è obbligatorio")
                .NotNull()
                .WithMessage("Il campo nome non può essere nullo")
                .MinimumLength(4)
                .WithMessage("Il campo nome deve contenere almeno 4 caratteri")
                .Matches("^[A-Za-zÀ-ÖØ-öø-ÿ\\s]*$")
                .WithMessage("Il campo nome può contenere solo lettere e spazi");

            RuleFor(r => r.Cognome)
                .NotEmpty()
                .WithMessage("Il campo cognome è obbligatorio")
                .NotNull()
                .WithMessage("Il campo cognome non può essere nullo")
                .MinimumLength(4)
                .WithMessage("Il campo cognome deve contenere almeno 4 caratteri")
                .Matches("^[A-Za-zÀ-ÖØ-öø-ÿ\\s]*$")
                .WithMessage("Il campo cognome può contenere solo lettere e spazi");

        }
    }
}
