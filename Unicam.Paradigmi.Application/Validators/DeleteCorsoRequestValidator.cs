using FluentValidation;
using Unicam.Paradigmi.Application.Models.Requests;

namespace Unicam.Paradigmi.Application.Validators
{
    public class DeleteCorsoRequestValidator :AbstractValidator<DeleteCorsoRequest>
    {
        // metodo costruttore dove vengono definite le regole del campo IdCorso
        public DeleteCorsoRequestValidator()
        {
            RuleFor(r => r.IdCorso)
                .NotNull()
                .WithMessage("Il campo IdCorso non puó essere null")
                .NotEmpty()
                .WithMessage("Il campo IdCorso non può essere vuoto");
        }
    }
}
