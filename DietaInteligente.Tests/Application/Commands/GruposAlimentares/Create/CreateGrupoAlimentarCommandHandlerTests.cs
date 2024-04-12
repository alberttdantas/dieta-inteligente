
using AutoMapper;
using DietaInteligente.Application.Commands.GruposAlimentares.Create;
using DietaInteligente.Application.InputModels;
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Repositories;
using Moq;

namespace DietaInteligente.Tests.Application.Commands.GruposAlimentares.Create;

public class CreateGrupoAlimentarCommandHandlerTests
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IGrupoAlimentarRepository> _grupoAlimentarRepositoryMock;
    private readonly CreateGrupoAlimentarCommandHandler _handler;

    public CreateGrupoAlimentarCommandHandlerTests()
    {
        _mapperMock = new Mock<IMapper>();
        _grupoAlimentarRepositoryMock = new Mock<IGrupoAlimentarRepository>();
        _handler = new CreateGrupoAlimentarCommandHandler(_mapperMock.Object, _grupoAlimentarRepositoryMock.Object);
    }

    [Fact]
    public async void Handle_ValidInputModel_ShouldCreateGrupoAlimentarAndReturnSuccess()
    {
        // Arrange
        var grupoAlimentarInputModel = new GrupoAlimentarInputModel
        {
            Nome = "Nome"
        };

        var grupoAlimentar = new GrupoAlimentar("Nome");

        var command = new CreateGrupoAlimentarCommand(grupoAlimentarInputModel);
        _mapperMock.Setup(m => m.Map<GrupoAlimentar>(It.IsAny<GrupoAlimentarInputModel>())).Returns(grupoAlimentar);
        _grupoAlimentarRepositoryMock.Setup(repo => repo.CriarGrupoAlimentarAsync(It.IsAny<GrupoAlimentar>())).ReturnsAsync(true);

        // Act
        var result = await _handler.Handle(command, new CancellationToken());


        // Assert
        Assert.True(result.Success);
        Assert.Equal("Grupo alimentar criado com sucesso!", result.Message);
        _mapperMock.Verify(m => m.Map<GrupoAlimentar>(It.IsAny<GrupoAlimentarInputModel>()), Times.Once());
        _grupoAlimentarRepositoryMock.Verify(repo => repo.CriarGrupoAlimentarAsync(It.IsAny<GrupoAlimentar>()), Times.Once());
    }

    [Fact]
    public async void Handle_InvalidInputModel_ShouldReturnFailure()
    {
        // Arrange
        var grupoAlimentarInputModel = new GrupoAlimentarInputModel
        {
            Nome = "Nome"
        };

        var command = new CreateGrupoAlimentarCommand(grupoAlimentarInputModel);
        _mapperMock.Setup(m => m.Map<GrupoAlimentar>(It.IsAny<GrupoAlimentarInputModel>())).Returns((GrupoAlimentar)null);
        _grupoAlimentarRepositoryMock.Setup(repo => repo.CriarGrupoAlimentarAsync(null)).ReturnsAsync(false);

        // Act
        var result = await _handler.Handle(command, new CancellationToken());


        // Assert
        Assert.False(result.Success);
        Assert.NotEmpty(result.Errors);
        _mapperMock.Verify(m => m.Map<GrupoAlimentar>(It.IsAny<GrupoAlimentarInputModel>()), Times.Once);
        _grupoAlimentarRepositoryMock.Verify(repo => repo.CriarGrupoAlimentarAsync(null), Times.Once);

    }

}
