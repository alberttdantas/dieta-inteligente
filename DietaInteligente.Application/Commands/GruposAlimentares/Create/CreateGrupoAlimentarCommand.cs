
using DietaInteligente.Application.InputModels;
using MediatR;

namespace DietaInteligente.Application.Commands.GruposAlimentares.Create;

public class CreateGrupoAlimentarCommand : IRequest<CommandResult>
{
    public CreateGrupoAlimentarCommand(GrupoAlimentarInputModel? grupoAlimentarInput)
    {
        GrupoAlimentarInput = grupoAlimentarInput;
    }

    public GrupoAlimentarInputModel? GrupoAlimentarInput { get; set; }
}
