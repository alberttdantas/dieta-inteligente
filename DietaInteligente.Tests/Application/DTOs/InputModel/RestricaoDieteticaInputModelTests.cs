
using DietaInteligente.Application.InputModels;

namespace DietaInteligente.Tests.Application.DTOs.InputModel;

public class RestricaoDieteticaInputModelTests
{
    [Fact]
    public void RestricaoDieteticaInputModel_ValidData_ShouldPassValidation()
    {
        // Arrange
        var inputModel = new RestricaoDieteticaInputModel
        {
            UsuarioId = 1,
            GrupoAlimentarId = 1
        };


        // Act
        var usuarioId = inputModel.UsuarioId;
        var grupoAlimentarId = inputModel.GrupoAlimentarId;


        // Assert
        Assert.Equal(1, usuarioId);
        Assert.Equal(1, grupoAlimentarId);

    }
}
