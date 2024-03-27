
using DietaInteligente.Application.InputModels;
using MediatR;

namespace DietaInteligente.Application.Commands.Alimentos.Create;
public class CreateAlimentoCommand : IRequest<CommandResult>
{
    public CreateAlimentoCommand(AlimentoInputModel alimentoInput)
    {
        AlimentoInput = alimentoInput;
    }

    public AlimentoInputModel AlimentoInput { get; set; }
}