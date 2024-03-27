
using AutoMapper;
using DietaInteligente.Application.ViewModels;
using DietaInteligente.Domain.Repositories;
using MediatR;

namespace DietaInteligente.Application.Queries.InformacoesNutricionais.GetById;

public class GetInformacaoNutricionalByIdQueryHandler : IRequestHandler<GetInformacaoNutricionalByIdQuery, InformacaoNutricionalViewModel>
{
    private readonly IMapper _mapper;
    private readonly IInformacaoNutricionalRepository _informacaoNutricionalRepository;

    public GetInformacaoNutricionalByIdQueryHandler(IMapper mapper, IInformacaoNutricionalRepository informacaoNutricionalRepository)
    {
        _mapper = mapper;
        _informacaoNutricionalRepository = informacaoNutricionalRepository;
    }

    public async Task<InformacaoNutricionalViewModel> Handle(GetInformacaoNutricionalByIdQuery request, CancellationToken cancellationToken)
    {
        var informacaoNutricional = await _informacaoNutricionalRepository.BuscarInformacaoNutricionalAsync(request.AlimentoId);
        return _mapper.Map<InformacaoNutricionalViewModel>(informacaoNutricional);
    }
}
