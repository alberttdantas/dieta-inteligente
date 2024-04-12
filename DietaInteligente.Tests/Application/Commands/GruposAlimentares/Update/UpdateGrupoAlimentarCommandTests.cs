
using DietaInteligente.Application.Commands.GruposAlimentares.Update;
using DietaInteligente.Application.InputModels;

namespace DietaInteligente.Tests.Application.Commands.GruposAlimentares.Update;

public class UpdateGrupoAlimentarCommandTests
{
    [Fact]
    public void UpdateGruposAlimentaresCommand_ConstructedWithValidData_ShouldCreateCorrectObject()
    {
        // Arrange
        var grupoAlimentarInputModel = new GrupoAlimentarInputModel
        {
            Nome = "Nome"
        };


        // Act
        var commad = new UpdateGrupoAlimentarCommand(grupoAlimentarInputModel);


        // Assert
        Assert.NotNull(commad.GrupoAlimentarInput);
        Assert.Equal("Nome", commad.GrupoAlimentarInput.Nome);

    }
}
