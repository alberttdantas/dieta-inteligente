
using MediatR;

namespace DietaInteligente.Application.Commands.GruposAlimentares.Delete;

public class DeleteGrupoAlimentarCommand : IRequest<CommandResult>
{
    public DeleteGrupoAlimentarCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
