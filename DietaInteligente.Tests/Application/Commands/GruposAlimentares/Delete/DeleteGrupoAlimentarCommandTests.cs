
using DietaInteligente.Application.Commands.GruposAlimentares.Delete;
using DietaInteligente.Application.InputModels;

namespace DietaInteligente.Tests.Application.Commands.GruposAlimentares.Delete;

public class DeleteGrupoAlimentarCommandTests
{
    [Fact]
    public void DeleteGruposAlimentaresCommand_ConstructedWithValidData_ShouldCreateCorrectObject()
    {
        // Arrange
        var grupoAlmentarId = 1;

        // Act
        var command = new DeleteGrupoAlimentarCommand(grupoAlmentarId);


        // Assert
        Assert.Equal(grupoAlmentarId, command.Id);

    }
}
