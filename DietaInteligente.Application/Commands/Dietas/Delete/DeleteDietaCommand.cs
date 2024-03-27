
using MediatR;

namespace DietaInteligente.Application.Commands.Dietas.Delete;

public class DeleteDietaCommand : IRequest<CommandResult>
{
    public DeleteDietaCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
