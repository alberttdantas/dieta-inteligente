
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Repositories;
using MediatR;

namespace DietaInteligente.Application.Commands.DietasAlimentos.Associate;

public class AssociateDietaAlimentoCommandHandler : IRequestHandler<AssociateDietaAlimentoCommand, CommandResult>
{
    private readonly IDietaAlimentoRepository _dietaAlimentoRepository;

    public AssociateDietaAlimentoCommandHandler(IDietaAlimentoRepository dietaAlimentoRepository)
    {
        _dietaAlimentoRepository = dietaAlimentoRepository;
    }

    public async Task<CommandResult> Handle(AssociateDietaAlimentoCommand request, CancellationToken cancellationToken)
    {
        var dietaAlimento = new DietaAlimento(request.DietaId, request.AlimentoId, request.QuantidadeGramas);
        var success = await _dietaAlimentoRepository.AssociarDietaAlimentoAsync(dietaAlimento);
        
        if (success)
        {
            return CommandResult.SuccessResult("Sucesso ao relacionar dieta e alimento");
        }
        return CommandResult.FailureResult(new[] { "Falha ao relacionar dieta a alimento" });
    }
}
