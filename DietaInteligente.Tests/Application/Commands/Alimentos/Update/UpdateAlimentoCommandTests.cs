using DietaInteligente.Application.Commands.Alimentos.Update;
using DietaInteligente.Application.InputModels;

namespace DietaInteligente.Tests.Application.Commands.Alimentos.Update;

public class UpdateAlimentoCommandTests
{
    [Fact]
    public void UpdateAlimentoCommand_CreatedWithValidInputModel_ShouldHaveCorrectInputModel()
    {
        // Arrange
        var alimentoInputModel = new AlimentoInputModel
        {
            Nome = "Maçã",
            GrupoAlimentarId = 1,
            InformacaoNutricionalId = 1
        };

        // Act
        var command = new UpdateAlimentoCommand(alimentoInputModel);


        // Assert
        Assert.NotNull(command.AlimentoInput);
        Assert.Equal("Maçã", command.AlimentoInput.Nome);
        Assert.Equal(1, command.AlimentoInput.GrupoAlimentarId);
        Assert.Equal(1, command.AlimentoInput.InformacaoNutricionalId);

    }
}
