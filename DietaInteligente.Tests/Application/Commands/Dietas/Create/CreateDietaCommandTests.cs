
using DietaInteligente.Application.Commands.Dietas.Create;
using DietaInteligente.Application.InputModels;

namespace DietaInteligente.Tests.Application.Commands.Dietas.Create;

public class CreateDietaCommandTests
{
    [Fact]
    public void CreateDietaCommand_ConstructedWithValidData_ShouldCreateCorrectObject()
    {
        // Arrange
        var inputModel = new DietaInputModel
        {
            Data = new DateTime(2024, 4, 4),
            UsuarioId = 1
        };

        // Act
        var command = new CreateDietaCommand(inputModel);

        // Assert
        Assert.NotNull(command.DietaInput);
        Assert.Equal(new DateTime(2024, 4, 4), command.DietaInput.Data);
        Assert.Equal(1, command.DietaInput.UsuarioId);

    }
}
