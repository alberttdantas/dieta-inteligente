
using DietaInteligente.Application.Queries.Alimentos.GetById;

namespace DietaInteligente.Tests.Application.Queries.Alimentos.GetById;

public class GetAlimentoByIdQueryTests
{
    [Fact]
    public void GetAlimentoByIdQuery_CorrectlyStoresId()
    {
        // Arrange
        var alimentoId = 1;
        var query = new GetAlimentoByIdQuery(alimentoId);

        // Act
        var resultId = query.Id;

        // Assert
        Assert.Equal(alimentoId, resultId);
    }
}
