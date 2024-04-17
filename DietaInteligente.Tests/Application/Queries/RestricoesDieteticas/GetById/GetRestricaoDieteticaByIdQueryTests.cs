
using DietaInteligente.Application.Queries.Alimentos.GetById;

namespace DietaInteligente.Tests.Application.Queries.RestricoesDieteticas.GetById;

public class GetRestricaoDieteticaByIdQueryTests
{
    [Fact]
    public void GetRestricaoDieteticaByIdQuery_CorrectlyStoresId()
    {
        // Arrange
        var restricaoDieteticaId = 1;
        var query = new GetAlimentoByIdQuery(restricaoDieteticaId);

        // Act
        var result = query.Id;

        // Assert
        Assert.Equal(restricaoDieteticaId, result);

    }
}
