
using DietaInteligente.Application.ViewModels;
using MediatR;

namespace DietaInteligente.Application.Queries.Dietas.GetAll;

public class GetAllDietasQuery : IRequest<IEnumerable<DietaViewModel>>
{
    public GetAllDietasQuery()
    {
        
    }
}