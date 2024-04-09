
using AutoMapper;
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Repositories;
using MediatR;

namespace DietaInteligente.Application.Commands.GruposAlimentares.Update;

public class UpdateGrupoAlimentarCommandHandler : IRequestHandler<UpdateGrupoAlimentarCommand, CommandResult>
{
    private readonly IMapper _mapper;
    private readonly IGrupoAlimentarRepository _grupoAlimentarRepository;

    public UpdateGrupoAlimentarCommandHandler(IMapper mapper, IGrupoAlimentarRepository grupoAlimentarRepository)
    {
        _mapper = mapper;
        _grupoAlimentarRepository = grupoAlimentarRepository;
    }

    public async Task<CommandResult> Handle(UpdateGrupoAlimentarCommand request, CancellationToken cancellationToken)
    {
        var grupoAlimentar = _mapper.Map<GrupoAlimentar>(request.GrupoAlimentarInput);

        if (grupoAlimentar == null)
        {
            return CommandResult.FailureResult(new[] { "Grupo alimetar não encontrado!" });
        }

        var success = await _grupoAlimentarRepository.AtualizarGrupoAlimentarAsync(grupoAlimentar);

        if (success)
        {
            return CommandResult.SuccessResult("Sucesso ao atualizar grupo alimentar!");
        }

        return CommandResult.FailureResult(new[] { "Falha ao atualizar grupo alimentar!" });
    }
}
