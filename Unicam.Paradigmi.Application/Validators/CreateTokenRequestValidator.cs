using FluentValidation;
using Unicam.Paradigmi.Application.Extensions;
using Unicam.Paradigmi.Application.Models.Requests;

namespace Unicam.Paradigmi.Application.Validators
{
    public class CreateTokenRequestValidator : AbstractValidator<CreateTokenRequest>
    {
        // metodo costruttore dove vengono definite le regole dei campi Email e Password per la creazione del token
        public CreateTokenRequestValidator()
        {
            RuleFor(r => r.Email)
                .NotNull()
                .WithMessage("Il campo Email non può essere nullo")
                .NotEmpty()
                .WithMessage("Il campo Email non puó essere vuoto")
                .EmailAddress()
                .WithMessage("Il campo Email deve essere un indirizzo email valido");

            RuleFor(r => r.Password)
                .NotNull()
                .WithMessage("Il campo password non può essere nullo")
                .NotEmpty()
                .WithMessage("Il campo password non puó essere vuoto")
                .MinimumLength(6)
                .WithMessage("Il campo password deve essere almeno lungo 6 caratteri")
                .RegEx("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)(?=.*[!@#$%^&*()_+{}\\[\\]:;<>,.?~\\\\-]).{6,}$" //Esempio con le RegeEx invece di Matches
                , "Il campo password deve essere lungo almeno 6 caratteri e deve contenere almeno un carattere maiuscolo, uno minuscolo, un numero e un carattere speciale"
                );
        }
        }
}
