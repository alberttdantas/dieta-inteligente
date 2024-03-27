
using DietaInteligente.Application.Commands.DietasAlimentos.Disassociate;
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Repositories;
using MediatR;

namespace DietaInteligente.Application.Commands.RestricoesDieteticas.Disassociate;

public class DisassociateRestricaoDieteticaCommandHandler : IRequestHandler<DisassociateRestricaoDieteticaCommand, CommandResult>
{
    private readonly IRestricaoDieteticaRepository _restricaoDieteticaRepository;

    public DisassociateRestricaoDieteticaCommandHandler(IRestricaoDieteticaRepository restricaoDieteticaRepository)
    {
        _restricaoDieteticaRepository = restricaoDieteticaRepository;
    }

    public async Task<CommandResult> Handle(DisassociateRestricaoDieteticaCommand request, CancellationToken cancellationToken)
    {
        var restricaoDietetica = new RestricaoDietetica(request.UsuarioId, request.GrupoAlimentarId);
        var success = await _restricaoDieteticaRepository.DesassociarRestricaoDieteticaAsync(restricaoDietetica);

        if (success)
        {
            return CommandResult.SuccessResult("Sucesso ao desassociar uma restricao de uma dieta");
        }
        return CommandResult.FailureResult(new[] { "Falha ao desassociar uma restricao de uma dieta" });
    }
}
