
using AutoMapper;
using DietaInteligente.Application.Queries.InformacoesNutricionais.GetAll;
using DietaInteligente.Application.Queries.InformacoesNutricionais.GetById;
using DietaInteligente.Application.ViewModels;
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Repositories;
using MediatR;
using Moq;

namespace DietaInteligente.Tests.Application.Queries.InformacoesNutricionais.GetAll;

public class GetAllInformacoesNutricionaisQueryHandlerTests
{
    private readonly Mock<IInformacaoNutricionalRepository> _informacaoNutricionalRepositoryMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly IRequestHandler<GetAllInformacoesNutricionaisQuery, IEnumerable<InformacaoNutricionalViewModel>> _handler;

    public GetAllInformacoesNutricionaisQueryHandlerTests()
    {
        _informacaoNutricionalRepositoryMock = new Mock<IInformacaoNutricionalRepository>();
        _mapperMock = new Mock<IMapper>();
        _handler = new GetAllInformacoesNutricionaisQueryHandler(_mapperMock.Object, _informacaoNutricionalRepositoryMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldReturnAllInformacoesNutricionais()
    {
        // Arrange
        var informacoesNutricionais = new List<InformacaoNutricional>
        {
            new InformacaoNutricional (1, 100, 100, 100, 100, 100),
            new InformacaoNutricional (2, 100, 100, 100, 100, 100)
        };

        var informacoesNutricionaisViewModel = new List<InformacaoNutricionalViewModel>
        {
            new InformacaoNutricionalViewModel { AlimentoId = 1, Calorias = 100, Carboidratos = 100, Fibras = 100, Gorduras = 100, Proteinas = 100 },
            new InformacaoNutricionalViewModel { AlimentoId = 2, Calorias = 100, Carboidratos = 100, Fibras = 100, Gorduras = 100, Proteinas = 100 }
        };

        _informacaoNutricionalRepositoryMock.Setup(repo => repo.BuscarInformacoesNutricionaisAsync()).ReturnsAsync(informacoesNutricionais);
        _mapperMock.Setup(m => m.Map<IEnumerable<InformacaoNutricionalViewModel>>(It.IsAny<IEnumerable<InformacaoNutricional>>())).Returns(informacoesNutricionaisViewModel);

        var query = new GetAllInformacoesNutricionaisQuery();

        // Act
        var result = await _handler.Handle(query, new CancellationToken());


        // Assert
        Assert.NotNull(result);
        Assert.Equal(informacoesNutricionais.Count, result.Count());

    }
}
