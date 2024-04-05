using FluentValidation;
using Unicam.Paradigmi.Application.Extensions;
using Unicam.Paradigmi.Application.Models.Requests;

namespace Unicam.Paradigmi.Application.Validators
{
    public class CreateUtenteRequestValidator : AbstractValidator<CreateUtenteRequest>
    {
        // metodo costruttore dove vengono definite le regole dei campi Email, Password, Nome e Cognome di un nuovo utente
        public CreateUtenteRequestValidator()
        {
            RuleFor(r => r.Email)
                .NotNull()
                .WithMessage("Il campo username non può essere nullo")
                .NotEmpty()
                .WithMessage("Il campo username non puó essere vuoto")
                .EmailAddress()
                .WithMessage("Il campo username deve essere un indirizzo email valido");

            RuleFor(r => r.Password)
                .NotNull()
                .WithMessage("Il campo password non può essere nullo")
                .NotEmpty()
                .WithMessage("Il campo password non puó essere vuoto")
                .MinimumLength(6)
                .WithMessage("Il campo password deve essere almeno lungo 6 caratteri")
                .RegEx("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)(?=.*[!@#$%^&*()_+{}\\[\\]:;<>,.?~\\\\-]).{6,}$"
                , "Il campo password deve essere lungo almeno 6 caratteri e deve contenere almeno un carattere maiuscolo, uno minuscolo, un numero e un carattere speciale"
                );
            
            RuleFor(r => r.Nome)
                .NotNull()
                .WithMessage("Il campo nome non può essere nullo")
                .NotEmpty()
                .WithMessage("Il campo nome non puó essere vuoto")
                .MinimumLength(4)
                .WithMessage("Il campo nome deve contenere almeno 4 caratteri")
                .Matches("^[A-Za-zÀ-ÖØ-öø-ÿ\\s]*$")
                .WithMessage("Il campo nome può contenere solo lettere e spazi");

            RuleFor(r => r.Cognome)
                .NotNull()
                .WithMessage("Il campo cognome non può essere nullo")
                .NotEmpty()
                .WithMessage("Il campo cognome non puó essere vuoto")
                .MinimumLength(4)
                .WithMessage("Il campo cognome deve contenere almeno 4 caratteri")
                .Matches("^[A-Za-zÀ-ÖØ-öø-ÿ\\s]*$")
                .WithMessage("Il campo cognome può contenere solo lettere e spazi");

        }
    }
}
