using DietaInteligente.Application.Commands.Alimentos.Delete;

namespace DietaInteligente.Tests.Application.Commands.Alimentos.Delete;

public class DeleteAlimentoCommandTests
{
    [Fact]
    public void DeleteAlimentoCommand_CreatedWithValidId_ShouldHaveCorrectId()
    {
        // Arrange
        var alimentoId = 1;


        // Act
        var command = new DeleteAlimentoCommand(alimentoId);


        // Assert
        Assert.Equal(alimentoId, command.Id);

    }
}
