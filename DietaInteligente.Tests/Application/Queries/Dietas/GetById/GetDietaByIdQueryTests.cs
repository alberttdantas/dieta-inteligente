
using DietaInteligente.Application.Queries.Dietas.GetById;

namespace DietaInteligente.Tests.Application.Queries.Dietas.GetById;

public class GetDietaByIdQueryTests
{
    [Fact]
    public void GetDietaByIdQuery_CorrectlyStoresId()
    {
        // Arrange
        var dietaId = 1;
        var query = new GetDietaByIdQuery(dietaId);

        // Act
        var resultId = query.Id;

        // Assert
        Assert.Equal(dietaId, resultId);
    }
}
