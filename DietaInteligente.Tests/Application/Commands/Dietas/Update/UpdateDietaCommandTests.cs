
using DietaInteligente.Application.Commands.Dietas.Update;
using DietaInteligente.Application.InputModels;

namespace DietaInteligente.Tests.Application.Commands.Dietas.Update;

public class UpdateDietaCommandTests
{
    [Fact]
    public void UpdateDietaCommand_CreatedWithValidInputModel_ShouldHaveCorrectInputModel()
    {
        // Arrange
        var dietaInputModel = new DietaInputModel
        {
            Data = new DateTime(2024, 4, 4),
            UsuarioId = 1
        };


        // Act
        var command = new UpdateDietaCommand(dietaInputModel);


        // Assert
        Assert.NotNull(command.DietaInput);
        Assert.Equal(new DateTime(2024, 4, 4), command.DietaInput.Data);
        Assert.Equal(1, command.DietaInput.UsuarioId);

    }
}
