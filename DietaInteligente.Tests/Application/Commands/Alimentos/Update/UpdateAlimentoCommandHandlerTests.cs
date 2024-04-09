
using AutoMapper;
using DietaInteligente.Application.Commands.Alimentos.Update;
using DietaInteligente.Application.InputModels;
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Repositories;
using Moq;
using System.Security.Cryptography.X509Certificates;

namespace DietaInteligente.Tests.Application.Commands.Alimentos.Update;

public class UpdateAlimentoCommandHandlerTests
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAlimentoRepository> _alimentoRepositoryMock;
    private readonly UpdateAlimentoCommandHandler _handler;

    public UpdateAlimentoCommandHandlerTests()
    {
        _mapperMock = new Mock<IMapper>();
        _alimentoRepositoryMock = new Mock<IAlimentoRepository>();
        _handler = new UpdateAlimentoCommandHandler(_mapperMock.Object, _alimentoRepositoryMock.Object);
    }

    [Fact]
    public async Task Handle_ValidInputModel_ShouldUpdateAlimento()
    {
        // Arrange
        var alimentoInputModel = new AlimentoInputModel
        {
            Nome = "Maçã",
            GrupoAlimentarId = 1,
            InformacaoNutricionalId = 1
        };

        var alimento = new Alimento("Maçã", 1, 1);

        var command = new UpdateAlimentoCommand(alimentoInputModel);
        _mapperMock.Setup(m => m.Map<Alimento>(It.IsAny<AlimentoInputModel>())).Returns(alimento);
        _alimentoRepositoryMock.Setup(repo => repo.AtualizarAlimentoAsync(It.IsAny<Alimento>())).ReturnsAsync(true);


        // Act
        var result = await _handler.Handle(command, new CancellationToken());


        // Assert
        Assert.True(result.Success);
        _mapperMock.Verify(m => m.Map<Alimento>(It.IsAny<AlimentoInputModel>()), Times.Once);
        _alimentoRepositoryMock.Verify(repo => repo.AtualizarAlimentoAsync(It.IsAny<Alimento>()), Times.Once);


    }
}
