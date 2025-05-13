using MediatR;
using GerenciaServidoresAPI.Application.DTOs;
using GerenciaServidoresAPI.Domain.Entities;
using GerenciaServidoresAPI.Persistence;

namespace GerenciaServidoresAPI.Application.Commands.CreateServidor;

public class CreateServidorCommandHandler : IRequestHandler<CreateServidorCommand, ServidorDto>
{
    private readonly ApplicationDbContext _context;

    public CreateServidorCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ServidorDto> Handle(CreateServidorCommand request, CancellationToken cancellationToken)
    {
        var servidor = new Servidor
        {
            Nome = request.Nome,
            Telefone = request.Telefone,
            Email = request.Email,
            OrgaoId = request.OrgaoId,
            LotacaoId = request.LotacaoId,
            Sala = request.Sala,
            Ativo = true
        };

        _context.Servidores.Add(servidor);
        await _context.SaveChangesAsync(cancellationToken);

        return new ServidorDto
        {
            Id = servidor.Id,
            Nome = servidor.Nome,
            Telefone = servidor.Telefone,
            Email = servidor.Email,
            OrgaoId = servidor.OrgaoId,
            LotacaoId = servidor.LotacaoId,
            Sala = servidor.Sala,
            Ativo = servidor.Ativo
        };
    }
}
