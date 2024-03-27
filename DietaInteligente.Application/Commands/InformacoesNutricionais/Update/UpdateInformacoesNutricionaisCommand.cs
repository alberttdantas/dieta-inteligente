
using DietaInteligente.Application.InputModels;
using MediatR;

namespace DietaInteligente.Application.Commands.InformacoesNutricionais.Update;

public class UpdateInformacoesNutricionaisCommand : IRequest<CommandResult>
{
    public UpdateInformacoesNutricionaisCommand(InformacaoNutricionalInputModel? informacaoNutricionalInput)
    {
        InformacaoNutricionalInput = informacaoNutricionalInput;
    }

    public InformacaoNutricionalInputModel? InformacaoNutricionalInput { get; set; }
}
