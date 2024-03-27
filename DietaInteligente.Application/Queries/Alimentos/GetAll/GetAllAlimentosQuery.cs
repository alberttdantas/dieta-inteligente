
using DietaInteligente.Application.ViewModels;
using MediatR;

namespace DietaInteligente.Application.Queries.Alimentos.GetAll;

public class GetAllAlimentosQuery : IRequest<IEnumerable<AlimentoViewModel>>
{
    public GetAllAlimentosQuery()
    {
        
    }
}