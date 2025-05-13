using System;
using System.Threading.Tasks;
using FluentAssertions;
using GerenciaServidoresAPI.Application.Commands.DeleteServidor;
using GerenciaServidoresAPI.Domain.Entities;
using GerenciaServidoresAPI.Persistence;
using Xunit;

namespace GerenciaServidoresAPI.Tests.Commands;

public class DeleteServidorCommandHandlerTests
{
    private readonly TestFixture _fixture = new();

    [Fact]
    public async Task Deve_Inativar_Servidor_Com_Sucesso()
    {
        // Arrange
        var context = _fixture.CreateContext();

        var servidor = new Servidor
        {
            Id = Guid.NewGuid(),
            Nome = "Carlos Oliveira",
            OrgaoId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
            LotacaoId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            Ativo = true
        };

        context.Servidores.Add(servidor);
        await context.SaveChangesAsync();

        var handler = new DeleteServidorCommandHandler(context);

        // Act
        var result = await handler.Handle(new DeleteServidorCommand(servidor.Id), default);

        // Assert
        result.Should().BeTrue();

        var inativo = context.Servidores.Find(servidor.Id);
        inativo!.Ativo.Should().BeFalse();
    }

    [Fact]
    public async Task Deve_Retornar_False_Se_Servidor_Nao_Encontrado()
    {
        var context = _fixture.CreateContext();
        var handler = new DeleteServidorCommandHandler(context);

        var result = await handler.Handle(new DeleteServidorCommand(Guid.NewGuid()), default);
        result.Should().BeFalse();
    }
}
