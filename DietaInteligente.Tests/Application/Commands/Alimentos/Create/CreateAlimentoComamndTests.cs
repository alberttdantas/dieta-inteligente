using DietaInteligente.Application.Commands.Alimentos.Create;
using DietaInteligente.Application.InputModels;

namespace DietaInteligente.Tests.Application.Commands.Alimentos.Create;

public class CreateAlimentoComamndTests
{
    [Fact]
    public void CreateAlimentoCommand_ConstructedWithValidData_ShouldCreateCorrectObject()
    {
        // Arrange
        var inputModel = new AlimentoInputModel
        {
            Nome = "Maçã",
            GrupoAlimentarId = 1,
            InformacaoNutricionalId = 1
        };

        // Act
        var command = new CreateAlimentoCommand(inputModel);

        // Assert
        Assert.NotNull(command.AlimentoInput);
        Assert.Equal("Maçã", command.AlimentoInput.Nome);
        Assert.Equal(1, command.AlimentoInput.GrupoAlimentarId);
        Assert.Equal(1, command.AlimentoInput.InformacaoNutricionalId);
    }
}
