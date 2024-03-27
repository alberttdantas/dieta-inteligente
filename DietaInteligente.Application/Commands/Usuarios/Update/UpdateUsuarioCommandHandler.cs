
using AutoMapper;
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Repositories;
using MediatR;

namespace DietaInteligente.Application.Commands.Usuarios.Update;

public class UpdateUsuarioCommandHandler : IRequestHandler<UpdateUsuarioCommand, CommandResult>
{
    private readonly IMapper _mapper;
    private readonly IUsuarioRepository _usuarioRepository;

    public UpdateUsuarioCommandHandler(IMapper mapper, IUsuarioRepository usuarioRepository)
    {
        _mapper = mapper;
        _usuarioRepository = usuarioRepository;
    }

    public async Task<CommandResult> Handle(UpdateUsuarioCommand request, CancellationToken cancellationToken)
    {
        var usuario = _mapper.Map<Usuario>(request.UsuarioInput);
        var success = await _usuarioRepository.AtualizarUsuarioAsync(usuario);

        if (success)
        {
            return CommandResult.SuccessResult("Sucesso ao atualizar dados do usuario");
        }
        return CommandResult.FailureResult(new[] { "Falha ao atualizar dados do usuario" });
    }
}
