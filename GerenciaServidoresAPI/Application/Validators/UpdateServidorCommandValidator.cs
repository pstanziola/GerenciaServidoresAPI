using FluentValidation;
using GerenciaServidoresAPI.Application.Commands.UpdateServidor;

namespace GerenciaServidoresAPI.Application.Validators;

public class UpdateServidorCommandValidator : AbstractValidator<UpdateServidorCommand>
{
    public UpdateServidorCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id do Servidor é obrigatória.");
        RuleFor(x => x.Nome).NotEmpty().WithMessage("Nome do Servidor é obrigatório.");
        RuleFor(x => x.OrgaoId).NotEmpty().WithMessage("Orgão do Servidor é obrigatório.");
        RuleFor(x => x.LotacaoId).NotEmpty().WithMessage("Locação do Servidor é obrigatória.");
    }
}
