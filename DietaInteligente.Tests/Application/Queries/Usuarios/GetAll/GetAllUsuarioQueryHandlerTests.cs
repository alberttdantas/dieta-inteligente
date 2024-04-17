
using AutoMapper;
using DietaInteligente.Application.Queries.Usuarios.GetAll;
using DietaInteligente.Application.ViewModels;
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Enums;
using DietaInteligente.Domain.Repositories;
using MediatR;
using Moq;

namespace DietaInteligente.Tests.Application.Queries.Usuarios.GetAll;

public class GetAllUsuarioQueryHandlerTests
{
    private readonly Mock<IUsuarioRepository> _usuarioRepositoryMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly IRequestHandler<GetAllUsuariosQuery, IEnumerable<UsuarioViewModel>> _handler;

    public GetAllUsuarioQueryHandlerTests()
    {
        _usuarioRepositoryMock = new Mock<IUsuarioRepository>();
        _mapperMock = new Mock<IMapper>();
        _handler = new GetAllUsuariosQueryHandler(_mapperMock.Object, _usuarioRepositoryMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldReturnAllUsuarios()
    {
        // Arrange
        var usuarios = new List<Usuario>
        {
            new Usuario("Nome 1", "Email 1", 70, 1.75m, Objetivos.definir_musculos),
            new Usuario("Nome 2", "Email 2", 80, 1.80m, Objetivos.ganhar_massa)
        };

        var usuariosViewModel = new List<UsuarioViewModel>
        {
            new UsuarioViewModel { Id = 1, Nome = "Nome 1", Email = "Email 1", Peso = 70, Altura = 1.75m, Objetivo = Objetivos.definir_musculos },
            new UsuarioViewModel { Id = 2, Nome = "Nome 2", Email = "Email 2", Peso = 80, Altura = 1.80m, Objetivo = Objetivos.ganhar_massa }
        };

        _usuarioRepositoryMock.Setup(repo => repo.BuscarUsuariosAsync()).ReturnsAsync(usuarios);
        _mapperMock.Setup(m => m.Map<IEnumerable<UsuarioViewModel>>(usuarios)).Returns(usuariosViewModel);

        var query = new GetAllUsuariosQuery();

        // Act
        var result = await _handler.Handle(query, new CancellationToken());


        // Assert
        Assert.NotNull(result);
        Assert.Equal(usuariosViewModel.Count, result.Count());
        Assert.All(result, item => Assert.Contains(item, usuariosViewModel));

    }
}
