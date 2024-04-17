
//using AutoMapper;
//using DietaInteligente.Application.ViewModels;
//using DietaInteligente.Domain.Repositories;
//using MediatR;

//namespace DietaInteligente.Application.Queries.DietasAlimentos.GetById;

//public class GetDietaAlimentoByIdQueryHandler : IRequestHandler<GetDietaAlimentoByIdQuery, IEnumerable<DietaAlimentoViewModel>>
//{
//    private readonly IMapper _mapper;
//    private readonly IDietaAlimentoRepository _dietaAlimentoRepository;

//    public GetDietaAlimentoByIdQueryHandler(IMapper _mapper, IDietaAlimentoRepository dietaAlimentoRepository)
//    {
//        _mapper = _mapper;
//        _dietaAlimentoRepository = dietaAlimentoRepository;
//    }

//    public async Task<IEnumerable<DietaAlimentoViewModel>> Handle(GetDietaAlimentoByIdQuery request, CancellationToken cancellationToken)
//    {
//        var dietaAlimentos = await _dietaAlimentoRepository.BuscarAlimentosPorDietaAsync(request.DietaId);
//        return _mapper.Map<IEnumerable<DietaAlimentoViewModel>>(dietaAlimentos);
//    }
//}
