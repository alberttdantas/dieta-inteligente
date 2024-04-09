
using AutoMapper;
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Repositories;
using MediatR;

namespace DietaInteligente.Application.Commands.GruposAlimentares.Create;

public class CreateGrupoAlimentarCommandHandler : IRequestHandler<CreateGrupoAlimentarCommand, CommandResult>
{
    private readonly IMapper _mapper;
    private readonly IGrupoAlimentarRepository _grupoAlimentarRepository;

    public CreateGrupoAlimentarCommandHandler(IMapper mapper, IGrupoAlimentarRepository grupoAlimentarRepository)
    {
        _mapper = mapper;
        _grupoAlimentarRepository = grupoAlimentarRepository;
    }

    public async Task<CommandResult> Handle(CreateGrupoAlimentarCommand request, CancellationToken cancellationToken)
    {
        var grupoAlimentar = _mapper.Map<GrupoAlimentar>(request.GrupoAlimentarInput);
        var success = await _grupoAlimentarRepository.CriarGrupoAlimentarAsync(grupoAlimentar);

        if (success)
        {
            return CommandResult.SuccessResult("Grupo alimentar criado com sucesso!");
        }
        return CommandResult.FailureResult(new[] { "Falha ao criar grupo alimentar" });


    }
}
