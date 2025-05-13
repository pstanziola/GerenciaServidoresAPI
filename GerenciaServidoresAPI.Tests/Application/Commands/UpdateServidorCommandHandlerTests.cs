using System;
using System.Threading.Tasks;
using FluentAssertions;
using GerenciaServidoresAPI.Application.Commands.UpdateServidor;
using GerenciaServidoresAPI.Domain.Entities;
using GerenciaServidoresAPI.Persistence;
using Xunit;

namespace GerenciaServidoresAPI.Tests.Commands;

public class UpdateServidorCommandHandlerTests
{
    private readonly TestFixture _fixture = new();

    [Fact]
    public async Task Deve_Atualizar_Servidor_Com_Sucesso()
    {
        // Arrange
        var context = _fixture.CreateContext();

        var servidor = new Servidor
        {
            Id = Guid.NewGuid(),
            Nome = "Maria Souza",
            Email = "maria@exemplo.com",
            Telefone = "1111",
            Sala = "C303",
            OrgaoId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
            LotacaoId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            Ativo = true
        };

        context.Servidores.Add(servidor);
        await context.SaveChangesAsync();

        var handler = new UpdateServidorCommandHandler(context);

        var command = new UpdateServidorCommand
        {
            Id = servidor.Id,
            Nome = "Maria Souza Atualizada",
            Email = "maria.nova@exemplo.com",
            Telefone = "2222",
            Sala = "D404",
            OrgaoId = servidor.OrgaoId,
            LotacaoId = servidor.LotacaoId
        };

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        result.Should().NotBeNull();
        result!.Nome.Should().Be("Maria Souza Atualizada");

        var atualizado = context.Servidores.Find(servidor.Id);
        atualizado!.Nome.Should().Be("Maria Souza Atualizada");
        atualizado.Email.Should().Be("maria.nova@exemplo.com");
    }

    [Fact]
    public async Task Deve_Retornar_Null_Se_Servidor_Nao_Encontrado()
    {
        var context = _fixture.CreateContext();
        var handler = new UpdateServidorCommandHandler(context);

        var command = new UpdateServidorCommand
        {
            Id = Guid.NewGuid(),
            Nome = "Inexistente",
            Email = "nao@existe.com",
            Telefone = "0000",
            Sala = "Z999",
            OrgaoId = Guid.NewGuid(),
            LotacaoId = Guid.NewGuid()
        };

        var result = await handler.Handle(command, default);
        result.Should().BeNull();
    }
}
