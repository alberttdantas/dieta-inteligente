using DietaInteligente.Application.Commands.Alimentos.Delete;
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Repositories;
using MediatR;
using Moq;

namespace DietaInteligente.Tests.Application.Commands.Alimentos.Delete;

public class DeleteAlimentoCommandHandlerTests
{
    private readonly Mock<IAlimentoRepository> _alimentoRepositoryMock;
    private readonly IRequestHandler<DeleteAlimentoCommand, CommandResult> _handler;

    public DeleteAlimentoCommandHandlerTests()
    {
        _alimentoRepositoryMock = new Mock<IAlimentoRepository>();
        _handler = new DeleteAlimentoCommandHandler(_alimentoRepositoryMock.Object);
    }

    [Fact]
    public async Task Handle_GivenValidId_ShouldDeleteAlimento()
    {
        // Arrange
        var alimentoId = 1;
        var alimento = new Alimento("Maçã", 1, 1);
        _alimentoRepositoryMock.Setup(repo => repo.BuscarAlimentoAsync(alimentoId)).ReturnsAsync(alimento);
        _alimentoRepositoryMock.Setup(repo => repo.DeletarAlimentoAsync(alimento)).ReturnsAsync(true);
        var command = new DeleteAlimentoCommand(alimentoId);


        // Act
        var result = await _handler.Handle(command, new CancellationToken());


        // Assert
        Assert.True(result.Success);
        _alimentoRepositoryMock.Verify(repo => repo.DeletarAlimentoAsync(alimento), Times.Once);
    }
}
