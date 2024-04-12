
using DietaInteligente.Application.Commands.RestricoesDieteticas.Disassociate;
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Repositories;
using Moq;

namespace DietaInteligente.Tests.Application.Commands.RestricoesDieteticas.Disassociate;

public class DisassociateRestricaoDieteticaCommandHandlerTests
{
    private readonly Mock<IRestricaoDieteticaRepository> _restricaoDieteticaRepositoryMock;
    private readonly DisassociateRestricaoDieteticaCommandHandler _handler;

    public DisassociateRestricaoDieteticaCommandHandlerTests()
    {
        _restricaoDieteticaRepositoryMock = new Mock<IRestricaoDieteticaRepository>();
        _handler = new DisassociateRestricaoDieteticaCommandHandler(_restricaoDieteticaRepositoryMock.Object);
    }

    [Fact]
    public async void Handle_ValidCommand_RestricaoDieteticaShouldDisassociateAndReturnSuccess()
    {
        // Arrange
        var usuarioId = 1;
        var grupoAlimentar = 2;
        var command = new DisassociateRestricaoDieteticaCommand(usuarioId, grupoAlimentar);
        _restricaoDieteticaRepositoryMock.Setup(repo => repo.DesassociarRestricaoDieteticaAsync(It.IsAny<RestricaoDietetica>())).ReturnsAsync(true);

        // Act
        var result = await _handler.Handle(command, new CancellationToken());

        // Assert
        Assert.True(result.Success);
        Assert.Equal("Sucesso ao desassociar uma restricao de uma dieta!", result.Message);
    }

    [Fact]
    public async void Handle_InvalidCommand_RestricaoDieteticaShouldNotDisassociateAndReturnFailure()
    {
        // Arrange
        var usuarioId = 0;
        var grupoAlimentar = 0;
        var command = new DisassociateRestricaoDieteticaCommand(usuarioId, grupoAlimentar);
        _restricaoDieteticaRepositoryMock.Setup(repo => repo.DesassociarRestricaoDieteticaAsync(It.IsAny<RestricaoDietetica>())).ReturnsAsync(false);

        // Act
        var result = await _handler.Handle(command, new CancellationToken());

        // Assert
        Assert.False(result.Success);
        Assert.Contains("Falha ao desassociar uma restricao de uma dieta!", result.Errors);
    }
}
