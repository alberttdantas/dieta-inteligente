
using AutoMapper;
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Repositories;
using MediatR;

namespace DietaInteligente.Application.Commands.Usuarios.Create;

public class CreateUsuarioCommandHandler : IRequestHandler<CreateUsuarioCommand, CommandResult>
{
    private readonly IMapper _mapper;
    private readonly IUsuarioRepository _usuarioRepository;

    public CreateUsuarioCommandHandler(IMapper mapper, IUsuarioRepository usuarioRepository)
    {
        _mapper = mapper;
        _usuarioRepository = usuarioRepository;
    }

    public async Task<CommandResult> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
    {
        var usuario = _mapper.Map<Usuario>(request.UsuarioInput);
        var success = await _usuarioRepository.CriarUsuarioAsync(usuario);

        if (success)
        {
            return CommandResult.SuccessResult("Sucesso ao criar usuario!");
        }
        return CommandResult.FailureResult(new[] { "Falha ao criar usuario!" });
    }
}
