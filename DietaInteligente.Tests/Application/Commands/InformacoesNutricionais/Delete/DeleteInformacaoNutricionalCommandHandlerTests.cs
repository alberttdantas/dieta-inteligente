
using AutoMapper;
using DietaInteligente.Application.Commands.InformacoesNutricionais.Delete;
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Repositories;
using Moq;

namespace DietaInteligente.Tests.Application.Commands.InformacoesNutricionais.Delete;

public class DeleteInformacaoNutricionalCommandHandlerTests
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IInformacaoNutricionalRepository> _informacaoNutricionalRepositoryMock;
    private readonly DeleteInformacoesNutricionaisCommandHandler _handler;

    public DeleteInformacaoNutricionalCommandHandlerTests()
    {
        _mapperMock = new Mock<IMapper>();
        _informacaoNutricionalRepositoryMock = new Mock<IInformacaoNutricionalRepository>();
        _handler = new DeleteInformacoesNutricionaisCommandHandler(_mapperMock.Object, _informacaoNutricionalRepositoryMock.Object);
    }

    [Fact]
    public async void Handle_InformacaoNutricionalExists_ShouldDeleteInformacaoNutricionalAndReturnSuccess()
    {
        // Arrange
        var informacaoNutricionalId = 1;
        var informacaoNutricional = new InformacaoNutricional(1, 100, 100, 100, 100, 100);
        var command = new DeleteInformacoesNutricionaisCommand(informacaoNutricionalId);
        _informacaoNutricionalRepositoryMock.Setup(repo => repo.BuscarInformacaoNutricionalAsync(informacaoNutricionalId)).ReturnsAsync(informacaoNutricional);
        _informacaoNutricionalRepositoryMock.Setup(repo => repo.DeletarInformacaoNutricionalAsync(informacaoNutricional)).ReturnsAsync(true);

        // Act
        var result = await _handler.Handle(command, new CancellationToken());

        // Assert
        Assert.True(result.Success);
        Assert.Equal("Sucesso ao deletar informação nutricional!", result.Message);
        _informacaoNutricionalRepositoryMock.Verify(repo => repo.BuscarInformacaoNutricionalAsync(informacaoNutricionalId), Times.Once);
        _informacaoNutricionalRepositoryMock.Verify(repo => repo.DeletarInformacaoNutricionalAsync(informacaoNutricional), Times.Once);
    }

    [Fact]
    public async void Handle_InformacaoNutricionalDoesNotExist_ShouldReturnFailure()
    {
        // Arrange
        var informacaoNutricionalId = 1;
        var command = new DeleteInformacoesNutricionaisCommand(informacaoNutricionalId);
        _informacaoNutricionalRepositoryMock.Setup(repo => repo.BuscarInformacaoNutricionalAsync(informacaoNutricionalId)).ReturnsAsync((InformacaoNutricional)null);


        // Act
        var result = await _handler.Handle(command, new CancellationToken());


        // Assert
        Assert.False(result.Success);
        Assert.Contains("Informação nutricional não encontrada!", result.Errors);
        _informacaoNutricionalRepositoryMock.Verify(repo => repo.BuscarInformacaoNutricionalAsync(informacaoNutricionalId), Times.Once);
        _informacaoNutricionalRepositoryMock.Verify(repo => repo.DeletarInformacaoNutricionalAsync(It.IsAny<InformacaoNutricional>()), Times.Never);
    }
}
