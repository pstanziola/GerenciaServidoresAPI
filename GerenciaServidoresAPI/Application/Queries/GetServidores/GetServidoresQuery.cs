using MediatR;
using GerenciaServidoresAPI.Application.DTOs;

namespace GerenciaServidoresAPI.Application.Queries.GetServidores;

public class GetServidoresQuery : IRequest<List<ServidorDto>>
{
    public string? Nome { get; set; }
    public string? Orgao { get; set; }
    public string? Lotacao { get; set; }
}
