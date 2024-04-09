
using DietaInteligente.Application.InputModels;

namespace DietaInteligente.Tests.Application.DTOs.InputModel;

public class InformacaoNutricionalInputModelTests
{
    [Fact]
    public void InformacaoNutricionalInputModel_ValidData_ShouldPassValidation()
    {
        // Arrange
        var inputModel = new InformacaoNutricionalInputModel
        {
            AlimentoId = 1,
            Calorias = 100,
            Proteinas = 100,
            Gorduras = 100,
            Carboidratos = 100,
            Fibras = 100
        };


        // Act
        var alimentoId = inputModel.AlimentoId;
        var calorias = inputModel.Calorias;
        var proteinas = inputModel.Proteinas;
        var gorduras = inputModel.Gorduras;
        var carboidratos = inputModel.Carboidratos;
        var fibras = inputModel.Fibras;


        // Assert
        Assert.Equal(1, alimentoId);
        Assert.Equal(100, calorias);
        Assert.Equal(100, proteinas);
        Assert.Equal(100, gorduras);
        Assert.Equal(100, carboidratos);
        Assert.Equal(100, fibras);
    }
}
