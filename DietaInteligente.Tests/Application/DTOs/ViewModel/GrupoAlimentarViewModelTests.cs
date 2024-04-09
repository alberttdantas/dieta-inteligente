
using DietaInteligente.Application.ViewModels;

namespace DietaInteligente.Tests.Application.DTOs.ViewModel;

public class GrupoAlimentarViewModelTests
{
    [Fact]
    public void GrupoAlimentarViewModel_ValidData_ShouldPassValidation()
    {
        // Arrange
        var alimentosViewModel = new List<AlimentoViewModel>
        {
            new AlimentoViewModel{ Id = 1, Nome = "Arroz", GrupoAlimentarId = 1 },
            new AlimentoViewModel{ Id = 2, Nome = "Feijão", GrupoAlimentarId = 1 } ,
            new AlimentoViewModel{ Id = 3, Nome = "Trigo", GrupoAlimentarId = 1 },
        };

        var grupoAlimentarViewModel = new GrupoAlimentarViewModel
        {
            Id = 1,
            Nome = "Cereais",
            Alimentos = alimentosViewModel
        };


        // Act
        var id = grupoAlimentarViewModel.Id;
        var nome = grupoAlimentarViewModel.Nome;
        var alimentosCount = grupoAlimentarViewModel.Alimentos.Count();


        // Assert
        Assert.Equal(1, id);
        Assert.Equal("Cereais", nome);
        Assert.Equal(3, alimentosCount);
    }
}
