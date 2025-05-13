using GerenciaServidoresAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GerenciaServidoresAPI.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Servidor> Servidores => Set<Servidor>();
    public DbSet<Orgao> Orgaos => Set<Orgao>();
    public DbSet<Lotacao> Lotacoes => Set<Lotacao>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Servidor>(entity =>
        {
            entity.HasKey(s => s.Id);
            entity.Property(s => s.Nome).IsRequired();
            entity.HasOne(s => s.Orgao)
                  .WithMany(o => o.Servidores)
                  .HasForeignKey(s => s.OrgaoId);

            entity.HasOne(s => s.Lotacao)
                  .WithMany(l => l.Servidores)
                  .HasForeignKey(s => s.LotacaoId);
        });

        modelBuilder.Entity<Orgao>().HasKey(o => o.Id);
        modelBuilder.Entity<Orgao>().Property(o => o.Nome).IsRequired();

        modelBuilder.Entity<Lotacao>().HasKey(l => l.Id);
        modelBuilder.Entity<Lotacao>().Property(l => l.Nome).IsRequired();

        var orgao1 = new Orgao { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), Nome = "Secretaria de Saúde" };
        var orgao2 = new Orgao { Id = Guid.Parse("11111111-1111-1111-1111-222222222222"), Nome = "Secretaria de Educação" };

        var lotacao1 = new Lotacao { Id = Guid.Parse("22222222-2222-2222-2222-111111111111"), Nome = "Hospital Municipal" };
        var lotacao2 = new Lotacao { Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), Nome = "Escola Estadual" };

        modelBuilder.Entity<Orgao>().HasData(orgao1, orgao2);
        modelBuilder.Entity<Lotacao>().HasData(lotacao1, lotacao2);

    }
}
