
using DietaInteligente.Application.ViewModels;

namespace DietaInteligente.Tests.Application.DTOs.ViewModel;

public class DietaViewModelTests
{
    [Fact]
    public void DietaViewModel_ValidData_ShouldPassValidation()
    {
        // Arrange
        var dietaAlimentoViewModel = new List<DietaAlimentoViewModel>
        {
            new DietaAlimentoViewModel
            {
                QuantidadeGramas = 100m
            },
            new DietaAlimentoViewModel
            {
                QuantidadeGramas = 100m
            },
            new DietaAlimentoViewModel
            {
                QuantidadeGramas = 100m
            }
        };

        var dietaViewModel = new DietaViewModel
        {
            Id = 1,
            Data = new DateTime(2024, 4, 4),
            UsuarioId = 1,
            DietasAlimentos = dietaAlimentoViewModel
        };


        // Act
        var id = dietaViewModel.Id;
        var data = dietaViewModel.Data;
        var usuarioId = dietaViewModel.UsuarioId;
        var quantidadeDeAlimentos = dietaViewModel.DietasAlimentos.Count();


        // Assert
        Assert.Equal(1, id);
        Assert.Equal(new DateTime(2024, 4, 4), data);
        Assert.Equal(1, usuarioId);
        Assert.Equal(3, quantidadeDeAlimentos);

    }
}
