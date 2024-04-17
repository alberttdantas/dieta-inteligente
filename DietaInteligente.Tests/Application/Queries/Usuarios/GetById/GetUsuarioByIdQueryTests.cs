
using DietaInteligente.Application.Queries.Usuarios.GetById;

namespace DietaInteligente.Tests.Application.Queries.Usuarios.GetById;

public class GetUsuarioByIdQueryTests
{
    [Fact]
    public void GetUsuarioByIdQuery_CorrectlyStoresId()
    {
        // Arrange
        var usuarioId = 1;
        var query = new GetUsuarioByIdQuery(usuarioId);

        // Act
        var resultId = query.Id;

        // Assert
        Assert.Equal(usuarioId, resultId);

    }
}
