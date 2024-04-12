
using AutoMapper;
using DietaInteligente.Application.Commands.InformacoesNutricionais.Update;
using DietaInteligente.Application.InputModels;
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Repositories;
using Moq;

namespace DietaInteligente.Tests.Application.Commands.InformacoesNutricionais.Update;

public class UpdateInformacaoNutricionalCommandHandlerTests
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IInformacaoNutricionalRepository> _informacaoNutricionalRepositoryMock;
    private readonly UpdateInformacoesNutricionaisCommandHandler _handler;

    public UpdateInformacaoNutricionalCommandHandlerTests()
    {
        _mapperMock = new Mock<IMapper>();
        _informacaoNutricionalRepositoryMock = new Mock<IInformacaoNutricionalRepository>();
        _handler = new UpdateInformacoesNutricionaisCommandHandler(_mapperMock.Object, _informacaoNutricionalRepositoryMock.Object);
    }

    [Fact]
    public async void Handle_ValidInformacaoNutricional_ShouldUpdateInformacaoNutricionalAndReturnSuccess()
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

        var informalNutricional = new InformacaoNutricional(informacaoNutricionalInputModel.AlimentoId, informacaoNutricionalInputModel.Fibras, informacaoNutricionalInputModel.Calorias, informacaoNutricionalInputModel.Gorduras, informacaoNutricionalInputModel.Carboidratos, informacaoNutricionalInputModel.Proteinas)
        {
            AlimentoId = 10
        };

        var command = new UpdateInformacoesNutricionaisCommand(informacaoNutricionalInputModel);
        _mapperMock.Setup(m => m.Map<InformacaoNutricional>(informacaoNutricionalInputModel)).Returns(informalNutricional);
        _informacaoNutricionalRepositoryMock.Setup(repo => repo.AtualizarInformacaoNutricionalAsync(informalNutricional)).ReturnsAsync(true);

        // Act
        var result = await _handler.Handle(command, new CancellationToken());

        // Assert
        Assert.True(result.Success);
        Assert.Equal("Sucesso ao atualizar informação nutricional!", result.Message);
        _mapperMock.Verify(m => m.Map<InformacaoNutricional>(informacaoNutricionalInputModel), Times.Once());
        _informacaoNutricionalRepositoryMock.Verify(repo => repo.AtualizarInformacaoNutricionalAsync(informalNutricional), Times.Once());
    }

    [Fact]
    public async void Handle_InvalidInformacaoNutricional_ShouldNotUpdateInformacaoNutricionalAndReturnFailure()
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

        var command = new UpdateInformacoesNutricionaisCommand(informacaoNutricionalInputModel);
        _mapperMock.Setup(m => m.Map<InformacaoNutricional>(informacaoNutricionalInputModel)).Returns((InformacaoNutricional)null);

        // Act
        var result = await _handler.Handle(command, new CancellationToken());


        // Assert
        Assert.False(result.Success);
        Assert.Contains("Informação nutricional não encontrada!", result.Errors);
        _mapperMock.Verify(m => m.Map<InformacaoNutricional>(informacaoNutricionalInputModel), Times.Once());
        _informacaoNutricionalRepositoryMock.Verify(repo => repo.AtualizarInformacaoNutricionalAsync(It.IsAny<InformacaoNutricional>()), Times.Never);
    }
}
