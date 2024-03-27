
using AutoMapper;
using DietaInteligente.Application.ViewModels;
using DietaInteligente.Domain.Repositories;
using MediatR;

namespace DietaInteligente.Application.Queries.GruposAlimentares.GetById;

public class GetGrupoAlimentarByIdQueryHandler : IRequestHandler<GetGrupoAlimentarByIdQuery, GrupoAlimentarViewModel>
{
    private readonly IMapper _mapper;
    private readonly IGrupoAlimentarRepository _grupoAlimentarRepository;

    public GetGrupoAlimentarByIdQueryHandler(IMapper mapper, IGrupoAlimentarRepository grupoAlimentarRepository)
    {
        _mapper = mapper;
        _grupoAlimentarRepository = grupoAlimentarRepository;
    }

    public async Task<GrupoAlimentarViewModel> Handle(GetGrupoAlimentarByIdQuery request, CancellationToken cancellationToken)
    {
        var grupoAlimentar = await _grupoAlimentarRepository.BuscarGrupoAlimentarAsync(request.Id);
        return _mapper.Map<GrupoAlimentarViewModel>(grupoAlimentar);
    }
}