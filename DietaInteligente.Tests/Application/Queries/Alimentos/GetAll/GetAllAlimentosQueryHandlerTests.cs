
using AutoMapper;
using DietaInteligente.Application.Queries.Alimentos.GetAll;
using DietaInteligente.Application.ViewModels;
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Repositories;
using MediatR;
using Moq;

namespace DietaInteligente.Tests.Application.Queries.Alimentos.GetAll;

public class GetAllAlimentosQueryHandlerTests
{
    private readonly Mock<IAlimentoRepository> _alimentoRepositoryMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly IRequestHandler<GetAllAlimentosQuery, IEnumerable<AlimentoViewModel>> _handler;

    public GetAllAlimentosQueryHandlerTests()
    {
        _alimentoRepositoryMock = new Mock<IAlimentoRepository>();
        _mapperMock = new Mock<IMapper>();
        _handler = new GetAllAlimentosQueryHandler(_mapperMock.Object, _alimentoRepositoryMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldReturnAllAlimentos()
    {
        // Arrange
        var alimentos = new List<Alimento>
         {
            new Alimento ("Alimento 1", 1, 1),
            new Alimento ("Alimento 2", 2, 2)
         };

        var alimentosViewModel = new List<AlimentoViewModel>
        {
            new AlimentoViewModel { Id = 1, Nome = "Alimento 1", GrupoAlimentarId = 1 },
            new AlimentoViewModel { Id = 2, Nome = "Alimento 2", GrupoAlimentarId = 2 }
        };

        _alimentoRepositoryMock.Setup(repo => repo.BuscarAlimentosAsync()).ReturnsAsync(alimentos);
        _mapperMock.Setup(m => m.Map<IEnumerable<AlimentoViewModel>>(It.IsAny<IEnumerable<Alimento>>())).Returns(alimentosViewModel);

        var query = new GetAllAlimentosQuery();

        // Act
        var result = await _handler.Handle(query, new CancellationToken());


        // Assert
        Assert.NotNull(result);
        Assert.Equal(alimentosViewModel.Count, result.Count());

    }
}
