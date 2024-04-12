
using AutoMapper;
using DietaInteligente.Application.Commands.GruposAlimentares.Update;
using DietaInteligente.Application.InputModels;
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Repositories;
using Moq;

namespace DietaInteligente.Tests.Application.Commands.GruposAlimentares.Update;

public class UpdateGrupoAlimentarCommandHandlerTests
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IGrupoAlimentarRepository> _grupoAlimentarRepositoryMock;
    private readonly UpdateGrupoAlimentarCommandHandler _handler;

    public UpdateGrupoAlimentarCommandHandlerTests()
    {
        _mapperMock = new Mock<IMapper>();
        _grupoAlimentarRepositoryMock = new Mock<IGrupoAlimentarRepository>();
        _handler = new UpdateGrupoAlimentarCommandHandler(_mapperMock.Object, _grupoAlimentarRepositoryMock.Object);
    }

    [Fact]
    public async void Handle_ValidGrupoAlimentar_ShouldUpdateGrupoAlimentarAndReturnSuccess()
    {
        // Arrange
        var grupoAlimentarIputModel = new GrupoAlimentarInputModel
        {
            Nome = "Nome"
        };

        var grupoAlimentar = new GrupoAlimentar(grupoAlimentarIputModel.Nome) { Nome = "Nome teste" };
        var command = new UpdateGrupoAlimentarCommand(grupoAlimentarIputModel);
        _mapperMock.Setup(m => m.Map<GrupoAlimentar>(grupoAlimentarIputModel)).Returns(grupoAlimentar);
        _grupoAlimentarRepositoryMock.Setup(repo => repo.AtualizarGrupoAlimentarAsync(grupoAlimentar)).ReturnsAsync(true);

        // Act
        var result = await _handler.Handle(command, new CancellationToken());


        // Assert
        Assert.True(result.Success);
        Assert.Equal("Sucesso ao atualizar grupo alimentar!", result.Message);
        _mapperMock.Verify(m => m.Map<GrupoAlimentar>(grupoAlimentarIputModel), Times.Once());
        _grupoAlimentarRepositoryMock.Verify(repo => repo.AtualizarGrupoAlimentarAsync(grupoAlimentar), Times.Once());
    }

    [Fact]
    public async void Handle_InvalidGrupoAlimentar_ShouldNotUpdateGrupoAlimentarAndReturnFailure()
    {
        // Arrange
        var grupoAlimentarInputModel = new GrupoAlimentarInputModel
        {
            Nome = "Nome"
        };
        var command = new UpdateGrupoAlimentarCommand(grupoAlimentarInputModel);
        _mapperMock.Setup(m => m.Map<GrupoAlimentar>(grupoAlimentarInputModel)).Returns((GrupoAlimentar)null);

        // Act
        var result = await _handler.Handle(command, new CancellationToken());

        // Assert
        Assert.False(result.Success);
        Assert.Contains("Grupo alimetar não encontrado!", result.Errors);
        _mapperMock.Verify(m => m.Map<GrupoAlimentar>(grupoAlimentarInputModel), Times.Once());
        _grupoAlimentarRepositoryMock.Verify(repo => repo.AtualizarGrupoAlimentarAsync(It.IsAny<GrupoAlimentar>()), Times.Never());
    }

}
