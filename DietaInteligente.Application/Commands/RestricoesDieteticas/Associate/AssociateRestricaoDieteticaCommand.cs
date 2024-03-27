
using MediatR;

namespace DietaInteligente.Application.Commands.RestricoesDieteticas.Associate;

public class AssociateRestricaoDieteticaCommand : IRequest<CommandResult>
{
    public AssociateRestricaoDieteticaCommand(int usuarioId, int grupoAlimentarId)
    {
        UsuarioId = usuarioId;
        GrupoAlimentarId = grupoAlimentarId;
    }

    public int UsuarioId { get; set; }
    public int GrupoAlimentarId { get; set; }
}
