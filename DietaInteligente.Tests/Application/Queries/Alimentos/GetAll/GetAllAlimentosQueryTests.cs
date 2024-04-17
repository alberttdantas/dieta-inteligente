
using DietaInteligente.Application.Queries.Alimentos.GetAll;

namespace DietaInteligente.Tests.Application.Queries.Alimentos.GetAll;

public class GetAllAlimentosQueryTests
{
    [Fact]
    public void GetAllAlimentosQuery_CanBeCreated()
    {
        // Act
        var query = new GetAllAlimentosQuery();


        // Assert
        Assert.NotNull(query);
    }
}
