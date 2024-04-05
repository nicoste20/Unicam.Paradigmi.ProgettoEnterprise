using FluentValidation;
using Unicam.Paradigmi.Application.Models.Requests;

namespace Unicam.Paradigmi.Application.Validators
{
    public class DeletePresenzaRequestValidator : AbstractValidator<DeletePresenzaRequest>
    {
        // metodo costruttore dove vengono definite le regole del campo IdPresenza
        public DeletePresenzaRequestValidator()
        {
            RuleFor(r=>r.IdPresenza)
                .NotNull()
                .WithMessage("Il campo IdCorso non puó essere null")
                .NotEmpty()
                .WithMessage("Il campo IdCorso non può essere vuoto");
        }
    }
}
