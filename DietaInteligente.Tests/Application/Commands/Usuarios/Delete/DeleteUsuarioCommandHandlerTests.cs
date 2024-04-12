
using AutoMapper;
using DietaInteligente.Application.Commands.Usuarios.Delete;
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Repositories;
using Moq;

namespace DietaInteligente.Tests.Application.Commands.Usuarios.Delete;

public class DeleteUsuarioCommandHandlerTests
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IUsuarioRepository> _usuarioRepositoryMock;
    private readonly DeleteUsuarioCommandHandler _handler;

    public DeleteUsuarioCommandHandlerTests()
    {
        _mapperMock = new Mock<IMapper>();
        _usuarioRepositoryMock = new Mock<IUsuarioRepository>();
        _handler = new DeleteUsuarioCommandHandler(_mapperMock.Object, _usuarioRepositoryMock.Object);
    }

    [Fact]
    public async void Handle_UsuarioExists_ShouldDeleteUsuarioAndReturnSuccess()
    {
        // Arrange
        var usuarioId = 1;
        var usuario = new Usuario("Nome", "Email", 100, 100, Domain.Enums.Objetivos.definir_musculos);
        var command = new DeleteUsuarioCommand(usuarioId);
        _usuarioRepositoryMock.Setup(repo => repo.BuscarUsuarioAsync(usuarioId)).ReturnsAsync(usuario);
        _usuarioRepositoryMock.Setup(repo => repo.DeletarUsuarioAsync(usuario)).ReturnsAsync(true);

        // Act
        var result = await _handler.Handle(command, new CancellationToken());

        // Assert
        Assert.True(result.Success);
        Assert.Equal("Sucesso ao deletar usuario!", result.Message);
        _usuarioRepositoryMock.Verify(repo => repo.BuscarUsuarioAsync(usuarioId), Times.Once());
        _usuarioRepositoryMock.Verify(repo => repo.DeletarUsuarioAsync(usuario), Times.Once);
    }

    [Fact]
    public async void Handle_UsuarioDoesNotExist_ShouldReturnFailure()
    {
        // Arrange
        var usuarioId = 1;
        var command = new DeleteUsuarioCommand(usuarioId);
        _usuarioRepositoryMock.Setup(repo => repo.BuscarUsuarioAsync(usuarioId)).ReturnsAsync((Usuario)null);

        // Act
        var result = await _handler.Handle(command, new CancellationToken());


        // Assert
        Assert.False(result.Success);
        Assert.Contains("Usuario não encontrado!", result.Errors);
        _usuarioRepositoryMock.Verify(repo => repo.BuscarUsuarioAsync(usuarioId), Times.Once);
        _usuarioRepositoryMock.Verify(repo => repo.DeletarUsuarioAsync(It.IsAny<Usuario>()), Times.Never);
    }
}
