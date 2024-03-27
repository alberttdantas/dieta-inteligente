
using DietaInteligente.Application.ViewModels;
using MediatR;

namespace DietaInteligente.Application.Queries.InformacoesNutricionais.GetById;

public class GetInformacaoNutricionalByIdQuery : IRequest<InformacaoNutricionalViewModel>
{
    public int AlimentoId { get; set; }
    public GetInformacaoNutricionalByIdQuery (int alimentoId) { AlimentoId = alimentoId; }
}
