
using DietaInteligente.Application.Commands.DietasAlimentos.Disassociate;
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Repositories;
using Moq;

namespace DietaInteligente.Tests.Application.Commands.DietasAlimentos.Disassociate;

public class DisassociateDietaAlimentoCommandHandlerTests
{
    private readonly Mock<IDietaAlimentoRepository> _dietaAlimentoRepositoryMock;
    private readonly DisassociateDietaAlimentoCommandHandler _handler;

    public DisassociateDietaAlimentoCommandHandlerTests()
    {
        _dietaAlimentoRepositoryMock = new Mock<IDietaAlimentoRepository>();
        _handler = new DisassociateDietaAlimentoCommandHandler(_dietaAlimentoRepositoryMock.Object);
    }


    [Fact]
    public async Task Handle_ValidCommand_ShouldDisassociateAndReturnSuccess()
    {
        // Arrange
        var dietaId = 1;
        var alimentoId = 2;
        var command = new DisassociateDietaAlimentoCommand(dietaId, alimentoId);
        _dietaAlimentoRepositoryMock.Setup(repo => repo.DesassociarDietaAlimentoAsync(It.IsAny<DietaAlimento>())).ReturnsAsync(true);

        // Act
        var result = await _handler.Handle(command, new CancellationToken());

        // Assert
        Assert.True(result.Success);
        Assert.Equal("Sucesso ao desassociar dieta de alimento", result.Message);
    }


    [Fact]
    public async Task Handle_InvalidCommand_ShouldNotDisassociateAndReturnFailure()
    {
        // Arrange
        var dietaId = 0;
        var alimentoId = 0;
        var command = new DisassociateDietaAlimentoCommand(dietaId, alimentoId);
        _dietaAlimentoRepositoryMock.Setup(repo => repo.DesassociarDietaAlimentoAsync(It.IsAny<DietaAlimento>())).ReturnsAsync(false);

        // Act
        var result = await _handler.Handle(command, new CancellationToken());

        // Assert
        Assert.False(result.Success);
        Assert.Contains("Falha ao desassociar dieta de alimento", result.Errors);
    }


}
