
using MediatR;

namespace DietaInteligente.Application.Commands.DietasAlimentos.Associate;

public class AssociateDietaAlimentoCommand : IRequest<CommandResult>
{
    public AssociateDietaAlimentoCommand(int dietaId, int alimentoId, decimal quantidadeGramas)
    {
        QuantidadeGramas = quantidadeGramas;
        DietaId = dietaId;
        AlimentoId = alimentoId;
    }

    public decimal QuantidadeGramas { get; set; }
    public int DietaId { get; set; }
    public int AlimentoId { get; set; }
}
