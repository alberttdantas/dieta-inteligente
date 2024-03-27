
using DietaInteligente.Domain.Repositories;
using MediatR;

namespace DietaInteligente.Application.Commands.InformacoesNutricionais.Delete;

public class DeleteInformacoesNutricionaisCommandHandler : IRequestHandler<DeleteInformacoesNutricionaisCommand, CommandResult>
{
    private readonly IInformacaoNutricionalRepository _informacaoNutricionalRepository;

    public DeleteInformacoesNutricionaisCommandHandler(IInformacaoNutricionalRepository informacaoNutricionalRepository)
    {
        _informacaoNutricionalRepository = informacaoNutricionalRepository;
    }

    public async Task<CommandResult> Handle(DeleteInformacoesNutricionaisCommand request, CancellationToken cancellationToken)
    {
        var informacaoNutricional = await _informacaoNutricionalRepository.BuscarInformacaoNutricionalAsync(request.Id);
        var success = await _informacaoNutricionalRepository.DeletarInformacaoNutricional(informacaoNutricional);
        
        if (success)
        {
            return CommandResult.SuccessResult("Sucesso ao deletar Informações nutricionais");
        }
        return CommandResult.FailureResult(new[] { "Falha ao deletar informações nutricionais "});
    }
}
