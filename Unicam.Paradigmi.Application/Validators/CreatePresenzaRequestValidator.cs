using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Application.Models.Requests;

namespace Unicam.Paradigmi.Application.Validators
{
    public class CreatePresenzaRequestValidator :AbstractValidator<CreatePresenzaRequest>
    {
        // metodo costruttore dove vengono definite le regole dei campi DataOra inizio e fine di una presenza
        public CreatePresenzaRequestValidator()
        {

            RuleFor(l => l.DataOraInizio)
               .NotEmpty()
               .WithMessage("Il campo DataOraInizio è obbligatorio");

            RuleFor(l => l.DataOraFine)
                .NotEmpty()
                .WithMessage("Il campo DataOraFine è obbligatorio")
                .GreaterThanOrEqualTo(l => l.DataOraInizio)
                .WithMessage("Il campo DataOraFine deve essere maggiore o uguale a DataOraInizio");
        }
    }
}
