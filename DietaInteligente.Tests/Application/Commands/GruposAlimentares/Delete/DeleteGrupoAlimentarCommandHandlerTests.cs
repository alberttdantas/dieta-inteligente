
using AutoMapper;
using DietaInteligente.Application.Commands.GruposAlimentares.Delete;
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Repositories;
using Moq;

namespace DietaInteligente.Tests.Application.Commands.GruposAlimentares.Delete;

public class DeleteGrupoAlimentarCommandHandlerTests
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IGrupoAlimentarRepository> _grupoAlimentarRepositoryMock;
    private readonly DeleteGrupoAlimentarCommandHandler _handler;

    public DeleteGrupoAlimentarCommandHandlerTests()
    {
        _mapperMock = new Mock<IMapper>();
        _grupoAlimentarRepositoryMock = new Mock<IGrupoAlimentarRepository>();
        _handler = new DeleteGrupoAlimentarCommandHandler(_mapperMock.Object, _grupoAlimentarRepositoryMock.Object);
    }

    [Fact]
    public async void Handle_GrupoAlimentarExists_ShouldDeleteGrupoAlimentarAndReturnSuccess()
    {
        // Arrange
        var grupoAlimentarId = 1;
        var grupoAlimentar = new GrupoAlimentar("Nome");
        _grupoAlimentarRepositoryMock.Setup(repo => repo.BuscarGrupoAlimentarAsync(grupoAlimentarId)).ReturnsAsync(grupoAlimentar);
        _grupoAlimentarRepositoryMock.Setup(repo => repo.DeletarGrupoAlimentarAsync(grupoAlimentar)).ReturnsAsync(true);
        var command = new DeleteGrupoAlimentarCommand(grupoAlimentarId);

        // Act
        var result = await _handler.Handle(command, new CancellationToken());


        // Assert
        Assert.True(result.Success);
        _grupoAlimentarRepositoryMock.Verify(repo => repo.DeletarGrupoAlimentarAsync(grupoAlimentar), Times.Once());

    }

    [Fact]
    public async void Handle_DietaDoesNotExist_ShouldReturnFailure()
    {
        // Arrange
        var grupoAlimentarId = 1;
        var command = new DeleteGrupoAlimentarCommand(grupoAlimentarId);
        _grupoAlimentarRepositoryMock.Setup(repo => repo.BuscarGrupoAlimentarAsync(grupoAlimentarId)).ReturnsAsync((GrupoAlimentar)null);

        // Act
        var result = await _handler.Handle(command, new CancellationToken());

        // Assert
        Assert.False(result.Success);
        Assert.Contains("Grupo alimentar não encontrado!", result.Errors);
        _grupoAlimentarRepositoryMock.Verify(repo => repo.BuscarGrupoAlimentarAsync(grupoAlimentarId), Times.Once());
        _grupoAlimentarRepositoryMock.Verify(repo => repo.DeletarGrupoAlimentarAsync(It.IsAny<GrupoAlimentar>()), Times.Never());

    }
}
