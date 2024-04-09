
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

        

        var usuarioViewModel = new UsuarioViewModel
        {
            Altura = 100m,
            Email = "email",
            Nome = "Nome",
            Peso = 100
        };

        var restricaoDietetica = new RestricaoDieteticaViewModel
        {
            UsuarioId = 1,
            Usuarios = usuarioViewModel,
            GruposAlimentares = gruposAlimentaresViewModel
        };


        // Act
        var usuarioId = restricaoDietetica.UsuarioId;
        var usuarios = restricaoDietetica.Usuarios;
        var gruposAlimentares = restricaoDietetica.GruposAlimentares.Count();


        // Assert
        Assert.Equal(1, usuarioId);
        Assert.Equal(2, gruposAlimentares);
        Assert.Equal(100m, usuarios.Altura);
        Assert.Equal("email", usuarios.Email);
        Assert.Equal("Nome", usuarios.Nome);
        Assert.Equal(100, usuarios.Peso);
    }
}
