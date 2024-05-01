
using DietaInteligente.Application.ViewModels;

namespace DietaInteligente.Tests.Application.DTOs.ViewModel;

public class AlimentoViewModelTests
{
    [Fact]
    public void AlimentoViewModel_ValidData_ShouldPassValidation()
    {
        // Arrange
        var viewModel = new AlimentoViewModel
        {
            Id = 1,
            Nome = "Maçã",
            InformacoesNutricionais = new InformacaoNutricionalViewModel { AlimentoId = 1, Calorias = 52 }
        };


        // Act
        var id = viewModel.Id;
        var nome = viewModel.Nome;
        var calorias = viewModel.InformacoesNutricionais.Calorias;

        // Assert
        Assert.Equal(1, id);
        Assert.Equal("Maçã", nome);
        Assert.Equal(52, calorias);

    }
}
