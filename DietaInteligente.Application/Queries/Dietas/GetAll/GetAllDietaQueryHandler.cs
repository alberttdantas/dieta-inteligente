
using AutoMapper;
using DietaInteligente.Application.ViewModels;
using DietaInteligente.Domain.Repositories;
using MediatR;

namespace DietaInteligente.Application.Queries.Dietas.GetAll
{
    public class GetAllDietaQueryHandler : IRequestHandler<GetAllDietaQuery, IEnumerable<DietaViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IDietaRepository _dietaRepository;

        public GetAllDietaQueryHandler(IMapper mapper, IDietaRepository dietaRepository)
        {
            _mapper = mapper;
            _dietaRepository = dietaRepository;
        }

        public async Task<IEnumerable<DietaViewModel>> Handle(GetAllDietaQuery request, CancellationToken cancellationToken)
        {
            var dieta = await _dietaRepository.BuscarDietasAsync();
            return _mapper.Map<IEnumerable<DietaViewModel>>(dieta);
        }
    }
}
