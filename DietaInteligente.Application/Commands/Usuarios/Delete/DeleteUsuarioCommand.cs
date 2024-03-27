
using MediatR;

namespace DietaInteligente.Application.Commands.Usuarios.Delete;

public class DeleteUsuarioCommand : IRequest<CommandResult>
{
    public DeleteUsuarioCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
