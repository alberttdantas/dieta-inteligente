
using AutoMapper;
using DietaInteligente.Application.Commands.InformacoesNutricionais.Create;
using DietaInteligente.Application.InputModels;
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Repositories;
using Moq;

namespace DietaInteligente.Tests.Application.Commands.InformacoesNutricionais.Create;

public class CreateInformacaoNutricionalCommandHandlerTests
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IInformacaoNutricionalRepository> _informacaoNutricionalRepositoryMock;
    private readonly CreateInformacoesNutricionaisCommandHandler _handler;

    public CreateInformacaoNutricionalCommandHandlerTests()
    {
        _mapperMock = new Mock<IMapper>();
        _informacaoNutricionalRepositoryMock = new Mock<IInformacaoNutricionalRepository>();
        _handler = new CreateInformacoesNutricionaisCommandHandler(_mapperMock.Object, _informacaoNutricionalRepositoryMock.Object);
    }

    [Fact]
    public async void Handle_ValidInputModel_ShouldCreateInformacaoNutricionalAndReturnSuccess()
    {
        // Arrange
        var informacaoNutricionalInputModel = new InformacaoNutricionalInputModel
        {
            AlimentoId = 1,
            Calorias = 100,
            Carboidratos = 100,
            Fibras = 100,
            Gorduras = 100,
            Proteinas = 100
        };

        var informacaoNutricional = new InformacaoNutricional(1, 100, 100, 100, 100, 100);

        var command = new CreateInformacoesNutricionaisCommand(informacaoNutricionalInputModel);
        _mapperMock.Setup(m => m.Map<InformacaoNutricional>(It.IsAny<InformacaoNutricionalInputModel>())).Returns(informacaoNutricional);
        _informacaoNutricionalRepositoryMock.Setup(repo => repo.CriarInformacaoNutricionalAsync(It.IsAny<InformacaoNutricional>())).ReturnsAsync(true);

        // Act
        var result = await _handler.Handle(command, new CancellationToken());

        // Assert
        Assert.True(result.Success);
        Assert.Equal("Sucesso ao criar informação nutricional!", result.Message);
        _mapperMock.Verify(m => m.Map<InformacaoNutricional>(It.IsAny<InformacaoNutricionalInputModel>()), Times.Once);
        _informacaoNutricionalRepositoryMock.Verify(repo => repo.CriarInformacaoNutricionalAsync(It.IsAny<InformacaoNutricional>()), Times.Once);
    }

    [Fact]
    public async void Handle_InvalidInputModel_ShouldReturnFailure()
    {
        // Arrange
        var informacaoNutricionalInputModel = new InformacaoNutricionalInputModel
        {
            AlimentoId = 1,
            Calorias = 100,
            Carboidratos = 100,
            Fibras = 100,
            Gorduras = 100,
            Proteinas = 100
        };

        var command = new CreateInformacoesNutricionaisCommand(informacaoNutricionalInputModel);
        _mapperMock.Setup(m => m.Map<InformacaoNutricional>(It.IsAny<InformacaoNutricionalInputModel>())).Returns((InformacaoNutricional)null);
        _informacaoNutricionalRepositoryMock.Setup(repo => repo.CriarInformacaoNutricionalAsync(null)).ReturnsAsync(false);

        // Act
        var result = await _handler.Handle(command, new CancellationToken());

        // Assert
        Assert.False(result.Success);
        Assert.NotEmpty(result.Errors);
        _mapperMock.Verify(m => m.Map<InformacaoNutricional>(It.IsAny<InformacaoNutricionalInputModel>()), Times.Once);
        _informacaoNutricionalRepositoryMock.Verify(repo => repo.CriarInformacaoNutricionalAsync(null), Times.Once);
    }
}
