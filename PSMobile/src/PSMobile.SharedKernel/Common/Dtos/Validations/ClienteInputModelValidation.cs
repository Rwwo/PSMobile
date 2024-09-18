using FluentValidation;

namespace PSMobile.SharedKernel.Common.Dtos.Validations;

public class ClienteInputModelValidation : AbstractValidator<CadastroInputModel>
{
    public ClienteInputModelValidation()
    {
        RuleFor(c => c.Nome)
            .NotEmpty()
            .NotNull()
            .WithMessage("O Nome é obrigatório");

        //RuleFor(c=>c.Fone1).
    }
}