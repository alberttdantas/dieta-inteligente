
using AutoMapper;
using DietaInteligente.Application.Commands.Alimentos.Create;
using DietaInteligente.Application.InputModels;
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Repositories;
using Moq;

namespace DietaInteligente.Tests.Application.Commands.Alimentos.Create;

public class CreateAlimentoCommandHandlerTests
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAlimentoRepository> _alimentoRepositoryMock;
    private readonly CreateAlimentoCommandHandler _handler;

    public CreateAlimentoCommandHandlerTests()
    {
        _mapperMock = new Mock<IMapper>();
        _alimentoRepositoryMock = new Mock<IAlimentoRepository>();
        _handler = new CreateAlimentoCommandHandler(_mapperMock.Object, _alimentoRepositoryMock.Object);
    }

    [Fact]
    public async Task Handle_ValidInputModel_ShouldCreateAlimento()
    {
        // Arrange
        var inputModel = new AlimentoInputModel
        {
            Nome = "Maçã",
            GrupoAlimentarId = 1,
            InformacaoNutricionalId = 1
        };

        var alimento = new Alimento("Maçã", 1, 1);
        var command = new CreateAlimentoCommand(inputModel);
        _mapperMock.Setup(m => m.Map<Alimento>(It.IsAny<AlimentoInputModel>())).Returns(alimento);
        _alimentoRepositoryMock.Setup(repo => repo.InserirAlimentoAsync(It.IsAny<Alimento>())).ReturnsAsync(true);


        // Act
        var result = await _handler.Handle(command, new CancellationToken());


        // Assert
        Assert.True(result.Success);
        _mapperMock.Verify(m => m.Map<Alimento>(It.IsAny<AlimentoInputModel>()), Times.Once);
        _alimentoRepositoryMock.Verify(repo => repo.InserirAlimentoAsync(It.IsAny<Alimento>()), Times.Once);

    }
}
