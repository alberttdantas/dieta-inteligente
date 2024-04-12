
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Repositories;
using MediatR;

namespace DietaInteligente.Application.Commands.RestricoesDieteticas.Associate;

public class AssociateRestricaoDieteticaCommandHandler : IRequestHandler<AssociateRestricaoDieteticaCommand, CommandResult>
{
    private readonly IRestricaoDieteticaRepository _restricaoDieteticaRepository;

    public AssociateRestricaoDieteticaCommandHandler(IRestricaoDieteticaRepository restricaoDieteticaRepository)
    {
        _restricaoDieteticaRepository = restricaoDieteticaRepository;
    }

    public async Task<CommandResult> Handle(AssociateRestricaoDieteticaCommand request, CancellationToken cancellationToken)
    {
        var restricaoDietetica = new RestricaoDietetica(request.UsuarioId, request.GrupoAlimentarId);
        var success = await _restricaoDieteticaRepository.AssociarRestricaoDieteticaAsync(restricaoDietetica);

        if (success)
        {
            return CommandResult.SuccessResult("Sucesso ao associar uma restrição a uma dieta!");
        }
        return CommandResult.FailureResult(new[] { "Falha ao associar uma restrição a uma dieta!" });
    }
}
