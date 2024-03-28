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
