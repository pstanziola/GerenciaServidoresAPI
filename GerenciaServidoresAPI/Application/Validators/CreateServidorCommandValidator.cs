using FluentValidation;
using GerenciaServidoresAPI.Application.Commands.CreateServidor;

namespace GerenciaServidoresAPI.Application.Validators;

public class CreateServidorCommandValidator : AbstractValidator<CreateServidorCommand>
{
    public CreateServidorCommandValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("Nome do Servidor é obrigatório.");

        RuleFor(x => x.OrgaoId)
            .NotEmpty().WithMessage("Orgão do Servidor é obrigatório.");

        RuleFor(x => x.LotacaoId)
            .NotEmpty().WithMessage("Locação do Servidor é obrigatória.");
    }
}
