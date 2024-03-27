
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Repositories;
using MediatR;

namespace DietaInteligente.Application.Commands.DietasAlimentos.Disassociate;

public class DisassociateDietaAlimentoCommandHandler : IRequestHandler<DisassociateDietaAlimentoCommand, CommandResult>
{
    private readonly IDietaAlimentoRepository _dietaAlimentoRepository;

    public DisassociateDietaAlimentoCommandHandler(IDietaAlimentoRepository dietaAlimentoRepository)
    {
        _dietaAlimentoRepository = dietaAlimentoRepository;
    }

    public async Task<CommandResult> Handle(DisassociateDietaAlimentoCommand request, CancellationToken cancellationToken)
    {
        var dietaAlimento = new DietaAlimento(request.DietaId, request.AlimentoId);
        var success = await _dietaAlimentoRepository.DesassociarDietaAlimentoAsync(dietaAlimento);

        if (success)
        {
            return CommandResult.SuccessResult("Sucesso ao desassociar dieta de alimento");
        }
        return CommandResult.FailureResult(new[] { "Falha ao desassociar dieta de alimento" });
    }
}
