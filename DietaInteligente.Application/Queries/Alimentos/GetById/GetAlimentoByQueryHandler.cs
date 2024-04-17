
using AutoMapper;
using DietaInteligente.Application.ViewModels;
using DietaInteligente.Domain.Repositories;
using MediatR;

namespace DietaInteligente.Application.Queries.Alimentos.GetById;

public class GetAlimentoByQueryHandler : IRequestHandler<GetAlimentoByIdQuery, AlimentoViewModel>
{
    private readonly IMapper _mapper;
    private readonly IAlimentoRepository _alimentoRepository;

    public GetAlimentoByQueryHandler(IMapper mapper, IAlimentoRepository alimentoRepository)
    {
        _mapper = mapper;
        _alimentoRepository = alimentoRepository;
    }

    public async Task<AlimentoViewModel> Handle(GetAlimentoByIdQuery request, CancellationToken cancellationToken)
    {
        var alimento = await _alimentoRepository.BuscarAlimentoAsync(request.Id);
        return _mapper.Map<AlimentoViewModel>(alimento);
    }
}
