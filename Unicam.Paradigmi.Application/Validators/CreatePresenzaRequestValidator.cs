using FluentValidation;
using Unicam.Paradigmi.Application.Models.Requests;

namespace Unicam.Paradigmi.Application.Validators
{
    public class CreatePresenzaRequestValidator :AbstractValidator<CreatePresenzaRequest>
    {
        // metodo costruttore dove vengono definite le regole dei campi DataOra inizio e fine di una presenza
        public CreatePresenzaRequestValidator()
        {
            RuleFor(c => c.IdLezione)
                .NotNull()
                .WithMessage("Il campo IdLezione non deve essere nullo")
                .NotEmpty()
                .WithMessage("Il campo idLezione non deve essere vuoto");

            RuleFor(c => c.EmailAlunno)
                .NotEmpty()
                .WithMessage("Il campo email é obbligatorio")
                .EmailAddress()
                .WithMessage("Il campo email deve essere una mail");

            RuleFor(c => c.DataOraInizio)
                .NotNull()
                .WithMessage("Il campo DataOraInizio non può essere nullo")
               .NotEmpty()
               .WithMessage("Il campo DataOraInizio non puó essere vuoto");

            RuleFor(c => c.DataOraFine)
                .NotNull()
                .WithMessage("Il campo DataOraFine non può essere nullo")
                .NotEmpty()
                .WithMessage("Il campo DataOraFine non puó essere vuoto")
                .GreaterThan(l => l.DataOraInizio)
                .WithMessage("Il campo DataOraFine deve essere maggiore o uguale a DataOraInizio");
        }
    }
}
