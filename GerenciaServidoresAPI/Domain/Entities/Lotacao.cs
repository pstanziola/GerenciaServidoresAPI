namespace GerenciaServidoresAPI.Domain.Entities;

public class Lotacao
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Nome { get; set; } = null!;

    public ICollection<Servidor> Servidores { get; set; } = new List<Servidor>();
}
