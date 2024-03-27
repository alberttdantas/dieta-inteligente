
using DietaInteligente.Application.InputModels;
using MediatR;

namespace DietaInteligente.Application.Commands.Alimentos.Update;

public class UpdateAlimentoCommand : IRequest<CommandResult>
{
    public UpdateAlimentoCommand(AlimentoInputModel alimentoInput)
    {
        AlimentoInput = alimentoInput;
    }

    public AlimentoInputModel? AlimentoInput { get; set; }
}
