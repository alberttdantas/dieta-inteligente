
using AutoMapper;
using DietaInteligente.Application.Commands.Usuarios.Create;
using DietaInteligente.Application.InputModels;
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Enums;
using DietaInteligente.Domain.Repositories;
using Moq;

namespace DietaInteligente.Tests.Application.Commands.Usuarios.Create;

public class CreateUsuarioCommandHandlerTests
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IUsuarioRepository> _usuarioRepositoryMock;
    private readonly CreateUsuarioCommandHandler _handler;

    public CreateUsuarioCommandHandlerTests()
    {
        _mapperMock = new Mock<IMapper>();
        _usuarioRepositoryMock = new Mock<IUsuarioRepository>();
        _handler = new CreateUsuarioCommandHandler(_mapperMock.Object, _usuarioRepositoryMock.Object);
    }

    [Fact]
    public async void Handle_ValidInputModel_ShouldCreateUsuarioAndReturnSuccess()
    {
        // Arrange
        var usuarioInputModel = new UsuarioInputModel
        {
            Altura = 100,
            Email = "Email",
            Nome = "Nome",
            Peso = 100,
            Objetivo = Domain.Enums.Objetivos.definir_musculos
        };

        var usuario = new Usuario("Nome", "Email", 100, 100, Domain.Enums.Objetivos.definir_musculos);

        var command = new CreateUsuarioCommand(usuarioInputModel);
        _mapperMock.Setup(m => m.Map<Usuario>(It.IsAny<UsuarioInputModel>())).Returns(usuario);
        _usuarioRepositoryMock.Setup(repo => repo.CriarUsuarioAsync(It.IsAny<Usuario>())).ReturnsAsync(true);

        // Act
        var result = await _handler.Handle(command, new CancellationToken());


        // Assert
        Assert.True(result.Success);
        Assert.Equal("Sucesso ao criar usuario!", result.Message);
        _mapperMock.Verify(m => m.Map<Usuario>(It.IsAny<UsuarioInputModel>()), Times.Once());
        _usuarioRepositoryMock.Verify(repo => repo.CriarUsuarioAsync(It.IsAny<Usuario>()), Times.Once);
    }

    [Fact]
    public async void Handle_InvalidInputModel_ShouldReturnFailure()
    {
        // Arrange
        var usuarioInputModel = new UsuarioInputModel
        {
            Altura = 100,
            Email = "Email",
            Nome = "Nome",
            Peso = 100,
            Objetivo = Domain.Enums.Objetivos.definir_musculos
        };

        var command = new CreateUsuarioCommand(usuarioInputModel);
        _mapperMock.Setup(m => m.Map<Usuario>(It.IsAny<UsuarioInputModel>())).Returns((Usuario)null);
        _usuarioRepositoryMock.Setup(repo => repo.CriarUsuarioAsync(null)).ReturnsAsync(false);

        // Act
        var result = await _handler.Handle(command, new CancellationToken());


        // Assert
        Assert.False(result.Success);
        Assert.NotEmpty(result.Errors);
        _mapperMock.Verify(m => m.Map<Usuario>(It.IsAny<UsuarioInputModel>()), Times.Once);
        _usuarioRepositoryMock.Verify(repo => repo.CriarUsuarioAsync(null), Times.Once);
    }
}
