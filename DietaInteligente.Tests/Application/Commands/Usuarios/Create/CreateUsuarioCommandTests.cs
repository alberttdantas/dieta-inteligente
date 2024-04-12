
using DietaInteligente.Application.Commands.Usuarios.Create;
using DietaInteligente.Application.InputModels;

namespace DietaInteligente.Tests.Application.Commands.Usuarios.Create;

public class CreateUsuarioCommandTests
{
    [Fact]
    public void CreateUsuarioCommand_ConstructedWithValidData_ShouldCreateCorrectObject()
    {
        // Arrange
        var inputModel = new UsuarioInputModel
        {
            Altura = 100,
            Email = "Email",
            Nome = "Nome",
            Peso = 100,
            Objetivo = Domain.Enums.Objetivos.definir_musculos
        };


        // Act
        var command = new CreateUsuarioCommand(inputModel);

        // Assert
        Assert.NotNull(command.UsuarioInput);
        Assert.Equal(100, command.UsuarioInput.Altura);
        Assert.Equal("Email", command.UsuarioInput.Email);
        Assert.Equal("Nome", command.UsuarioInput.Nome);
        Assert.Equal(Domain.Enums.Objetivos.definir_musculos, command.UsuarioInput.Objetivo);
    }
}
