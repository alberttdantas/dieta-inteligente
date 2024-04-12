
using DietaInteligente.Application.Commands.RestricoesDieteticas.Associate;
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Repositories;
using Moq;

namespace DietaInteligente.Tests.Application.Commands.RestricoesDieteticas.Associate;

public class AssociateRestricaoDieteticaCommandHandlerTests
{
    private readonly Mock<IRestricaoDieteticaRepository> _restricaoDieteticaRepositoryMock;
    private readonly AssociateRestricaoDieteticaCommandHandler _handler;

    public AssociateRestricaoDieteticaCommandHandlerTests()
    {
        _restricaoDieteticaRepositoryMock = new Mock<IRestricaoDieteticaRepository>();
        _handler = new AssociateRestricaoDieteticaCommandHandler(_restricaoDieteticaRepositoryMock.Object);
    }

    [Fact]
    public async void Handle_ValidCommand_RestricaoDieteticaShouldAssociateAndReturnSuccess()
    {
        // Arrange
        var usuarioId = 1;
        var grupoAlimentar = 2;
        var command = new AssociateRestricaoDieteticaCommand(usuarioId, grupoAlimentar);

        _restricaoDieteticaRepositoryMock.Setup(repo => repo.AssociarRestricaoDieteticaAsync(It.IsAny<RestricaoDietetica>())).ReturnsAsync(true);

        // Act
        var result = await _handler.Handle(command, new CancellationToken());

        // Assert
        Assert.True(result.Success);
        Assert.Equal("Sucesso ao associar uma restrição a uma dieta!", result.Message);

    }
}
