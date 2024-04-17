
using AutoMapper;
using DietaInteligente.Application.Queries.Usuarios.GetById;
using DietaInteligente.Application.ViewModels;
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Enums;
using DietaInteligente.Domain.Repositories;
using MediatR;
using Moq;

namespace DietaInteligente.Tests.Application.Queries.Usuarios.GetById;

public class GetUsuarioByIdQueryHandlerTests
{
    private readonly Mock<IUsuarioRepository> _usuarioRepositoryMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly IRequestHandler<GetUsuarioByIdQuery, UsuarioViewModel> _handler;

    public GetUsuarioByIdQueryHandlerTests()
    {
        _usuarioRepositoryMock = new Mock<IUsuarioRepository>();
        _mapperMock = new Mock<IMapper>();
        _handler = new GetUsuarioByIdQueryHandler(_mapperMock.Object, _usuarioRepositoryMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldReturnUsuarioById()
    {
        // Arrange
        int usuarioId = 1;
        var usuario = new Usuario("Nome 1", "Email 1", 70, 1.75m, Objetivos.ganhar_massa);

        var usuarioViewModel = new UsuarioViewModel
        {
            Id = usuarioId,
            Nome = "Nome 1",
            Email = "Email 1",
            Peso = 70,
            Altura = 1.75m,
            Objetivo = Objetivos.ganhar_massa
        };

        _usuarioRepositoryMock.Setup(repo => repo.BuscarUsuarioAsync(usuarioId)).ReturnsAsync(usuario);
        _mapperMock.Setup(m => m.Map<UsuarioViewModel>(usuario)).Returns(usuarioViewModel);

        var query = new GetUsuarioByIdQuery(usuarioId);

        // Act
        var result = await _handler.Handle(query, new CancellationToken());

        // Assert
        Assert.NotNull(result);
        Assert.Equal(usuarioId, result.Id);
        Assert.Equal("Nome 1", result.Nome);
        Assert.Equal("Email 1", result.Email);
        Assert.Equal(70, result.Peso);
        Assert.Equal(1.75m, result.Altura);
        Assert.Equal(Objetivos.ganhar_massa, result.Objetivo);

    }
}
