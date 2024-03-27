
using AutoMapper;
using DietaInteligente.Application.ViewModels;
using DietaInteligente.Domain.Repositories;
using MediatR;

namespace DietaInteligente.Application.Queries.Alimentos.GetAll;

public class GetAllAlimentosQueryHandler : IRequestHandler<GetAllAlimentosQuery, IEnumerable<AlimentoViewModel>>
{
    private readonly IMapper _mapper;
    private readonly IAlimentoRepository _alimentoRepository;

    public GetAllAlimentosQueryHandler(IAlimentoRepository alimentoRepository, IMapper mapper)
    {
        _mapper = mapper;
        _alimentoRepository = alimentoRepository;
    }

    public async Task<IEnumerable<AlimentoViewModel>> Handle(GetAllAlimentosQuery request, CancellationToken cancellationToken)
    {
        var alimentos = await _alimentoRepository.BuscarAlimentosAsync();
        return _mapper.Map<IEnumerable<AlimentoViewModel>>(alimentos);
    }
}