
using DietaInteligente.Application.ViewModels;

namespace DietaInteligente.Tests.Application.DTOs.ViewModel;

public class InformacaoNutricionalViewModelTests
{
    [Fact]
    public void InformacaoNutricionalViewModel_ValidData_ShouldPassValidation()
    {
        var informacaoNutricionalViewModel = new InformacaoNutricionalViewModel
        {
            AlimentoId = 1,
            Calorias = 100m,
            Proteinas = 100m,
            Gorduras = 100m,
            Carboidratos = 100m,
            Fibras = 100m,
        };

        // Act
        var id = informacaoNutricionalViewModel.AlimentoId;
        var calorias = informacaoNutricionalViewModel.Calorias;
        var proteinas = informacaoNutricionalViewModel.Proteinas;
        var gorduras = informacaoNutricionalViewModel.Gorduras;
        var carboidratos = informacaoNutricionalViewModel.Carboidratos;
        var fibras = informacaoNutricionalViewModel.Fibras;

        // Assert
        Assert.Equal(1, id);
        Assert.Equal(100m, calorias);
        Assert.Equal(100m, proteinas);
        Assert.Equal(100m, gorduras);
        Assert.Equal(100m, carboidratos);
        Assert.Equal(100m, fibras);


    }
}
