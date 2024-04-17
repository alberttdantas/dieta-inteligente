
using AutoMapper;
using DietaInteligente.Application.Queries.RestricoesDieteticas.GetAll;
using DietaInteligente.Application.Queries.RestricoesDieteticas.GetById;
using DietaInteligente.Application.ViewModels;
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Repositories;
using MediatR;
using Moq;

namespace DietaInteligente.Tests.Application.Queries.RestricoesDieteticas.GetById;

public class GetRestricaoDieteticaByIdQueryHandlerTests
{
    private readonly Mock<IRestricaoDieteticaRepository> _restricaoDieteticaRepositoryMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly IRequestHandler<GetRestricoesDieteticasByIdQuery, RestricaoDieteticaViewModel> _handler;

    public GetRestricaoDieteticaByIdQueryHandlerTests()
    {
        _restricaoDieteticaRepositoryMock = new Mock<IRestricaoDieteticaRepository>();
        _mapperMock = new Mock<IMapper>();
        _handler = new GetRestricoesDieteticasByIdQueryHandler(_mapperMock.Object, _restricaoDieteticaRepositoryMock.Object);
    }

    [Fact]
    public async Task GetRestricoesDieteticasByIdQueryHandlerTests()
    {
        // Arrange
        int usuarioId = 1;
        var restricoesDieteticas = new List<RestricaoDietetica>
        {
            new RestricaoDietetica(usuarioId, 1),
            new RestricaoDietetica(usuarioId, 2),
            new RestricaoDietetica(usuarioId, 3)
        };

        var restricoesDieteticasViewModel = new RestricaoDieteticaViewModel
        {
            UsuarioId = usuarioId,
            GruposAlimentares = new List<GrupoAlimentarViewModel>
            {
                new GrupoAlimentarViewModel { Id = 1, Nome = "Cereais" },
                new GrupoAlimentarViewModel { Id = 2, Nome = "Legumes" },
                new GrupoAlimentarViewModel { Id = 3, Nome = "Frutas" }
            }
        };

        _restricaoDieteticaRepositoryMock.Setup(repo => repo.BuscarRestricaoDieteticaAsync(usuarioId)).ReturnsAsync(restricoesDieteticas);
        _mapperMock.Setup(m => m.Map<RestricaoDieteticaViewModel>(It.IsAny<IEnumerable<RestricaoDietetica>>())).Returns(restricoesDieteticasViewModel);

        var query = new GetRestricoesDieteticasByIdQuery(usuarioId);

        // Act
        var result = await _handler.Handle(query, new CancellationToken());


        // Assert
        Assert.NotNull(result);
        Assert.Equal(usuarioId, result.UsuarioId);
        Assert.Equal(3, result.GruposAlimentares.Count());

    }
}
