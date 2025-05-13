using MediatR;
using Microsoft.EntityFrameworkCore;
using GerenciaServidoresAPI.Persistence;

namespace GerenciaServidoresAPI.Application.Commands.DeleteServidor;

public class DeleteServidorCommandHandler : IRequestHandler<DeleteServidorCommand, bool>
{
    private readonly ApplicationDbContext _context;

    public DeleteServidorCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteServidorCommand request, CancellationToken cancellationToken)
    {
        var servidor = await _context.Servidores
            .FirstOrDefaultAsync(s => s.Id == request.Id && s.Ativo, cancellationToken);

        if (servidor == null)
            return false;

        servidor.Ativo = false;
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
