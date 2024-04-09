
using DietaInteligente.Application.InputModels;

namespace DietaInteligente.Tests.Application.DTOs.InputModel;

public class DietaAlimentoInputModelTests
{
    [Fact]
    public void DietaAlimentoInputModel_ValidData_ShouldPassValidation()
    {
        // Arrange
        var inputModel = new DietaAlimentoInputModel
        {
            DietaId = 1,
            AlimentoId = 2,
            QuantidadeGramas = 100m
        };


        // Act
        var dietaId = inputModel.DietaId;
        var alimentoId = inputModel.AlimentoId;
        var quantidadeGramas = inputModel.QuantidadeGramas;


        // Assert
        Assert.Equal(1, dietaId);
        Assert.Equal(2, alimentoId);
        Assert.Equal(100m, quantidadeGramas);

    }
}
