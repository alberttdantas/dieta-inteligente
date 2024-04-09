
using DietaInteligente.Application.Commands.GruposAlimentares.Create;
using DietaInteligente.Application.InputModels;

namespace DietaInteligente.Tests.Application.Commands.GruposAlimentares.Create;

public class CreateGrupoAlimentarCommandTests
{
    [Fact]
    public void CreateGrupoAlimentarCommand_ConstructedWithValidData_ShouldCreateCorrectObject()
    {
        // Arrange
        var inputModel = new GrupoAlimentarInputModel
        {
            Nome = "Nome"
        };

        // Act
        var command = new CreateGrupoAlimentarCommand(inputModel);

        // Assert
        Assert.NotNull(command.GrupoAlimentarInput);
        Assert.Equal("Nome", command.GrupoAlimentarInput.Nome);

    }
}
