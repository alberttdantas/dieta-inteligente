
using DietaInteligente.Application.ViewModels;

namespace DietaInteligente.Tests.Application.DTOs.ViewModel;

public class UsuarioViewModelTests
{
    [Fact]
    public void UsuarioViewModel_ValidData_ShouldPassValidation()
    {
        // Arrange
        var dietaViewModel = new DietaViewModel
        {
            Data = new DateTime(2024, 4, 4),
            Id = 1,
            UsuarioId = 1
        };

        var restricaoDieteticaViewModel = new RestricaoDieteticaViewModel
        {
            UsuarioId = 1,
        };

        var usuarioViewModel = new UsuarioViewModel
        {
            Id = 1,
            Nome = "Nome",
            Email = "Email",
            Peso = 100,
            Altura = 190,
            Dietas = dietaViewModel,
            RestricaoDietetica = restricaoDieteticaViewModel,
            Objetivo = Domain.Enums.Objetivos.ganhar_massa
        };


        // Act
        var id = usuarioViewModel.Id;
        var nome = usuarioViewModel.Nome;
        var email = usuarioViewModel.Email;
        var peso = usuarioViewModel.Peso;
        var altura = usuarioViewModel.Altura;
        var dietaData = usuarioViewModel.Dietas.Data;
        var restricaoUsuarioId = usuarioViewModel.RestricaoDietetica.UsuarioId;
        var objetivo = usuarioViewModel.Objetivo;


        // Assert
        Assert.Equal(1, id);
        Assert.Equal("Nome", nome);
        Assert.Equal("Email", email);
        Assert.Equal(100, peso);
        Assert.Equal(190, altura);
        Assert.Equal(new DateTime(2024, 4, 4), dietaData);
        Assert.Equal(1, restricaoUsuarioId);
        Assert.Equal(Domain.Enums.Objetivos.ganhar_massa, objetivo);

    }
}
