
using DietaInteligente.Application.Queries.InformacoesNutricionais.GetAll;

namespace DietaInteligente.Tests.Application.Queries.InformacoesNutricionais.GetAll;

public class GetAllInformacoesNutricionaisQueryTests
{
    [Fact]
    public void GetAllAlimentosQuery_CanBeCreated()
    {
        // Act
        var query = new GetAllInformacoesNutricionaisQuery();

        // Assert
        Assert.NotNull(query);

    }
}
