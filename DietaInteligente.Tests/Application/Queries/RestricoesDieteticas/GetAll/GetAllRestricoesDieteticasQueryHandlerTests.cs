
using AutoMapper;
using DietaInteligente.Application.Queries.InformacoesNutricionais.GetAll;
using DietaInteligente.Application.Queries.RestricoesDieteticas.GetAll;
using DietaInteligente.Application.ViewModels;
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Repositories;
using MediatR;
using Moq;

namespace DietaInteligente.Tests.Application.Queries.RestricoesDieteticas.GetAll;

public class GetAllRestricoesDieteticasQueryHandlerTests
{
    private readonly Mock<IRestricaoDieteticaRepository> _restricaoDieteticaRepositoryMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly IRequestHandler<GetAllRestricoesDieteticasQuery, IEnumerable<RestricaoDieteticaViewModel>> _handler;

    public GetAllRestricoesDieteticasQueryHandlerTests()
    {
        _restricaoDieteticaRepositoryMock = new Mock<IRestricaoDieteticaRepository>();
        _mapperMock = new Mock<IMapper>();
        _handler = new GetAllRestricoesDieteticasQueryHandler(_mapperMock.Object, _restricaoDieteticaRepositoryMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldReturnAllRestricoesDieteticas()
    {
        // Arrange
        var restricoesDieteticas = new List<RestricaoDietetica>
        {
            new RestricaoDietetica (1, 1),
            new RestricaoDietetica (1, 2)
        };

        var grupoAlimentarNomes = new Dictionary<int, string>
        {
            { 1, "Cereais" },
            { 2, "Carnes" }
        };

        var restricoesDieteticasViewModel = restricoesDieteticas.GroupBy(rd => rd.UsuarioId).Select(group => new RestricaoDieteticaViewModel
        {
            UsuarioId = group.Key,
            GruposAlimentares = group.Select(rd => new GrupoAlimentarViewModel { Nome = grupoAlimentarNomes[rd.GrupoAlimentarId], Id = rd.GrupoAlimentarId })
        }).ToList();

        _restricaoDieteticaRepositoryMock.Setup(repo => repo.BuscarRestricoesDieteticasAsync()).ReturnsAsync(restricoesDieteticas);
        _mapperMock.Setup(m => m.Map<IEnumerable<RestricaoDieteticaViewModel>>(It.IsAny<IEnumerable<RestricaoDietetica>>())).Returns(restricoesDieteticasViewModel);

        var query = new GetAllRestricoesDieteticasQuery();

        // Act
        var result = await _handler.Handle(query, new CancellationToken());


        // Assert
        Assert.NotNull(result);
        Assert.Equal(restricoesDieteticasViewModel.Count, result.Count());
        Assert.All(result, item => Assert.Equal(item.GruposAlimentares.Count(), restricoesDieteticas.Where(rd => rd.UsuarioId == item.UsuarioId).Count()));

    }
}
