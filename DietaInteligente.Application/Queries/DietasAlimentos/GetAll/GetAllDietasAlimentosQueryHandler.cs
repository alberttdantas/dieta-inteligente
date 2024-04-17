
using AutoMapper;
using DietaInteligente.Application.ViewModels;
using DietaInteligente.Domain.Repositories;
using MediatR;

namespace DietaInteligente.Application.Queries.DietasAlimentos.GetAll;

public class GetAllDietasAlimentosQueryHandler : IRequestHandler<GetAllDietasAlimentosQuery, IEnumerable<DietaAlimentoViewModel>>
{
    private readonly IMapper _mapper;
    private readonly IDietaAlimentoRepository _dietaAlimentoRepository;

    public GetAllDietasAlimentosQueryHandler(IMapper mapper, IDietaAlimentoRepository dietaAlimentoRepository)
    {
        _mapper = mapper;
        _dietaAlimentoRepository = dietaAlimentoRepository;
    }

    public async Task<IEnumerable<DietaAlimentoViewModel>> Handle(GetAllDietasAlimentosQuery request, CancellationToken cancellationToken)
    {
        var dietaAlimento = await _dietaAlimentoRepository.BuscarDietasAlimentosAsync();
        return _mapper.Map<IEnumerable<DietaAlimentoViewModel>>(dietaAlimento);
    }
}
