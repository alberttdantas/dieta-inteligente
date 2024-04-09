
using DietaInteligente.Application.Commands.DietasAlimentos.Associate;
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Repositories;
using Moq;

namespace DietaInteligente.Tests.Application.Commands.DietasAlimentos.Associate;

public class AssociateDietaAlimentoCommandHandlerTests
{
    private readonly Mock<IDietaAlimentoRepository> _dietaAlimentoRepositoryMock;
    private readonly AssociateDietaAlimentoCommandHandler _handler;

    public AssociateDietaAlimentoCommandHandlerTests()
    {
        _dietaAlimentoRepositoryMock = new Mock<IDietaAlimentoRepository>();
        _handler = new AssociateDietaAlimentoCommandHandler(_dietaAlimentoRepositoryMock.Object);
    }

    [Fact]
    public async Task Handle_ValidCommand_ShouldAssociateAndReturnSuccess()
    {
        // Arrange
        var dietaId = 1;
        var alimentoId = 2;
        var quantidadeGramas = 100m;
        var command = new AssociateDietaAlimentoCommand(dietaId, alimentoId, quantidadeGramas);

        _dietaAlimentoRepositoryMock.Setup(repo => repo.AssociarDietaAlimentoAsync(It.IsAny<DietaAlimento>())).ReturnsAsync(true);

        // Act
        var result = await _handler.Handle(command, new CancellationToken());

        // Assert
        Assert.True(result.Success);
        Assert.Equal("Sucesso ao associar dieta e alimento", result.Message);
    }
}
