
using AutoMapper;
using DietaInteligente.Application.ViewModels;
using DietaInteligente.Domain.Repositories;
using MediatR;

namespace DietaInteligente.Application.Queries.Dietas.GetById;

public class GetDietaByIdQueryHandler : IRequestHandler<GetDietaByIdQuery, DietaViewModel>
{
    private readonly IMapper _mapper;
    private readonly IDietaRepository _dietaRepository;

    public GetDietaByIdQueryHandler(IMapper mapper, IDietaRepository dietaRepository)
    {
        _mapper = mapper;
        _dietaRepository = dietaRepository;
    }

    public async Task<DietaViewModel> Handle(GetDietaByIdQuery request, CancellationToken cancellationToken)
    {
        var dieta = await _dietaRepository.BuscarDietaAsync(request.Id);
        return _mapper.Map<DietaViewModel>(dieta);
    }
}