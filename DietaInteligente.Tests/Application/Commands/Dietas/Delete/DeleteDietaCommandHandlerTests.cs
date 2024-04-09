
using AutoMapper;
using DietaInteligente.Application.Commands.Dietas.Delete;
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Repositories;
using Moq;

namespace DietaInteligente.Tests.Application.Commands.Dietas.Delete;

public class DeleteDietaCommandHandlerTests
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IDietaRepository> _dietaRepositoryMock;
    private readonly DeleteDietaCommandHandler _handler;

    public DeleteDietaCommandHandlerTests()
    {
        _mapperMock = new Mock<IMapper>();
        _dietaRepositoryMock = new Mock<IDietaRepository>();
        _handler = new DeleteDietaCommandHandler(_mapperMock.Object, _dietaRepositoryMock.Object);
    }

    [Fact]
    public async Task Handle_DietaExists_ShouldDeleteDietaAndReturnSuccess()
    {
        // Arrange
        var dietaId = 1;
        var dieta = new Dieta(dietaId);
        var command = new DeleteDietaCommand(dietaId);
        _dietaRepositoryMock.Setup(repo => repo.BuscarDietaAsync(dietaId)).ReturnsAsync(dieta);
        _dietaRepositoryMock.Setup(repo => repo.DeletarDietaAsync(dieta)).ReturnsAsync(true);

        // Act
        var result = await _handler.Handle(command, new CancellationToken());

        // Assert
        Assert.True(result.Success);
        Assert.Equal("Dieta deletada com sucesso!", result.Message);
        _dietaRepositoryMock.Verify(repo => repo.BuscarDietaAsync(dietaId), Times.Once);
        _dietaRepositoryMock.Verify(repo => repo.DeletarDietaAsync(dieta), Times.Once);
    }

    [Fact]
    public async Task Handle_DietaDoesNotExist_ShouldReturnFailure()
    {
        // Arrange
        var dietaId = 1;
        var command = new DeleteDietaCommand(dietaId);
        _dietaRepositoryMock.Setup(repo => repo.BuscarDietaAsync(dietaId)).ReturnsAsync((Dieta)null);

        // Act
        var result = await _handler.Handle(command, new CancellationToken());

        // Assert
        Assert.False(result.Success);
        Assert.Contains("Dieta não encontrada!", result.Errors);
        _dietaRepositoryMock.Verify(repo => repo.BuscarDietaAsync(dietaId), Times.Once);
        _dietaRepositoryMock.Verify(repo => repo.DeletarDietaAsync(It.IsAny<Dieta>()), Times.Never);
    }
}
