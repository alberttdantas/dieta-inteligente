
using AutoMapper;
using DietaInteligente.Application.Queries.GruposAlimentares.GetAll;
using DietaInteligente.Application.ViewModels;
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Repositories;
using MediatR;
using Moq;

namespace DietaInteligente.Tests.Application.Queries.GruposAlimentares.GetAll;

public class GetAllGruposAlimentaresQueryHandlerTests
{
    private readonly Mock<IGrupoAlimentarRepository> _grupoAlimentarRepositoryMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly IRequestHandler<GetAllGruposAlimentaresQuery, IEnumerable<GrupoAlimentarViewModel>> _handler;

    public GetAllGruposAlimentaresQueryHandlerTests()
    {
        _grupoAlimentarRepositoryMock = new Mock<IGrupoAlimentarRepository>();
        _mapperMock = new Mock<IMapper>();
        _handler = new GetAllGruposAlimentaresQueryHandler(_mapperMock.Object, _grupoAlimentarRepositoryMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldReturnAllGruposAlimentares()
    {
        // Arrange
        var gruposAlimentares = new List<GrupoAlimentar>
        {
            new GrupoAlimentar ("Cereais"),
            new GrupoAlimentar ("Carnes")
        };

        var grupoAlimetarViewModel = new List<GrupoAlimentarViewModel>
        {
            new GrupoAlimentarViewModel { Nome = "Cereais" },
            new GrupoAlimentarViewModel { Nome = "Carnes" }
        };

        _grupoAlimentarRepositoryMock.Setup(repo => repo.BuscarGruposAlimentarAsync()).ReturnsAsync(gruposAlimentares);
        _mapperMock.Setup(m => m.Map<IEnumerable<GrupoAlimentarViewModel>>(It.IsAny<IEnumerable<GrupoAlimentar>>())).Returns(grupoAlimetarViewModel);

        var query = new GetAllGruposAlimentaresQuery();

        // Act
        var result = await _handler.Handle(query, new CancellationToken());


        // Assert
        Assert.NotNull(result);
        Assert.Equal(grupoAlimetarViewModel.Count, result.Count());


    }
}
