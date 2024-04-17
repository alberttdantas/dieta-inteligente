
using AutoMapper;
using DietaInteligente.Application.Queries.Dietas.GetById;
using DietaInteligente.Application.ViewModels;
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Repositories;
using MediatR;
using Moq;

namespace DietaInteligente.Tests.Application.Queries.Dietas.GetById;

public class GetDietaByIdQueryHandlerTests
{
    private readonly Mock<IDietaRepository> _dietaRepositoryMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly IRequestHandler<GetDietaByIdQuery, DietaViewModel> _handler;

    public GetDietaByIdQueryHandlerTests()
    {
        _dietaRepositoryMock = new Mock<IDietaRepository>();
        _mapperMock = new Mock<IMapper>();
        _handler = new GetDietaByIdQueryHandler(_mapperMock.Object, _dietaRepositoryMock.Object);
    }

    [Fact]
    public async Task Handle_ValidId_ShouldReturnDietaViewModel()
    {
        // Arrange
        var dietaId = 1;
        var dieta = new Dieta(1) { Id = dietaId };
        var dietaViewModel = new DietaViewModel { Id = dietaId, Data = new DateTime(2024, 4, 4) };

        _dietaRepositoryMock.Setup(repo => repo.BuscarDietaAsync(dietaId)).ReturnsAsync(dieta);
        _mapperMock.Setup(m => m.Map<DietaViewModel>(It.IsAny<Dieta>())).Returns(dietaViewModel);

        var query = new GetDietaByIdQuery(dietaId);

        // Act
        var result = await _handler.Handle(query, new CancellationToken());

        // Assert
        Assert.NotNull(result);
        Assert.Equal(dietaId, result.Id);
        Assert.Equal(1, result.Id);
        Assert.Equal(new DateTime(2024, 4, 4), result.Data);

    }
}
