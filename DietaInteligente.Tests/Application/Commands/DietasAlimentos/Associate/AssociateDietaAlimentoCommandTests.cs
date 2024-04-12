
using DietaInteligente.Application.Commands.DietasAlimentos.Associate;

namespace DietaInteligente.Tests.Application.Commands.DietasAlimentos.Associate;

public class AssociateDietaAlimentoCommandTests
{
    [Fact]
    public void Command_DietaAlimentoShouldSetPropertiesCorrectly()
    {
        // Arrange
        var dietaId = 1;
        var alimentoId = 2;
        var quantidadeGramas = 100m;

        // Act
        var command = new AssociateDietaAlimentoCommand(dietaId, alimentoId, quantidadeGramas);

        // Assert
        Assert.Equal(dietaId, command.DietaId);
        Assert.Equal(alimentoId, command.AlimentoId);
        Assert.Equal(quantidadeGramas, command.QuantidadeGramas);
    }
}
