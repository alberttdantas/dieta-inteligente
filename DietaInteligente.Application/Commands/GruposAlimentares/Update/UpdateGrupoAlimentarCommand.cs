
using DietaInteligente.Application.InputModels;
using MediatR;

namespace DietaInteligente.Application.Commands.GruposAlimentares.Update;

public class UpdateGrupoAlimentarCommand : IRequest<CommandResult>
{
    public UpdateGrupoAlimentarCommand(GrupoAlimentarInputModel? grupoAlimentarInput)
    {
        GrupoAlimentarInput = grupoAlimentarInput;
    }

    public GrupoAlimentarInputModel? GrupoAlimentarInput { get; set; }
}
