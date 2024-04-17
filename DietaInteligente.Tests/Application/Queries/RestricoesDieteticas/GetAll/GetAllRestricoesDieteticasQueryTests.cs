
using DietaInteligente.Application.Queries.RestricoesDieteticas.GetAll;

namespace DietaInteligente.Tests.Application.Queries.RestricoesDieteticas.GetAll;

public class GetAllRestricoesDieteticasQueryTests
{
    [Fact]
    public void GetAllRestricoesDieteticasQuery_CanBeCreated()
    {
        // Act
        var query = new GetAllRestricoesDieteticasQuery();

        // Assert
        Assert.NotNull(query);

    }
}
