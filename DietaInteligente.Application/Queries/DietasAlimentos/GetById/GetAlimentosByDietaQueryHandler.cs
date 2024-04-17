using AutoMapper;
using DietaInteligente.Application.ViewModels;
using DietaInteligente.Domain.Repositories;
using MediatR;

namespace DietaInteligente.Application.Queries.DietasAlimentos.GetById
{
    public class GetAlimentosByDietaQueryHandler : IRequestHandler<GetDietaAlimentoByIdQuery, IEnumerable<DietaAlimentoViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IDietaAlimentoRepository _dietaAlimentoRepository;

        public GetAlimentosByDietaQueryHandler(IMapper mapper, IDietaAlimentoRepository dietaAlimentoRepository)
        {
            _mapper = mapper;
            _dietaAlimentoRepository = dietaAlimentoRepository;
        }

        public async Task<IEnumerable<DietaAlimentoViewModel>> Handle(GetDietaAlimentoByIdQuery request, CancellationToken cancellationToken)
        {
            var dietaAlimentos = await _dietaAlimentoRepository.BuscarAlimentosPorDietaAsync(request.DietaId);
            var dietaAlimentoViewModels = dietaAlimentos.Select(da => new DietaAlimentoViewModel
            {
                DietaId = da.DietaId,
                Alimentos = new List<AlimentoViewModel>
                {
                    _mapper.Map<AlimentoViewModel>(da.Alimentos)
                },
                QuantidadedeGramas = da.QuantidadeGramas
            }).ToList();

            return dietaAlimentoViewModels;
        }
    }
}
