
using MediatR;

namespace DietaInteligente.Application.Commands.DietasAlimentos.Disassociate;

public class DisassociateDietaAlimentoCommand : IRequest<CommandResult>
{
    public DisassociateDietaAlimentoCommand(int dietaId, int alimentoId)
    {
        DietaId = dietaId;
        AlimentoId = alimentoId;
    }

    public int DietaId { get; set; }
    public int AlimentoId { get; set; }
}
