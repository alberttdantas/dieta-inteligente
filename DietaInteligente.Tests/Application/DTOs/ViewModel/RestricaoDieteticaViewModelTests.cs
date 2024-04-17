
using DietaInteligente.Application.ViewModels;

namespace DietaInteligente.Tests.Application.DTOs.ViewModel;

public class RestricaoDieteticaViewModelTests
{
    [Fact]
    public void RestricaoDieteticaViewModel_ValidData_ShouldPassValidation()
    {
        // Arrange
        var gruposAlimentaresViewModel = new List<GrupoAlimentarViewModel>
        {
            new GrupoAlimentarViewModel{ Id = 1, Nome = "Cereais"},
            new GrupoAlimentarViewModel{Id = 2, Nome = "Carnes"}
        };

        var restricaoDietetica = new RestricaoDieteticaViewModel
        {
            UsuarioId = 1,
            GruposAlimentares = gruposAlimentaresViewModel
        };


        // Act
        var usuarioId = restricaoDietetica.UsuarioId;
        var gruposAlimentares = restricaoDietetica.GruposAlimentares.Count();


        // Assert
        Assert.Equal(1, usuarioId);
        Assert.Equal(2, gruposAlimentares);
    }
}
