namespace GerenciaServidoresAPI.Domain.Entities;

public class Servidor
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Nome { get; set; } = null!;
    public string? Telefone { get; set; }
    public string? Email { get; set; }

    public Guid OrgaoId { get; set; }
    public Orgao Orgao { get; set; } = null!;

    public Guid LotacaoId { get; set; }
    public Lotacao Lotacao { get; set; } = null!;

    public string? Sala { get; set; }

    public bool Ativo { get; set; } = true;
}
