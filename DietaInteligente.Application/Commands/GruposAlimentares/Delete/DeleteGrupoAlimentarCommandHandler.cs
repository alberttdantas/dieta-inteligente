
using AutoMapper;
using DietaInteligente.Domain.Repositories;
using MediatR;

namespace DietaInteligente.Application.Commands.GruposAlimentares.Delete;

public class DeleteGrupoAlimentarCommandHandler : IRequestHandler<DeleteGrupoAlimentarCommand, CommandResult>
{
    private readonly IMapper _mapper;
    private readonly IGrupoAlimentarRepository _grupoAlimentarRepository;

    public DeleteGrupoAlimentarCommandHandler(IMapper mapper, IGrupoAlimentarRepository grupoAlimentarRepository)
    {
        _mapper = mapper;
        _grupoAlimentarRepository = grupoAlimentarRepository;
    }

    public async Task<CommandResult> Handle(DeleteGrupoAlimentarCommand request, CancellationToken cancellationToken)
    {
        var grupoAlimentar = await _grupoAlimentarRepository.BuscarGrupoAlimentarAsync(request.Id);

        if (grupoAlimentar == null)
        {
            return CommandResult.FailureResult(new[] { "Grupo alimentar não encontrada!" });
        }

        var success = await _grupoAlimentarRepository.DeletarGrupoAlimentarAsync(grupoAlimentar);

        if (success)
        {
            return CommandResult.SuccessResult("Grupo alimentar deletado com sucesso");
        }

        return CommandResult.FailureResult(new[] { "Falha ao deletar grupo alimentar!" });
    }
}
