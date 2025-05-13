namespace GerenciaServidoresAPI.Application.DTOs;

public class ServidorDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string? Telefone { get; set; }
    public string? Email { get; set; }
    public Guid OrgaoId { get; set; }
    public string Orgao { get; set; } = string.Empty;
    public Guid LotacaoId { get; set; }
    public string Lotacao { get; set; } = string.Empty;
    public string? Sala { get; set; }
    public bool Ativo { get; set; }
}
