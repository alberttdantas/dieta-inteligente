
using AutoMapper;
using DietaInteligente.Application.ViewModels;
using DietaInteligente.Domain.Repositories;
using MediatR;

namespace DietaInteligente.Application.Queries.DietasAlimentos.GetById;

public class GetDietaAlimentoByIdQueryHandler : IRequestHandler<GetDietaAlimentoByIdQuery,DietaAlimentoViewModel>
{
    private readonly IMapper _mapper;
    private readonly IDietaAlimentoRepository _dietaAlimentoRepository;

    public GetDietaAlimentoByIdQueryHandler(IMapper _mapper, IDietaAlimentoRepository dietaAlimentoRepository)
    {
        _mapper = _mapper;
        _dietaAlimentoRepository = dietaAlimentoRepository;
    }

    public async Task<DietaAlimentoViewModel> Handle(GetDietaAlimentoByIdQuery request, CancellationToken cancellationToken)
    {
        var dietaAlimento = await _dietaAlimentoRepository.BuscarDietaAlimentoAsync(request.DietaId);
        return _mapper.Map<DietaAlimentoViewModel>(dietaAlimento);
    }
}
