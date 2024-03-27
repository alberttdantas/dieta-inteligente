
using AutoMapper;
using DietaInteligente.Application.ViewModels;
using DietaInteligente.Domain.Repositories;
using MediatR;

namespace DietaInteligente.Application.Queries.RestricoesDieteticas.GetAll;

public class GetAllRestricoesDieteticasQueryHandler : IRequestHandler<GetAllRestricoesDieteticasQuery, IEnumerable<RestricaoDieteticaViewModel>>
{
    private readonly IMapper _mapper;
    private readonly IRestricaoDieteticaRepository _restricoesDieteticaRepository;

    public GetAllRestricoesDieteticasQueryHandler(IMapper mapper, IRestricaoDieteticaRepository restricaoDieteticaRepository)
    {
        _mapper = mapper;
        _restricoesDieteticaRepository = restricaoDieteticaRepository;
    }

    public async Task<IEnumerable<RestricaoDieteticaViewModel>> Handle(GetAllRestricoesDieteticasQuery request, CancellationToken cancellationToken)
    {
        var restricoesDieteticas = await _restricoesDieteticaRepository.BuscarRestricoesDieteticas();
        return _mapper.Map<IEnumerable<RestricaoDieteticaViewModel>>(restricoesDieteticas);
    }
}
