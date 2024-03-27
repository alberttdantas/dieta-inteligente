
using AutoMapper;
using DietaInteligente.Application.ViewModels;
using DietaInteligente.Domain.Repositories;
using MediatR;

namespace DietaInteligente.Application.Queries.GruposAlimentares.GetAll;

public class GetAllGruposAlimentaresQueryHandler : IRequestHandler<GetAllGruposAlimentaresQuery, IEnumerable<GrupoAlimentarViewModel>>
{
    private readonly IMapper _mapper;
    private readonly IGrupoAlimentarRepository _grupoAlimentarRepository;

    public GetAllGruposAlimentaresQueryHandler(IMapper mapper, IGrupoAlimentarRepository grupoAlimentarRepository)
    {
        _mapper = mapper;
        _grupoAlimentarRepository = grupoAlimentarRepository;
    }

    async Task<IEnumerable<GrupoAlimentarViewModel>> IRequestHandler<GetAllGruposAlimentaresQuery, IEnumerable<GrupoAlimentarViewModel>>.Handle(GetAllGruposAlimentaresQuery request, CancellationToken cancellationToken)
    {
        var grupoAlimentar = await _grupoAlimentarRepository.BuscarGruposAlimentarAsync();
        return _mapper.Map<IEnumerable<GrupoAlimentarViewModel>>(grupoAlimentar);
    }
}