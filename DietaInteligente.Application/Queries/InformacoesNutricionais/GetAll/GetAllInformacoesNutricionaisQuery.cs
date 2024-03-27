
using DietaInteligente.Application.ViewModels;
using MediatR;

namespace DietaInteligente.Application.Queries.InformacoesNutricionais.GetAll;

public class GetAllInformacoesNutricionaisQuery : IRequest<IEnumerable<InformacaoNutricionalViewModel>>
{
    public GetAllInformacoesNutricionaisQuery()
    {
        
    }
}
