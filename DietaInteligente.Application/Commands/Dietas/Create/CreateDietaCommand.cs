
using DietaInteligente.Application.InputModels;
using MediatR;

namespace DietaInteligente.Application.Commands.Dietas.Create;

public class CreateDietaCommand : IRequest<CommandResult>
{
    public CreateDietaCommand(DietaInputModel? dietaInput)
    {
        DietaInput = dietaInput;
    }

    public DietaInputModel? DietaInput { get; set; }
}
