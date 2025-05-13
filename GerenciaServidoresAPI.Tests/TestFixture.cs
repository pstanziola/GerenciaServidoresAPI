using System;
using GerenciaServidoresAPI.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GerenciaServidoresAPI.Tests;

public class TestFixture
{
    public ApplicationDbContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()) // novo DB a cada teste
            .Options;

        var context = new ApplicationDbContext(options);

        context.Orgaos.Add(new() { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), Nome = "Secretaria de TI" });
        context.Lotacoes.Add(new() { Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), Nome = "Setor de Infraestrutura" });
        context.SaveChanges();

        return context;
    }
}
