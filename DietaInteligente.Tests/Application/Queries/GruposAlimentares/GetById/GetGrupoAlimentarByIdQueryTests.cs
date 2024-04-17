
using DietaInteligente.Application.Queries.GruposAlimentares.GetById;

namespace DietaInteligente.Tests.Application.Queries.GruposAlimentares.GetById;

public class GetGrupoAlimentarByIdQueryTests
{
    [Fact]
    public void GetGrupoAlimentarByIdQuery_CorrectlyStoresId()
    {
        // Arrange
        var grupoAlimentarId = 1;
        var query = new GetGrupoAlimentarByIdQuery(grupoAlimentarId);

        // Act
        var resultId = query.Id;

        // Assert
        Assert.Equal(grupoAlimentarId, resultId);

    }
}
