using AgroSolutions.Identity.Service.Application.Dtos.Produtor;
using FluentValidation;

namespace AgroSolutions.Identity.Service.Application.Dtos.Produtor.Validations;

public class EfetuarLoginDtoValidator : AbstractValidator<EfetuarLoginDto>
{
    public EfetuarLoginDtoValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("O e-mail é obrigatório");

        RuleFor(x => x.Senha)
            .NotEmpty().WithMessage("A senha é obrigatória");
    }
}
