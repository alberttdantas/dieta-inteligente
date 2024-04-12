
using DietaInteligente.Application.Commands.GruposAlimentares.Create;
using DietaInteligente.Application.Commands.InformacoesNutricionais.Create;
using DietaInteligente.Application.InputModels;

namespace DietaInteligente.Tests.Application.Commands.InformacoesNutricionais.Create;

public class CreateInformacaoNutricionalCommandTests
{
    [Fact]
    public void CreateInformacaoNutricionalCommand_ConstructedWithValidData_ShouldCreateCorrectObject()
    {
        // Arrange
        var inputModel = new InformacaoNutricionalInputModel
        {
            AlimentoId = 1,
            Calorias = 100,
            Carboidratos = 100,
            Fibras = 100,
            Gorduras = 100,
            Proteinas = 100
        };

        // Act
        var command = new CreateInformacoesNutricionaisCommand(inputModel);

        // Assert
        Assert.NotNull(command.InformacaoNutricionalInput);
        Assert.Equal(1, command.InformacaoNutricionalInput.AlimentoId);
        Assert.Equal(100, command.InformacaoNutricionalInput.Calorias);
        Assert.Equal(100, command.InformacaoNutricionalInput.Carboidratos);
        Assert.Equal(100, command.InformacaoNutricionalInput.Fibras);
        Assert.Equal(100, command.InformacaoNutricionalInput.Gorduras);
        Assert.Equal(100, command.InformacaoNutricionalInput.Proteinas);
    }
}
