
using DietaInteligente.Application.InputModels;
using MediatR;

namespace DietaInteligente.Application.Commands.Dietas.Update;

public class UpdateDietaCommand : IRequest<CommandResult>
{
    public UpdateDietaCommand(DietaInputModel? dietaInput)
    {
        DietaInput = dietaInput;
    }

    public DietaInputModel? DietaInput { get; set; }
}
