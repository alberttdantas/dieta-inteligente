
using AutoMapper;
using DietaInteligente.Application.InputModels;
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Repositories;
using MediatR;

namespace DietaInteligente.Application.Commands.InformacoesNutricionais.Update;

public class UpdateInformacoesNutricionaisCommandHandler : IRequestHandler<UpdateInformacoesNutricionaisCommand, CommandResult>
{
    private readonly IMapper _mapper;
    private readonly IInformacaoNutricionalRepository _informacaoNutricionalRepository;

    public UpdateInformacoesNutricionaisCommandHandler(IMapper mapper, IInformacaoNutricionalRepository informacaoNutricionalRepository)
    {
        _mapper = mapper;
        _informacaoNutricionalRepository = informacaoNutricionalRepository;
    }

    public async Task<CommandResult> Handle(UpdateInformacoesNutricionaisCommand request, CancellationToken cancellationToken)
    {
        var informacaoNutricional = _mapper.Map<InformacaoNutricional>(request.InformacaoNutricionalInput);

        if (informacaoNutricional == null)
        {
            return CommandResult.FailureResult(new[] { "Informação nutricional não encontrada!" });
        }

        var success = await _informacaoNutricionalRepository.AtualizarInformacaoNutricionalAsync(informacaoNutricional);

        if (success)
        {
            return CommandResult.SuccessResult("Sucesso ao atualizar informação nutricional!");
        }
        return CommandResult.FailureResult(new[] { "Falha ao atualizar informação nutricional!" });
    }
}
