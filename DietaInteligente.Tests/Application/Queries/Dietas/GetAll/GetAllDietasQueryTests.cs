
using DietaInteligente.Application.Queries.Dietas.GetAll;

namespace DietaInteligente.Tests.Application.Queries.Dietas.GetAll;

public class GetAllDietasQueryTests
{
    [Fact]
    public void GetAllDietasQuery_CanBeCreated()
    {
        // Act
        var query = new GetAllDietasQuery();


        // Assert
        Assert.NotNull(query);
    }
}
