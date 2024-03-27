
using MediatR;

namespace DietaInteligente.Application.Commands.RestricoesDieteticas.Disassociate;

public class DisassociateRestricaoDieteticaCommand : IRequest<CommandResult>
{
    public DisassociateRestricaoDieteticaCommand(int usuarioId, int grupoAlimentarId)
    {
        UsuarioId = usuarioId;
        GrupoAlimentarId = grupoAlimentarId;
    }

    public int UsuarioId { get; set; }
    public int GrupoAlimentarId { get; set; }
}
