using MediatR;
using Microsoft.EntityFrameworkCore;
using GerenciaServidoresAPI.Application.DTOs;
using GerenciaServidoresAPI.Persistence;

namespace GerenciaServidoresAPI.Application.Commands.UpdateServidor;

public class UpdateServidorCommandHandler : IRequestHandler<UpdateServidorCommand, ServidorDto?>
{
    private readonly ApplicationDbContext _context;

    public UpdateServidorCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ServidorDto?> Handle(UpdateServidorCommand request, CancellationToken cancellationToken)
    {
        // var servidor = await _context.Servidores
        //     .FirstOrDefaultAsync(s => s.Id == request.Id && s.Ativo, cancellationToken);

        var servidor = await _context.Servidores
            .FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken);

        if (servidor == null)
            return null;

        servidor.Nome = request.Nome;
        servidor.Telefone = request.Telefone;
        servidor.Email = request.Email;
        servidor.OrgaoId = request.OrgaoId;
        servidor.LotacaoId = request.LotacaoId;
        servidor.Sala = request.Sala;
        servidor.Ativo = request.Ativo; 

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
