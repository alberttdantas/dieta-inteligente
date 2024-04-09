
using DietaInteligente.Application.InputModels;

namespace DietaInteligente.Tests.Application.DTOs.InputModel;

public class UsuarioInputModelTests
{
    [Fact]
    public void UsuarioInputModel_ValidData_ShouldPassValidation()
    {
        // Arrange
        var inputModel = new UsuarioInputModel
        {
            Nome = "Nome",
            Email = "Email",
            Peso = 100,
            Altura = 100,
            Objetivo = Domain.Enums.Objetivos.ganhar_massa
        };


        // Act
        var nome = inputModel.Nome;
        var email = inputModel.Email;
        var peso = inputModel.Peso;
        var altura = inputModel.Altura;
        var objetivo = inputModel.Objetivo;


        // Assert
        Assert.Equal("Nome", nome);
        Assert.Equal("Email", email);
        Assert.Equal(100, peso);
        Assert.Equal(100, altura);
        Assert.Equal(Domain.Enums.Objetivos.ganhar_massa, objetivo);

    }
}
