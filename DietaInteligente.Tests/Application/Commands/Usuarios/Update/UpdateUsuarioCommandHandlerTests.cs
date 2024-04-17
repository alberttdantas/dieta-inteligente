
using AutoMapper;
using DietaInteligente.Application.Commands.Alimentos.Update;
using DietaInteligente.Application.Commands.Usuarios.Update;
using DietaInteligente.Application.InputModels;
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Repositories;
using Moq;

namespace DietaInteligente.Tests.Application.Commands.Usuarios.Update;

public class UpdateUsuarioCommandHandlerTests
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IUsuarioRepository> _usuarioRepositoryMock;
    private readonly UpdateUsuarioCommandHandler _handler;

    public UpdateUsuarioCommandHandlerTests()
    {
        _mapperMock = new Mock<IMapper>();
        _usuarioRepositoryMock = new Mock<IUsuarioRepository>();
        _handler = new UpdateUsuarioCommandHandler(_mapperMock.Object, _usuarioRepositoryMock.Object);
    }

    [Fact]
    public async void Handle_ValidUsuario_ShouldUpdateUsuarioAndReturnSuccess()
    {
        // Arrange
        var usuarioInputModel = new UsuarioInputModel
        {
            Altura = 100m,
            Email = "Email",
            Nome = "Nome",
            Peso = 100m,
            Objetivo = Domain.Enums.Objetivos.definir_musculos
        };

        var usuario = new Usuario(usuarioInputModel.Nome, usuarioInputModel.Email, usuarioInputModel.Altura.Value, usuarioInputModel.Peso.Value, usuarioInputModel.Objetivo.Value)
        {
        };

        var command = new UpdateUsuarioCommand(usuarioInputModel);
        _mapperMock.Setup(m => m.Map<Usuario>(usuarioInputModel)).Returns(usuario);
        _usuarioRepositoryMock.Setup(repo => repo.AtualizarUsuarioAsync(usuario)).ReturnsAsync(true);

        // Act
        var result = await _handler.Handle(command, new CancellationToken());

        // Assert
        Assert.True(result.Success);
        Assert.Equal("Sucesso ao atualizar dados do usuario!", result.Message);
        _mapperMock.Verify(m => m.Map<Usuario>(usuarioInputModel), Times.Once());
        _usuarioRepositoryMock.Verify(repo => repo.AtualizarUsuarioAsync(usuario), Times.Once());
    }

    [Fact]
    public async void Handle_InvalidUsuario_ShouldNotUpdateUsuarioAndReturnFailure()
    {
        // Arrange
        var usuarioInputModel = new UsuarioInputModel
        {
            Altura = 100m,
            Email = "Email",
            Nome = "Nome",
            Peso = 100m,
            Objetivo = Domain.Enums.Objetivos.definir_musculos
        };

        var command = new UpdateUsuarioCommand(usuarioInputModel);
        _mapperMock.Setup(m => m.Map<Usuario>(usuarioInputModel)).Returns((Usuario)null);


        // Act
        var result = await _handler.Handle(command, new CancellationToken());


        // Assert
        Assert.False(result.Success);
        Assert.Contains("Usuario não encontrado!", result.Errors);
        _mapperMock.Verify(m => m.Map<Usuario>(usuarioInputModel), Times.Once());
        _usuarioRepositoryMock.Verify(repo => repo.AtualizarUsuarioAsync(It.IsAny<Usuario>()), Times.Never());
    }
}