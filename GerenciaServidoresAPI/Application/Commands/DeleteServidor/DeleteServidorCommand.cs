using MediatR;

namespace GerenciaServidoresAPI.Application.Commands.DeleteServidor;

public class DeleteServidorCommand : IRequest<bool>
{
    public Guid Id { get; set; }

    public DeleteServidorCommand(Guid id) => Id = id;
}
