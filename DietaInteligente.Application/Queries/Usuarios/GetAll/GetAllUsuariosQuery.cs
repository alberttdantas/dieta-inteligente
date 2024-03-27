
using DietaInteligente.Application.ViewModels;
using MediatR;

namespace DietaInteligente.Application.Queries.Usuarios.GetAll;

public class GetAllUsuariosQuery : IRequest<IEnumerable<UsuarioViewModel>>
{
    public GetAllUsuariosQuery()
    {
        
    }
}
