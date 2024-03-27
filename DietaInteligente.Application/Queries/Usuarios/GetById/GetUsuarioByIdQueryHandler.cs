
using AutoMapper;
using DietaInteligente.Application.ViewModels;
using DietaInteligente.Domain.Repositories;
using MediatR;

namespace DietaInteligente.Application.Queries.Usuarios.GetById;

public class GetUsuarioByIdQueryHandler : IRequestHandler<GetUsuarioByIdQuery, UsuarioViewModel>
{
    private readonly IMapper _mapper;
    private readonly IUsuarioRepository _usuarioRepository;

    public GetUsuarioByIdQueryHandler(IMapper mapper, IUsuarioRepository usuarioRepository)
    {
        _mapper = mapper;
        _usuarioRepository = usuarioRepository;
    }

    public async Task<UsuarioViewModel> Handle(GetUsuarioByIdQuery request, CancellationToken cancellationToken)
    {
        var usuario = await _usuarioRepository.BuscarUsuariosAsync();
        return _mapper.Map<UsuarioViewModel>(usuario);
    }
}
