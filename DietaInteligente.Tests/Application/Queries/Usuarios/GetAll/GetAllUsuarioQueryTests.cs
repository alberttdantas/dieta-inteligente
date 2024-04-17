
using DietaInteligente.Application.Queries.Usuarios.GetAll;

namespace DietaInteligente.Tests.Application.Queries.Usuarios.GetAll;

public class GetAllUsuarioQueryTests
{
    [Fact]
    public void GetAllUsuariosQuery_CanBeCreated()
    {
        // Act
        var query = new GetAllUsuariosQuery();

        // Assert
        Assert.NotNull(query);
    }
}
