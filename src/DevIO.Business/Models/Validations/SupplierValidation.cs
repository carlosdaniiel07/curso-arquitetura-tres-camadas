using FluentValidation;
using NetDevPack.Brasil.Documentos.Validacao;

namespace DevIO.Business.Models.Validations;

public class SupplierValidation : AbstractValidator<Supplier>
{
    public SupplierValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
            .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

        When(x => x.Kind == SupplierKind.Person, () =>
        {
            RuleFor(x => x.Document!.Length).Equal(11)
                .WithMessage("O campo documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}");

            RuleFor(x => new CpfValidador(x.Document).EstaValido()).Equal(true)
                .WithMessage("O documento fornecido é inválido");
        });

        When(x => x.Kind == SupplierKind.Company, () =>
        {
            RuleFor(x => x.Document!.Length).Equal(14)
                .WithMessage("O campo documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}");

            RuleFor(x => new CnpjValidador(x.Document).EstaValido()).Equal(true)
                .WithMessage("O documento fornecido é inválido");
        });
    }
}
