using FluentValidation;
using Unicam.Paradigmi.Application.Models.Requests;

namespace Unicam.Paradigmi.Application.Validators
{
    public class SearchPresenzeRequestValidator : AbstractValidator<SearchPresenzeRequest>
    {
        public SearchPresenzeRequestValidator()
        {
            RuleFor(request => request)
                .Custom((request, context) =>
                {
                    if (string.IsNullOrEmpty(request.NomeCorso) &&
                        string.IsNullOrEmpty(request.CognomeStudente) &&
                        string.IsNullOrEmpty(request.CognomeDocente) &&
                        request.DataLezione == null)
                    {
                        context.AddFailure("Almeno uno dei campi deve essere specificato");
                    }
                });

            RuleFor(request => request.Pagina)
                .GreaterThan(0)
                .WithMessage("La pagina deve essere più grande di 0");

            RuleFor(request => request.DimensionePagina)
                .GreaterThan(0)
                .WithMessage("La dimensione della pagina deve essere più grande di 0");
        }
    }
}