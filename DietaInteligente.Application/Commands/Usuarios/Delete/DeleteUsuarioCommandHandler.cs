
using DietaInteligente.Domain.Repositories;
using MediatR;

namespace DietaInteligente.Application.Commands.Usuarios.Delete;

public class DeleteUsuarioCommandHandler : IRequestHandler<DeleteUsuarioCommand, CommandResult>
{
    private readonly IUsuarioRepository _usuarioRepository;

    public DeleteUsuarioCommandHandler(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<CommandResult> Handle(DeleteUsuarioCommand request, CancellationToken cancellationToken)
    {
        var usuario = await _usuarioRepository.BuscarUsuarioAsync(request.Id);
        var success = await _usuarioRepository.DeletarUsuarioAsync(usuario);

        if (success)
        {
            return CommandResult.SuccessResult("Sucesso ao deletar usuario");
        }
        return CommandResult.FailureResult(new[] { "Falha ao deletar usuario" });

    }
}
