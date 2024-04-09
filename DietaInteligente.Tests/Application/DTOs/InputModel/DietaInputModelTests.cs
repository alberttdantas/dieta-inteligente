
using DietaInteligente.Application.InputModels;

namespace DietaInteligente.Tests.Application.DTOs.InputModel;

public class DietaInputModelTests
{
    [Fact]
    public void DietaInputModel_ValidData_ShouldPassValidation()
    {
        // Arrange
        var inputModel = new DietaInputModel
        {
            Data = new DateTime(2024, 4, 4),
            UsuarioId = 1
        };


        // Act
        var data = inputModel.Data;
        var usuarioId = inputModel.UsuarioId;


        // Assert
        Assert.Equal(new DateTime(2024, 4, 4), data);
        Assert.Equal(1, usuarioId);

    }
}
