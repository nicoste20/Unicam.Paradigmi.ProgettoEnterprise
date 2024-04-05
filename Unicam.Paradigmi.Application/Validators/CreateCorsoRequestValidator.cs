using FluentValidation;
using Unicam.Paradigmi.Application.Abstractions.Services;
using Unicam.Paradigmi.Application.Factories;
using Unicam.Paradigmi.Application.Models.Dtos;
using Unicam.Paradigmi.Application.Models.Requests;
using Unicam.Paradigmi.Application.Models.Responses;
using Unicam.Paradigmi.Application.Services;
using Unicam.Paradigmi.Models.Entities;
using Unicam.Paradigmi.Models.Repositories;

namespace Unicam.Paradigmi.Application.Validators
{
    public class CreateCorsoRequestValidator : AbstractValidator<CreateCorsoRequest>
    {
        private readonly ICorsoService _corsoService;
        public CreateCorsoRequestValidator(ICorsoService corsoService)
        {
            _corsoService = corsoService;

            RuleFor(c => c.NomeCorso)
                .NotNull()
                .WithMessage("Il campo NomeCorso non può essere nullo")
                .NotEmpty()
                .WithMessage("Il campo NomeCorso non puó essere vuoto")
                .MaximumLength(100)
                .WithMessage("Il campo NomeCorso non può superare i 100 caratteri");

            RuleFor(c => c.NOre)
                .NotEmpty()
                .WithMessage("Il campo NOre è obbligatorio")
                .GreaterThan(0)
                .WithMessage("Il campo NOre deve essere maggiore di 0");

            RuleFor(c => c.NomeCorso)
            .Custom(ValidaNomeCorso);
        }

        private async void ValidaNomeCorso(string value, ValidationContext<CreateCorsoRequest> context)
        {
            if (await _corsoService.ExistCorsoByNameAsync(value))
            {
               context.AddFailure("Esiste già un corso con lo stesso nome");
            }
        }
    }
}
