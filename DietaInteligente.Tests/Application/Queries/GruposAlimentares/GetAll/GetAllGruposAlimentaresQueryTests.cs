
using DietaInteligente.Application.Queries.GruposAlimentares.GetAll;

namespace DietaInteligente.Tests.Application.Queries.GruposAlimentares.GetAll;

public class GetAllGruposAlimentaresQueryTests
{
    [Fact]
    public void GetAllGruposAlimentaresQuery_CanBeCreated()
    {
        // Act
        var query = new GetAllGruposAlimentaresQuery();

        // Assert
        Assert.NotNull(query);
    }
}
