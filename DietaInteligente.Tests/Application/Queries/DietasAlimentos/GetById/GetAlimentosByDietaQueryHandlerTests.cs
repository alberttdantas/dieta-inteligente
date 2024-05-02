
using AutoMapper;
using DietaInteligente.Application.Queries.DietasAlimentos.GetById;
using DietaInteligente.Application.ViewModels;
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Repositories;
using MediatR;
using Moq;

namespace DietaInteligente.Tests.Application.Queries.DietasAlimentos.GetById;

public class GetAlimentosByDietaQueryHandlerTests
{
    Mock<IDietaAlimentoRepository> _dietaAlimentoRepositoMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly IRequestHandler<GetDietaAlimentoByIdQuery, IEnumerable<DietaAlimentoViewModel>> _handler;

    public GetAlimentosByDietaQueryHandlerTests()
    {
        _dietaAlimentoRepositoMock = new Mock<IDietaAlimentoRepository>();
        _mapperMock = new Mock<IMapper>();
        _handler = new GetAlimentosByDietaQueryHandler(_mapperMock.Object, _dietaAlimentoRepositoMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldReturnAlimentosByDieta()
    {
        // Arrange
        int dietaId = 1;
        var dietaAlimentos = new List<DietaAlimento>
        {
            new DietaAlimento(dietaId, 1, 100),
            new DietaAlimento(dietaId, 2, 150)
        };

        var dietaAlimentosViewModel = new List<DietaAlimentoViewModel>
        {
            new DietaAlimentoViewModel { DietaId = dietaId, Alimento = new AlimentoViewModel(), QuantidadeGramas = 100m },
            new DietaAlimentoViewModel { DietaId = dietaId, Alimento = new AlimentoViewModel(), QuantidadeGramas = 150m }

        };

        _dietaAlimentoRepositoMock.Setup(repo => repo.BuscarAlimentosPorDietaAsync(dietaId)).ReturnsAsync(dietaAlimentos);
        _mapperMock.Setup(m => m.Map<IEnumerable<DietaAlimentoViewModel>>(It.IsAny<IEnumerable<DietaAlimento>>())).Returns(dietaAlimentosViewModel);

        var query = new GetDietaAlimentoByIdQuery(dietaId);

        // Act
        var result = await _handler.Handle(query, new CancellationToken());

        // Assert
        Assert.NotNull(result);
        Assert.Equal(dietaAlimentosViewModel.Count(), result.Count());
        Assert.All(result, item => Assert.Equal(dietaId, item.DietaId));
        Assert.All(result, item => Assert.True(item.QuantidadeGramas.HasValue));
    }
}
