using MediatR;
using GerenciaServidoresAPI.Application.DTOs;

namespace GerenciaServidoresAPI.Application.Commands.UpdateServidor;

public class UpdateServidorCommand : IRequest<ServidorDto?>
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string? Telefone { get; set; }
    public string? Email { get; set; }
    public Guid OrgaoId { get; set; }
    public Guid LotacaoId { get; set; }
    public string? Sala { get; set; }
    public bool Ativo { get; set; } = true;
}
