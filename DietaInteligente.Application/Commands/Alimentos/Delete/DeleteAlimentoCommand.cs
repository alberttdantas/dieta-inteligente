
using MediatR;

namespace DietaInteligente.Application.Commands.Alimentos.Delete;

public class DeleteAlimentoCommand : IRequest<CommandResult>
{
    public DeleteAlimentoCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
