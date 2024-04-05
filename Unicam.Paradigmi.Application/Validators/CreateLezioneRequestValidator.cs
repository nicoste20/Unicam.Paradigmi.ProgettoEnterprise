using FluentValidation;
using Unicam.Paradigmi.Application.Models.Requests;

namespace Unicam.Paradigmi.Application.Validators
{
    public class CreateLezioneRequestValidator : AbstractValidator<CreateLezioneRequest>
    {
        // metodo costruttore dove vengono definite le regole dei campi DataOra inizio e fine, luogo e modalità di erogazione di una lezione
        public CreateLezioneRequestValidator()
        {
            RuleFor(l => l.IdCorso)
                .NotEmpty()
                .WithMessage("Il campo IdCorso non puó essere vuoto");

            RuleFor(l => l.DataOraInizio)
                .NotNull()
                .WithMessage("Il campo DataOraInizio non può essere nullo")
                .NotEmpty()
                .WithMessage("Il campo DataOraInizio non puó essere vuoto");
                

            RuleFor(l => l.DataOraFine)
                .NotNull()
                .WithMessage("Il campo DataOraFine non può essere nullo")
                .NotEmpty()
                .WithMessage("Il campo DataOraFine non puó essere vuoto")
                .GreaterThan(l => l.DataOraInizio)
                .WithMessage("Il campo DataOraFine deve essere maggiore o uguale a DataOraInizio");

            RuleFor(l => l.Luogo)
                .NotNull()
                .WithMessage("Il campo Luogo non può essere nullo")
                .NotEmpty()
                .WithMessage("Il campo Luogo non puó essere vuoto");

            RuleFor(l => l.Modalita)
                .NotEmpty()
                .WithMessage("Il campo Modalita non può essere vuoto")
                .IsInEnum()
                .WithMessage("Il campo Modalita deve essere o 1 o 2 (In presenza o A Distanza)");
        }
        
    }
}
