
using DietaInteligente.Application.ViewModels;
using MediatR;

namespace DietaInteligente.Application.Queries.Dietas.GetAll;

public class GetAllDietaQuery : IRequest<IEnumerable<DietaViewModel>>
{
    public GetAllDietaQuery()
    {
        
    }
}