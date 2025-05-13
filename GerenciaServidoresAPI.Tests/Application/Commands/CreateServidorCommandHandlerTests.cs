using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using GerenciaServidoresAPI.Application.Commands.CreateServidor;
using GerenciaServidoresAPI.Persistence;
using Xunit;
using Xunit.Abstractions;

namespace GerenciaServidoresAPI.Tests.Commands;

public class CreateServidorCommandHandlerTests
{
    private readonly TestFixture _fixture = new();

    private readonly ITestOutputHelper _output;

    public CreateServidorCommandHandlerTests(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public async Task Deve_Criar_Servidor_Com_Sucesso()
    {
        // Arrange
        var context = _fixture.CreateContext();
        var handler = new CreateServidorCommandHandler(context);

        var command = new CreateServidorCommand
        {
            Nome = "João da Silva",
            Telefone = "123456789",
            Email = "joao@exemplo.com",
            OrgaoId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
            LotacaoId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            Sala = "B202"
        };

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        result.Should().NotBeNull();
        result.Nome.Should().Be("João da Silva");

        var saved = context.Servidores.SingleOrDefault(s => s.Id == result.Id);
        saved.Should().NotBeNull();
        saved!.Ativo.Should().BeTrue();

        _output.WriteLine($"Servidor criado com ID: {saved.Id}");
        _output.WriteLine($"Nome: {saved.Nome}");
        _output.WriteLine($"Orgao: {saved.OrgaoId}");
        _output.WriteLine($"Lotacao: {saved.LotacaoId}");
    }
}
