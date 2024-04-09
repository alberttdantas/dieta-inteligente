
using AutoMapper;
using DietaInteligente.Application.Commands.Dietas.Update;
using DietaInteligente.Application.InputModels;
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Repositories;
using Moq;

namespace DietaInteligente.Tests.Application.Commands.Dietas.Update;

public class UpdateDietaCommandHandlerTests
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IDietaRepository> _dietaRepositoryMock;
    private readonly UpdateDietaCommandHandler _handler;

    public UpdateDietaCommandHandlerTests()
    {
        _mapperMock = new Mock<IMapper>();
        _dietaRepositoryMock = new Mock<IDietaRepository>();
        _handler = new UpdateDietaCommandHandler(_mapperMock.Object, _dietaRepositoryMock.Object);
    }

    [Fact]
    public async Task Handle_ValidDieta_ShouldUpdateDietaAndReturnSuccess()
    {
        // Arrange
        var dietaInputModel = new DietaInputModel
        {
            Data = new DateTime(2024, 4, 8),
            UsuarioId = 1
        };

        var dieta = new Dieta(dietaInputModel.UsuarioId, dietaInputModel.Data)
        {
            Id = 10,
        };
        var command = new UpdateDietaCommand(dietaInputModel);
        _mapperMock.Setup(mapper => mapper.Map<Dieta>(dietaInputModel)).Returns(dieta);
        _dietaRepositoryMock.Setup(repo => repo.AtualizarDietaAsync(dieta)).ReturnsAsync(true);

        // Act
        var result = await _handler.Handle(command, new CancellationToken());

        // Assert
        Assert.True(result.Success);
        Assert.Equal("Sucesso ao atualizar dieta!", result.Message);
        _mapperMock.Verify(mapper => mapper.Map<Dieta>(dietaInputModel), Times.Once);
        _dietaRepositoryMock.Verify(repo => repo.AtualizarDietaAsync(dieta), Times.Once);
    }

    [Fact]
    public async Task Handle_InvalidDieta_ShouldNotUpdateDietaAndReturnFailure()
    {
        // Arrange
        var dietaInputModel = new DietaInputModel
        {
            Data = new DateTime(2024, 4, 8),
            UsuarioId = 1
        };
        var command = new UpdateDietaCommand(dietaInputModel);
        _mapperMock.Setup(mapper => mapper.Map<Dieta>(dietaInputModel)).Returns((Dieta)null);

        // Act
        var result = await _handler.Handle(command, new CancellationToken());

        // Assert
        Assert.False(result.Success);
        Assert.Contains("Dieta não encontrada!", result.Errors);
        _mapperMock.Verify(mapper => mapper.Map<Dieta>(dietaInputModel), Times.Once);
        _dietaRepositoryMock.Verify(repo => repo.AtualizarDietaAsync(It.IsAny<Dieta>()), Times.Never);
    }

}
