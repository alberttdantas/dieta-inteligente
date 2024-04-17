
using AutoMapper;
using DietaInteligente.Application.Queries.GruposAlimentares.GetById;
using DietaInteligente.Application.ViewModels;
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Repositories;
using MediatR;
using Moq;

namespace DietaInteligente.Tests.Application.Queries.GruposAlimentares.GetById;

public class GetGruposAlimentaresByIdQueryHandlerTests
{
    private readonly Mock<IGrupoAlimentarRepository> _grupoAlimentarRepositoryMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly IRequestHandler<GetGrupoAlimentarByIdQuery, GrupoAlimentarViewModel> _handler;

    public GetGruposAlimentaresByIdQueryHandlerTests()
    {
        _grupoAlimentarRepositoryMock = new Mock<IGrupoAlimentarRepository>();
        _mapperMock = new Mock<IMapper>();
        _handler = new GetGrupoAlimentarByIdQueryHandler(_mapperMock.Object, _grupoAlimentarRepositoryMock.Object);
    }

    [Fact]
    public async Task Handle_ValidId_ShouldReturnGrupoAlimentarViewModel()
    {
        // Arrange
        var grupoAlimentarId = 1;
        var grupoAlimentar = new GrupoAlimentar("Cereais") { Id =  grupoAlimentarId };
        var grupoAlimentarViewModel = new GrupoAlimentarViewModel { Id = grupoAlimentarId, Nome = "Cereais", Alimentos = new List<AlimentoViewModel>() };

        _grupoAlimentarRepositoryMock.Setup(repo => repo.BuscarGrupoAlimentarAsync(grupoAlimentarId)).ReturnsAsync(grupoAlimentar);
        _mapperMock.Setup(m => m.Map<GrupoAlimentarViewModel>(It.IsAny<GrupoAlimentar>())).Returns(grupoAlimentarViewModel);

        var query = new GetGrupoAlimentarByIdQuery(grupoAlimentarId);

        // Act
        var result = await _handler.Handle(query, new CancellationToken());

        // Assert
        Assert.NotNull(result);
        Assert.Equal(grupoAlimentarId, result.Id);
        Assert.Equal("Cereais", result.Nome);
        Assert.Equal(1, grupoAlimentarId);

    }

    [Fact]
    public async Task Handle_InvalidId_ShouldReturnNull()
    {
        // Arrange
        var grupoAlimentarId = 99;

        _grupoAlimentarRepositoryMock.Setup(repo => repo.BuscarGrupoAlimentarAsync(grupoAlimentarId)).ReturnsAsync((GrupoAlimentar)null);

        var query = new GetGrupoAlimentarByIdQuery(grupoAlimentarId);

        // Act
        var result = await _handler.Handle(query, new CancellationToken());


        // Assert
        Assert.Null(result);


    }
}
