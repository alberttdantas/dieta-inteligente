
using DietaInteligente.Application.Queries.Alimentos.GetById;

namespace DietaInteligente.Tests.Application.Queries.DietasAlimentos.GetById;

public class GetDietaAlimentoByIdQueryTests
{
    [Fact]
    public void GetDietaAlimentoByIdQuery_CorrectlyStoresId()
    {
        // Arrange
        var dietaId = 1;
        var query = new GetAlimentoByIdQuery(dietaId);

        // Act
        var resultId = query.Id;

        // Assert
        Assert.Equal(dietaId, resultId);

    }
}
