
using DietaInteligente.Application.Commands.Usuarios.Update;
using DietaInteligente.Application.InputModels;

namespace DietaInteligente.Tests.Application.Commands.Usuarios.Update;

public class UpdateUsuarioCommandTests
{
    [Fact]
    public void UpdateUsuariosCommand_ConstructedWithValidData_ShouldCreateCorrectObject()
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

        // Act
        var command = new UpdateUsuarioCommand(usuarioInputModel);

        // Assert
        Assert.NotNull(command.UsuarioInput);
        Assert.Equal(100, command.UsuarioInput.Altura);
        Assert.Equal("Email", command.UsuarioInput.Email);
        Assert.Equal("Nome", command.UsuarioInput.Nome);
        Assert.Equal(Domain.Enums.Objetivos.definir_musculos, command.UsuarioInput.Objetivo);
    }
}
