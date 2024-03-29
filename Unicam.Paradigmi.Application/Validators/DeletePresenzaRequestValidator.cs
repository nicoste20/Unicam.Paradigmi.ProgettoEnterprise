﻿using FluentValidation;
using Unicam.Paradigmi.Application.Models.Requests;

namespace Unicam.Paradigmi.Application.Validators
{
    public class DeletePresenzaRequestValidator : AbstractValidator<DeletePresenzaRequest>
    {
        public DeletePresenzaRequestValidator()
        {
            RuleFor(r=>r.IdPresenza)
                .NotNull()
                .WithMessage("Il campo IdCorso è obbligatorio")
                .NotEmpty()
                .WithMessage("Il campo IdCorso non può essere nullo");
        }
    }
}
