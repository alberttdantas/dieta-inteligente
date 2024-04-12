
using AutoMapper;
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Repositories;
using MediatR;

namespace DietaInteligente.Application.Commands.InformacoesNutricionais.Delete;

public class DeleteInformacoesNutricionaisCommandHandler : IRequestHandler<DeleteInformacoesNutricionaisCommand, CommandResult>
{
    private readonly IMapper _mapper;
    private readonly IInformacaoNutricionalRepository _informacaoNutricionalRepository;

    public DeleteInformacoesNutricionaisCommandHandler(IMapper mapper, IInformacaoNutricionalRepository informacaoNutricionalRepository)
    {
        _mapper = mapper;
        _informacaoNutricionalRepository = informacaoNutricionalRepository;
    }

    public async Task<CommandResult> Handle(DeleteInformacoesNutricionaisCommand request, CancellationToken cancellationToken)
    {
        var informacaoNutricional = await _informacaoNutricionalRepository.BuscarInformacaoNutricionalAsync(request.Id);

        if (informacaoNutricional == null)
        {
            return CommandResult.FailureResult(new[] { "Informação nutricional não encontrada!" });
        }

        var success = await _informacaoNutricionalRepository.DeletarInformacaoNutricionalAsync(informacaoNutricional);
        
        if (success)
        {
            return CommandResult.SuccessResult("Sucesso ao deletar informação nutricional!");
        }
        return CommandResult.FailureResult(new[] { "Falha ao deletar informação nutricional!"});
    }
}
