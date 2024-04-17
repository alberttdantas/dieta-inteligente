
using AutoMapper;
using DietaInteligente.Application.Queries.Alimentos.GetById;
using DietaInteligente.Application.ViewModels;
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Repositories;
using MediatR;
using Moq;

namespace DietaInteligente.Tests.Application.Queries.Alimentos.GetById;

public class GetAlimentoByIdQueryHandlerTests
{
    private readonly Mock<IAlimentoRepository> _alimentoRepositoryMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly IRequestHandler<GetAlimentoByIdQuery, AlimentoViewModel> _handler;

    public GetAlimentoByIdQueryHandlerTests()
    {
        _alimentoRepositoryMock = new Mock<IAlimentoRepository>();
        _mapperMock = new Mock<IMapper>();
        _handler = new GetAlimentoByQueryHandler(_mapperMock.Object, _alimentoRepositoryMock.Object);
    }

    [Fact]
    public async Task Handle_ValidId_ShouldReturnAlimentoViewModel()
    {
        // Arrange
        var alimentoId = 1;
        var alimento = new Alimento("Arroz", 1, 1) {  Id = alimentoId };
        var alimentoViewModel = new AlimentoViewModel { Id = alimentoId, Nome = "Arroz", GrupoAlimentarId = 1 };

        _alimentoRepositoryMock.Setup(repo => repo.BuscarAlimentoAsync(alimentoId)).ReturnsAsync(alimento);
        _mapperMock.Setup(m => m.Map<AlimentoViewModel>(It.IsAny<Alimento>())).Returns(alimentoViewModel);

        var query = new GetAlimentoByIdQuery(alimentoId);

        // Act
        var result = await _handler.Handle(query, new CancellationToken());

        // Assert
        Assert.NotNull(result);
        Assert.Equal(alimentoId, result.Id);
        Assert.Equal("Arroz", result.Nome);
        Assert.Equal(1, result.GrupoAlimentarId);
    }

    [Fact]
    public async Task Handle_InvalidId_ShouldReturnNull()
    {
        // Arrange
        var alimentoId = 99;

        _alimentoRepositoryMock.Setup(repo => repo.BuscarAlimentoAsync(alimentoId)).ReturnsAsync((Alimento)null);

        var query = new GetAlimentoByIdQuery(alimentoId);


        // Act
        var result = await _handler.Handle(query, new CancellationToken());

        // Assert
        Assert.Null(result);


    }
}
