
using DietaInteligente.Application.Commands.DietasAlimentos.Disassociate;

namespace DietaInteligente.Tests.Application.Commands.DietasAlimentos.Disassociate;

public class DisassociateDietaAlimentoCommandTests
{

    [Fact]
    public void Command_ShouldSetPropertiesCorrectly()
    {
        // Arrange
        var dietaId = 1;
        var alimentoId = 2;

        // Act
        var command = new DisassociateDietaAlimentoCommand(dietaId, alimentoId);

        // Assert
        Assert.Equal(dietaId, command.DietaId);
        Assert.Equal(alimentoId, command.AlimentoId);
    }
}
