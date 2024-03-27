
using DietaInteligente.Application.InputModels;
using MediatR;

namespace DietaInteligente.Application.Commands.Dietas.Update;

public class UpdateDietaCommand : IRequest<CommandResult>
{
    public UpdateDietaCommand(DietaInputModel? dietaAlimento)
    {
        DietaAlimento = dietaAlimento;
    }

    public DietaInputModel? DietaAlimento { get; set; }
}
