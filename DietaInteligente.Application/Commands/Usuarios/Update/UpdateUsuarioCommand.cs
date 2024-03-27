
using DietaInteligente.Application.InputModels;
using MediatR;

namespace DietaInteligente.Application.Commands.Usuarios.Update;

public class UpdateUsuarioCommand : IRequest<CommandResult>
{
    public UpdateUsuarioCommand(UsuarioInputModel? usuarioInput)
    {
        UsuarioInput = usuarioInput;
    }

    public UsuarioInputModel? UsuarioInput { get; set; }
}
