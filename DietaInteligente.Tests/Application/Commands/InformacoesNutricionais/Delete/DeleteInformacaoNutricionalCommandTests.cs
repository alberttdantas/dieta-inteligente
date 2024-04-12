
using DietaInteligente.Application.Commands.InformacoesNutricionais.Delete;

namespace DietaInteligente.Tests.Application.Commands.InformacoesNutricionais.Delete;

public class DeleteInformacaoNutricionalCommandTests
{
    [Fact]
    public void DeleteInformacoesNutricionaisCommand_ConstructedWithValidData_ShouldCreateCorrectObject()
    {
        // Arrange
        var informacaoNutricionalId = 1;

        // Act
        var command = new DeleteInformacoesNutricionaisCommand(informacaoNutricionalId);

        // Assert
        Assert.Equal(informacaoNutricionalId, command.Id);

    }

}
