
using AutoMapper;
using DietaInteligente.Application.Queries.DietasAlimentos.GetAll;
using DietaInteligente.Application.ViewModels;
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Repositories;
using MediatR;
using Moq;

namespace DietaInteligente.Tests.Application.Queries.DietasAlimentos.GetAll;

public class GetAllDietasAlimentosQueryHandlerTests
{
    private readonly Mock<IDietaAlimentoRepository> _dietaAlimentoRepositoMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly IRequestHandler<GetAllDietasAlimentosQuery, IEnumerable<DietaAlimentoViewModel>> _handler;

    public GetAllDietasAlimentosQueryHandlerTests()
    {
        _dietaAlimentoRepositoMock = new Mock<IDietaAlimentoRepository>();
        _mapperMock = new Mock<IMapper>();
        _handler = new GetAllDietasAlimentosQueryHandler(_mapperMock.Object, _dietaAlimentoRepositoMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldReturnAllAlimentos()
    {
        // Arrange
        var dietasAlimentos = new List<DietaAlimento>
        {
            new DietaAlimento (1, 200),
            new DietaAlimento (2, 200)
        };

        var dietasAlimentosViewModel = new List<DietaAlimentoViewModel>
        {
            new DietaAlimentoViewModel { DietaId = 1, QuantidadeGramas = 200, Alimento = new AlimentoViewModel() },
            new DietaAlimentoViewModel { DietaId = 2, QuantidadeGramas = 200, Alimento = new AlimentoViewModel() }
        };

        _dietaAlimentoRepositoMock.Setup(repo => repo.BuscarDietasAlimentosAsync()).ReturnsAsync(dietasAlimentos);
        _mapperMock.Setup(m => m.Map<IEnumerable<DietaAlimentoViewModel>>(It.IsAny<IEnumerable<DietaAlimento>>())).Returns(dietasAlimentosViewModel);

        var query = new GetAllDietasAlimentosQuery();

        // Act
        var result = await _handler.Handle(query, new CancellationToken());

        // Assert
        Assert.NotNull(result);
        Assert.Equal(dietasAlimentosViewModel.Count, result.Count());

    }
}
