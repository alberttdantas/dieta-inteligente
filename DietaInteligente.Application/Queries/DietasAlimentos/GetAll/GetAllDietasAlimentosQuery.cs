
using DietaInteligente.Application.ViewModels;
using MediatR;

namespace DietaInteligente.Application.Queries.DietasAlimentos.GetAll;

public class GetAllDietasAlimentosQuery : IRequest<IEnumerable<DietaAlimentoViewModel>>
{
    public GetAllDietasAlimentosQuery()
    {
        
    }
}
