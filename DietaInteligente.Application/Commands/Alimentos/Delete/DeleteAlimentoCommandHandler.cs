
using DietaInteligente.Domain.Repositories;
using MediatR;

namespace DietaInteligente.Application.Commands.Alimentos.Delete;

public class DeleteAlimentoCommandHandler : IRequestHandler<DeleteAlimentoCommand, CommandResult>
{
    private readonly IAlimentoRepository _alimentoRepository;

    public DeleteAlimentoCommandHandler(IAlimentoRepository alimentoRepository)
    {
        _alimentoRepository = alimentoRepository;
    }

    public async Task<CommandResult> Handle(DeleteAlimentoCommand request, CancellationToken cancellationToken)
    {
        var alimento = await _alimentoRepository.BuscarAlimentoAsync(request.Id);
        var success = await _alimentoRepository.DeletarAlimentoAsync(alimento);

        if (success)
        {
            return CommandResult.SuccessResult("Alimento deletado com sucesso");
        }

        return CommandResult.FailureResult(new[] { "Falha ao deletar o alimento" });
    }
}
