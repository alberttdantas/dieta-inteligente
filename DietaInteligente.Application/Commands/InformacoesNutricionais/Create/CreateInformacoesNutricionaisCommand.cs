
using DietaInteligente.Application.InputModels;
using MediatR;

namespace DietaInteligente.Application.Commands.InformacoesNutricionais.Create;

public class CreateInformacoesNutricionaisCommand : IRequest<CommandResult>
{
    public CreateInformacoesNutricionaisCommand(InformacaoNutricionalInputModel? informacaoNutricionalInput)
    {
        InformacaoNutricionalInput = informacaoNutricionalInput;
    }

    public InformacaoNutricionalInputModel? InformacaoNutricionalInput { get; set; }
}
