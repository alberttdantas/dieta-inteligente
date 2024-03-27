
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
        var success = await _informacaoNutricionalRepository.AtualizarInformacaoNutricional(informacaoNutricional);

        if (success)
        {
            return CommandResult.SuccessResult("Sucesso ao atualizar informações nutricionais");
        }
        return CommandResult.FailureResult(new[] { "Falha ao atualizar informações nutricionais" });
    }
}
