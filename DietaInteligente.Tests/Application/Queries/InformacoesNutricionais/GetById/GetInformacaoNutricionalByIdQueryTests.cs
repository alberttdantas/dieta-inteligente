
using DietaInteligente.Application.Queries.InformacoesNutricionais.GetById;

namespace DietaInteligente.Tests.Application.Queries.InformacoesNutricionais.GetById;

public class GetInformacaoNutricionalByIdQueryTests
{
    [Fact]
    public void GetInformacaoNutricionalByIdQuery_CorrectlyStoresId()
    {
        // Arrange
        var informacaoNutricionalId = 1;
        var query = new GetInformacaoNutricionalByIdQuery(informacaoNutricionalId);

        // Act
        var resultId = query.AlimentoId;

        // Assert
        Assert.Equal(informacaoNutricionalId, resultId);

    }
}
