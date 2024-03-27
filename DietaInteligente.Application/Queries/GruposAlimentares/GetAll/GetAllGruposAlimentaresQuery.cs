
using DietaInteligente.Application.ViewModels;
using MediatR;

namespace DietaInteligente.Application.Queries.GruposAlimentares.GetAll;

public class GetAllGruposAlimentaresQuery : IRequest<IEnumerable<GrupoAlimentarViewModel>>
{
    public GetAllGruposAlimentaresQuery()
    {
        
    }
}