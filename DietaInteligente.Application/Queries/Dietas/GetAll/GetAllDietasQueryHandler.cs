
using AutoMapper;
using DietaInteligente.Application.ViewModels;
using DietaInteligente.Domain.Repositories;
using MediatR;

namespace DietaInteligente.Application.Queries.Dietas.GetAll
{
    public class GetAllDietasQueryHandler : IRequestHandler<GetAllDietasQuery, IEnumerable<DietaViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IDietaRepository _dietaRepository;

        public GetAllDietasQueryHandler(IMapper mapper, IDietaRepository dietaRepository)
        {
            _mapper = mapper;
            _dietaRepository = dietaRepository;
        }

        public async Task<IEnumerable<DietaViewModel>> Handle(GetAllDietasQuery request, CancellationToken cancellationToken)
        {
            var dieta = await _dietaRepository.BuscarDietasAsync();
            return _mapper.Map<IEnumerable<DietaViewModel>>(dieta);
        }
    }
}
