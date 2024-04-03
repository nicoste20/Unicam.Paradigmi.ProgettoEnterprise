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
                .WithMessage("Il campo IdCorso è obbligatorio")
                .NotEmpty()
                .WithMessage("Il campo IdCorso non può essere nullo");
        }
    }
}
