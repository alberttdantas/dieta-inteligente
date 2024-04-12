
using DietaInteligente.Application.Commands.Usuarios.Delete;

namespace DietaInteligente.Tests.Application.Commands.Usuarios.Delete;

public class DeleteUsuarioCommandTests
{
    [Fact]
    public void DeleteUsuariosCommand_ConstructedWithValidData_ShouldCreateCorrectObject()
    {
        // Arrange
        var usuarioId = 1;

        // Act
        var command = new DeleteUsuarioCommand(usuarioId);

        // Assert
        Assert.Equal(usuarioId, command.Id);

    }
}
