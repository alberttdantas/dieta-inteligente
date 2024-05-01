
using AutoMapper;
using DietaInteligente.Application.Queries.InformacoesNutricionais.GetById;
using DietaInteligente.Application.ViewModels;
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Repositories;
using MediatR;
using Moq;

namespace DietaInteligente.Tests.Application.Queries.InformacoesNutricionais.GetById;

public class GetInformacaoNutricionalByIdQueryHandlerTests
{
    private readonly Mock<IInformacaoNutricionalRepository> _informacaoNutricionalRepositoryMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly IRequestHandler<GetInformacaoNutricionalByIdQuery, InformacaoNutricionalViewModel> _handler;

    public GetInformacaoNutricionalByIdQueryHandlerTests()
    {
        _informacaoNutricionalRepositoryMock = new Mock<IInformacaoNutricionalRepository>();
        _mapperMock = new Mock<IMapper>();
        _handler = new GetInformacaoNutricionalByIdQueryHandler(_mapperMock.Object, _informacaoNutricionalRepositoryMock.Object);
    }

    [Fact]
    public async Task Handle_ValidId_ShouldReturnInformacaoNutricionalViewModel()
    {
        // Arrange
        var alimentoId = 1;
        var informacaoNutricional = new InformacaoNutricional(alimentoId, 100, 100, 100, 100, 100);
        var informacaoNutricionalViewModel = new InformacaoNutricionalViewModel { AlimentoId = alimentoId, Calorias = 100, Carboidratos = 100, Fibras = 100, Gorduras = 100, Proteinas = 100 };

        _informacaoNutricionalRepositoryMock.Setup(repo => repo.BuscarInformacaoNutricionalAsync(alimentoId)).ReturnsAsync(informacaoNutricional);
        _mapperMock.Setup(m => m.Map<InformacaoNutricionalViewModel>(It.IsAny<InformacaoNutricional>())).Returns(informacaoNutricionalViewModel);

        var query = new GetInformacaoNutricionalByIdQuery(alimentoId);

        // Act
        var result = await _handler.Handle(query, new CancellationToken());


        // Assert
        Assert.NotNull(result);
        Assert.Equal(alimentoId, result.AlimentoId);
        Assert.Equal(100, result.Carboidratos);
        Assert.Equal(100, result.Gorduras);
        Assert.Equal(100, result.Calorias);
        Assert.Equal(100, result.Carboidratos);
        Assert.Equal(100, result.Proteinas);

    }

    [Fact]
    public async Task Handle_InvalidId_ShouldReturnNull()
    {
        // Arrange
        var alimentoId = 99;

        _informacaoNutricionalRepositoryMock.Setup(repo => repo.BuscarInformacaoNutricionalAsync(alimentoId)).ReturnsAsync((InformacaoNutricional)null);

        var query = new GetInformacaoNutricionalByIdQuery(alimentoId);


        // Act
        var result = await _handler.Handle(query, new CancellationToken());


        // Assert
        Assert.Null(result);

    }
}
