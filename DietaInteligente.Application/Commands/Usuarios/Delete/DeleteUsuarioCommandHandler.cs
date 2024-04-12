
using AutoMapper;
using DietaInteligente.Domain.Repositories;
using MediatR;

namespace DietaInteligente.Application.Commands.Usuarios.Delete;

public class DeleteUsuarioCommandHandler : IRequestHandler<DeleteUsuarioCommand, CommandResult>
{
    private readonly IMapper _mapper;
    private readonly IUsuarioRepository _usuarioRepository;

    public DeleteUsuarioCommandHandler(IMapper mapper, IUsuarioRepository usuarioRepository)
    {
        _mapper = mapper;
        _usuarioRepository = usuarioRepository;
    }

    public async Task<CommandResult> Handle(DeleteUsuarioCommand request, CancellationToken cancellationToken)
    {
        var usuario = await _usuarioRepository.BuscarUsuarioAsync(request.Id);

        if (usuario == null)
        {
            return CommandResult.FailureResult(new[] { "Usuario não encontrado!" });
        }

        var success = await _usuarioRepository.DeletarUsuarioAsync(usuario);

        if (success)
        {
            return CommandResult.SuccessResult("Sucesso ao deletar usuario!");
        }
        return CommandResult.FailureResult(new[] { "Falha ao deletar usuario!" });

    }
}
