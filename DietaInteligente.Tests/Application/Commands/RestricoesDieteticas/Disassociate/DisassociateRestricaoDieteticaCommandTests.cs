
using DietaInteligente.Application.Commands.RestricoesDieteticas.Disassociate;

namespace DietaInteligente.Tests.Application.Commands.RestricoesDieteticas.Disassociate;

public class DisassociateRestricaoDieteticaCommandTests
{
    [Fact]
    public void Command_RestricaoDieteticaShouldSetPropertiesCorrectly()
    {
        // Arrange
        var usuarioId = 1;
        var grupoAlimentarId = 2;


        // Act
        var command = new DisassociateRestricaoDieteticaCommand(usuarioId, grupoAlimentarId);

        // Assert
        Assert.Equal(usuarioId, command.UsuarioId);
        Assert.Equal(grupoAlimentarId, command.GrupoAlimentarId);
    }
}
