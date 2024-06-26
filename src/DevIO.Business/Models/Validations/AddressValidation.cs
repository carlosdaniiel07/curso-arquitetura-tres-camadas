﻿using FluentValidation;

namespace DevIO.Business.Models.Validations;

public class AddressValidation : AbstractValidator<Address>
{
    public AddressValidation()
    {
        RuleFor(x => x.Street)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
            .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

        RuleFor(x => x.Neighborhood)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
            .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

        RuleFor(x => x.ZipCode)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
            .Length(8).WithMessage("O campo {PropertyName} precisa ter {MaxLength} caracteres");

        RuleFor(x => x.Street)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
            .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

        RuleFor(x => x.State)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
            .Length(2).WithMessage("O campo {PropertyName} precisa ter {MaxLength} caracteres");

        RuleFor(x => x.Number)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
            .Length(1, 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
    }
}
