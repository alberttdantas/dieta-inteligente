
using AutoMapper;
using DietaInteligente.Application.Commands.Dietas.Create;
using DietaInteligente.Application.InputModels;
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Repositories;
using Moq;

namespace DietaInteligente.Tests.Application.Commands.Dietas.Create;

public class CreateDietaCommandHandlerTests
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IDietaRepository> _dietaRepositoryMock;
    private readonly CreateDietaCommandHandler _handler;

    public CreateDietaCommandHandlerTests()
    {
        _mapperMock = new Mock<IMapper>();
        _dietaRepositoryMock = new Mock<IDietaRepository>();
        _handler = new CreateDietaCommandHandler(_mapperMock.Object, _dietaRepositoryMock.Object);
    }

    [Fact]
    public async Task Handle_ValidInputModel_ShouldCreateDietaAndReturnSuccess()
    {
        // Arrange
        var dietaInputModel = new DietaInputModel
        {
            Data = new DateTime(2024, 4, 4),
            UsuarioId = 1
        };

        var dieta = new Dieta(1, new DateTime(2024, 4, 4));

        var command = new CreateDietaCommand(dietaInputModel);
        _mapperMock.Setup(m => m.Map<Dieta>(It.IsAny<DietaInputModel>())).Returns(dieta);
        _dietaRepositoryMock.Setup(repo => repo.CriarDietaAsync(It.IsAny<Dieta>())).ReturnsAsync(true);

        // Act
        var result = await _handler.Handle(command, new CancellationToken());


        // Assert
        Assert.True(result.Success);
        Assert.Equal("Dieta criada com sucesso!", result.Message);
        _mapperMock.Verify(m => m.Map<Dieta>(It.IsAny<DietaInputModel>()), Times.Once);
        _dietaRepositoryMock.Verify(repo => repo.CriarDietaAsync(It.IsAny<Dieta>()), Times.Once);
    }

    [Fact]
    public async Task Handle_InvalidInputModel_ShouldReturnFailure()
    {
        // Arrange
        var dietaInputModel = new DietaInputModel
        {
            Data = new DateTime(),
            UsuarioId = 1
        };

        var command = new CreateDietaCommand(dietaInputModel);
        _mapperMock.Setup(m => m.Map<Dieta>(It.IsAny<DietaInputModel>())).Returns((Dieta)null);
        _dietaRepositoryMock.Setup(repo => repo.CriarDietaAsync(null)).ReturnsAsync(false);

        // Act
        var result = await _handler.Handle(command, new CancellationToken());

        // Assert
        Assert.False(result.Success);
        Assert.NotEmpty(result.Errors);
        _mapperMock.Verify(m => m.Map<Dieta>(It.IsAny<DietaInputModel>()), Times.Once);
        _dietaRepositoryMock.Verify(repo => repo.CriarDietaAsync(null), Times.Once);
    }
}
