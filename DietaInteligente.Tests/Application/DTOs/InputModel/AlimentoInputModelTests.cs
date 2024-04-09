
using DietaInteligente.Application.InputModels;

namespace DietaInteligente.Tests.Application.DTOs.InputModel;

public class AlimentoInputModelTests
{
    [Fact]
    public void AlimentoInputModel_ValidData_ShouldPassValidation()
    {
        // Arrange
        var inputModel = new AlimentoInputModel
        {
            Nome = "Maçã",
            GrupoAlimentarId = 1,
            InformacaoNutricionalId = 1,
        };

        // Act
        var nome = inputModel.Nome;
        var grupoAlimentarId = inputModel.GrupoAlimentarId;
        var informacaoNutricionalId = inputModel.InformacaoNutricionalId;

        // Assert
        Assert.Equal("Maçã", nome);
        Assert.Equal(1, grupoAlimentarId);
        Assert.Equal(1, informacaoNutricionalId);
    }
}
