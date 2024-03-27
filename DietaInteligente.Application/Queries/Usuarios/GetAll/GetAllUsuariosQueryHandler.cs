
using AutoMapper;
using DietaInteligente.Application.ViewModels;
using DietaInteligente.Domain.Repositories;
using MediatR;

namespace DietaInteligente.Application.Queries.Usuarios.GetAll;

public class GetAllUsuariosQueryHandler : IRequestHandler<GetAllUsuariosQuery, IEnumerable<UsuarioViewModel>>
{
    private readonly IMapper _mapper;
    private readonly IUsuarioRepository _usuarioRepository;

    public GetAllUsuariosQueryHandler(IMapper mapper, IUsuarioRepository usuarioRepository)
    {
        _mapper = mapper;
        _usuarioRepository = usuarioRepository;
    }

    public async Task<IEnumerable<UsuarioViewModel>> Handle(GetAllUsuariosQuery request, CancellationToken cancellationToken)
    {
        var usuario = await _usuarioRepository.BuscarUsuariosAsync();
        return _mapper.Map<IEnumerable<UsuarioViewModel>>(usuario);
    }
}
