
using AutoMapper;
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Repositories;
using MediatR;

namespace DietaInteligente.Application.Commands.InformacoesNutricionais.Create;

public class CreateInformacoesNutricionaisCommandHandler : IRequestHandler<CreateInformacoesNutricionaisCommand, CommandResult>
{
    private readonly IMapper _mapper;
    private readonly IInformacaoNutricionalRepository _informacaoNutricionalRepository;

    public CreateInformacoesNutricionaisCommandHandler(IMapper mapper, IInformacaoNutricionalRepository informacaoNutricionalRepository)
    {
        _mapper = mapper;
        _informacaoNutricionalRepository = informacaoNutricionalRepository;
    }

    public async Task<CommandResult> Handle(CreateInformacoesNutricionaisCommand request, CancellationToken cancellationToken)
    {
        var informacaoNutricional = _mapper.Map<InformacaoNutricional>(request.InformacaoNutricionalInput);
        var success = await _informacaoNutricionalRepository.CriarInformacaoNutricional(informacaoNutricional);

        if (success)
        {
            return CommandResult.SuccessResult("Sucesso ao criar informação nutricional");
        }
        return CommandResult.FailureResult(new[] { "Falha ao criar informação nutricional" });
    }
}
