
using MediatR;

namespace DietaInteligente.Application.Commands.InformacoesNutricionais.Delete;

public class DeleteInformacoesNutricionaisCommand : IRequest<CommandResult>
{
    public DeleteInformacoesNutricionaisCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
