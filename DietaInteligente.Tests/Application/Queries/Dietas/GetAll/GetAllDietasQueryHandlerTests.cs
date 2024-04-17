
using AutoMapper;
using DietaInteligente.Application.Queries.Dietas.GetAll;
using DietaInteligente.Application.ViewModels;
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Repositories;
using MediatR;
using Moq;

namespace DietaInteligente.Tests.Application.Queries.Dietas.GetAll;

public class GetAllDietasQueryHandlerTests
{
    private readonly Mock<IDietaRepository> _dietaRepositoryMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly IRequestHandler<GetAllDietasQuery, IEnumerable<DietaViewModel>> _handler;

    public GetAllDietasQueryHandlerTests()
    {
        _dietaRepositoryMock = new Mock<IDietaRepository>();
        _mapperMock = new Mock<IMapper>();
        _handler = new GetAllDietasQueryHandler(_mapperMock.Object, _dietaRepositoryMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldReturnAllDietas()
    {
        // Arrange
        var dietas = new List<Dieta>
        {
            new Dieta (1, new DateTime(2024, 4, 4)),
            new Dieta (2)
        };

        var dietaViewModel = new List<DietaViewModel>
        {
            new DietaViewModel { Data = new DateTime(2024, 4, 4), UsuarioId = 1 },
            new DietaViewModel { Data = new DateTime(2024, 4, 4), UsuarioId = 2 }
        };

        _dietaRepositoryMock.Setup(repo => repo.BuscarDietasAsync()).ReturnsAsync(dietas);
        _mapperMock.Setup(m => m.Map<IEnumerable<DietaViewModel>>(It.IsAny<IEnumerable<Dieta>>())).Returns(dietaViewModel);

        var query = new GetAllDietasQuery();

        // Act
        var result = await _handler.Handle(query, new CancellationToken());


        // Assert
        Assert.NotNull(result);
        Assert.Equal(dietaViewModel.Count, result.Count());

    }
}
