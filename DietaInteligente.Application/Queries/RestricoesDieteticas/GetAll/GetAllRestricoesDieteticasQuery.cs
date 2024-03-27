
using DietaInteligente.Application.ViewModels;
using MediatR;

namespace DietaInteligente.Application.Queries.RestricoesDieteticas.GetAll;

public class GetAllRestricoesDieteticasQuery : IRequest<IEnumerable<RestricaoDieteticaViewModel>>
{
    public GetAllRestricoesDieteticasQuery()
    {
        
    }
}
