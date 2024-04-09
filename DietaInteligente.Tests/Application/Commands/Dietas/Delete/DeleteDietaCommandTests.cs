
using DietaInteligente.Application.Commands.Dietas.Delete;

namespace DietaInteligente.Tests.Application.Commands.Dietas.Delete;

public class DeleteDietaCommandTests
{
    [Fact]
    public void DeleteDietaCommand_CreatedWithValidId_ShouldHaveCorrectId()
    {
        // Arrange
        var dietaId = 1;


        // Act
        var command = new DeleteDietaCommand(dietaId);


        // Assert
        Assert.Equal(dietaId, command.Id);

    }
}
