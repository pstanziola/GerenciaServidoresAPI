using MediatR;
using Microsoft.EntityFrameworkCore;
using GerenciaServidoresAPI.Application.DTOs;
using GerenciaServidoresAPI.Persistence;

namespace GerenciaServidoresAPI.Application.Queries.GetServidores;

public class GetServidoresQueryHandler : IRequestHandler<GetServidoresQuery, List<ServidorDto>>
{
    private readonly ApplicationDbContext _context;

    public GetServidoresQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ServidorDto>> Handle(GetServidoresQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Servidores
            .Include(s => s.Orgao)
            .Include(s => s.Lotacao)
            .Where(s => s.Ativo)
            .AsQueryable();

        if (!string.IsNullOrEmpty(request.Nome))
            query = query.Where(s => s.Nome.Contains(request.Nome));

        if (!string.IsNullOrEmpty(request.Orgao))
            query = query.Where(s => s.Orgao.Nome.Contains(request.Orgao));

        if (!string.IsNullOrEmpty(request.Lotacao))
            query = query.Where(s => s.Lotacao.Nome.Contains(request.Lotacao));

        return await query.Select(s => new ServidorDto
        {
            Id = s.Id,
            Nome = s.Nome,
            Telefone = s.Telefone,
            Email = s.Email,
            OrgaoId = s.OrgaoId,
            Orgao = s.Orgao.Nome,
            Lotacao = s.Lotacao.Nome,
            LotacaoId = s.LotacaoId,
            Sala = s.Sala,
            Ativo = s.Ativo
        }).ToListAsync(cancellationToken);
    }
}
