
using DietaInteligente.Application.ViewModels;
using DietaInteligente.Domain.Enums;

namespace DietaInteligente.Tests.Application.DTOs.ViewModel;

public class DietaAlimentoViewModelTests
{
    [Fact]
    public void DietaAlimentoViewModel_ValidData_ShouldPassValidation()
    {
        // Arrange
        var usuarioViewModel = new UsuarioViewModel
        {
            Id = 1,
            Nome = "Usuário Teste",
            Email = "usuario@teste.com",
            Peso = 70m,
            Altura = 1.75m,
            Objetivo = Objetivos.ganhar_massa
        };

        var dietaViewModel = new DietaViewModel
        {
            Id = 1,
            Data = new DateTime(2024, 4, 4),
            UsuarioId = 1
        };

        var grupoAlimentarViewModel = new GrupoAlimentarViewModel
        {
            Id = 1,
            Nome = "Frutas"
        };

        var alimentoViewModel = new AlimentoViewModel
        {
            Id = 2,
            Nome = "Maçã",
            GrupoAlimentar = grupoAlimentarViewModel,
            InformacoesNutricionais = new InformacaoNutricionalViewModel { AlimentoId = 2, Calorias = 52 }
        };

        var dietaAlimentoViewModel = new DietaAlimentoViewModel
        {
            DietaId = dietaViewModel.Id,
            Alimentos = new List<AlimentoViewModel> { alimentoViewModel },
            QuantidadedeGramas = 150m
        };

        // Act
        var dietaId = dietaAlimentoViewModel.DietaId;
        var quantidadeGramas = dietaAlimentoViewModel.QuantidadedeGramas;

        // Assert
        Assert.Equal(1, dietaId);
        Assert.Equal(150m, quantidadeGramas);

    }
}
