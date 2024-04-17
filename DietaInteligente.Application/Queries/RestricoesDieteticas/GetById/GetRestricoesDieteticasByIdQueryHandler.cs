
using AutoMapper;
using DietaInteligente.Application.ViewModels;
using DietaInteligente.Domain.Repositories;
using MediatR;

namespace DietaInteligente.Application.Queries.RestricoesDieteticas.GetById;

public class GetRestricoesDieteticasByIdQueryHandler : IRequestHandler<GetRestricoesDieteticasByIdQuery, RestricaoDieteticaViewModel>
{
    private readonly IMapper _mapper;
    private readonly IRestricaoDieteticaRepository _restricaoDieteticaRepository;

    public GetRestricoesDieteticasByIdQueryHandler(IMapper mapper, IRestricaoDieteticaRepository restricaoDieteticaRepository)
    {
        _mapper = mapper;
        _restricaoDieteticaRepository = restricaoDieteticaRepository;
    }

    public async Task<RestricaoDieteticaViewModel> Handle(GetRestricoesDieteticasByIdQuery request, CancellationToken cancellationToken)
    {
        var restricaoDietetica = await _restricaoDieteticaRepository.BuscarRestricaoDieteticaAsync(request.UsuarioId);
        return _mapper.Map<RestricaoDieteticaViewModel>(restricaoDietetica);
    }
}
