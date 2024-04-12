
using DietaInteligente.Application.Commands.RestricoesDieteticas.Associate;

namespace DietaInteligente.Tests.Application.Commands.RestricoesDieteticas.Associate;

public class AssociateRestricaoDieteticaCommandTests
{
    [Fact]
    public void Command_RestricaoDieteticaShouldSetPropertiesCorrectly()
    {
        // Arrange
        var usuarioId = 1;
        var grupoAlimentarId = 2;

        // Act
        var command = new AssociateRestricaoDieteticaCommand(usuarioId, grupoAlimentarId);

        // Assert
        Assert.Equal(usuarioId, command.UsuarioId);
        Assert.Equal(grupoAlimentarId, command.GrupoAlimentarId);

    }
}
