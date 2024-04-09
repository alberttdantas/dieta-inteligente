
using DietaInteligente.Application.InputModels;

namespace DietaInteligente.Tests.Application.DTOs.InputModel;

public class GrupoAlimentarInputModelTests
{
    [Fact]
    public void GrupoAlimentarInputModel_ValidData_ShouldPassValidation()
    {
        // Arrange
        var inputModel = new GrupoAlimentarInputModel
        {
            Nome = "Nome"
        };


        // Act
        var nome = inputModel.Nome;


        // Assert
        Assert.Equal("Nome", nome);

    }
}
