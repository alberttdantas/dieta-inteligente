
using AutoMapper;
using DietaInteligente.Application.ViewModels;
using DietaInteligente.Domain.Repositories;
using MediatR;

namespace DietaInteligente.Application.Queries.InformacoesNutricionais.GetAll;

public class GetAllInformacoesNutricionaisQueryHandler : IRequestHandler<GetAllInformacoesNutricionaisQuery, IEnumerable<InformacaoNutricionalViewModel>>
{
    private readonly IMapper _mapper;
    private readonly IInformacaoNutricionalRepository _informacaoNutricionalRepository;

    public GetAllInformacoesNutricionaisQueryHandler(IMapper mapper, IInformacaoNutricionalRepository informacaoNutricionalRepository)
    {
        _mapper = mapper;
        _informacaoNutricionalRepository = informacaoNutricionalRepository;
    }

    public async Task<IEnumerable<InformacaoNutricionalViewModel>> Handle(GetAllInformacoesNutricionaisQuery request, CancellationToken cancellationToken)
    {
        var informacoesNutricionais = await _informacaoNutricionalRepository.BuscarInformacoesNutricionaisAsync();
        return _mapper.Map<IEnumerable<InformacaoNutricionalViewModel>>(informacoesNutricionais);
    }
}