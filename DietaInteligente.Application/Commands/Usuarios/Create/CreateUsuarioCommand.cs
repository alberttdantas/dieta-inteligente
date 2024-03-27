
using DietaInteligente.Application.InputModels;
using MediatR;

namespace DietaInteligente.Application.Commands.Usuarios.Create;

public class CreateUsuarioCommand : IRequest<CommandResult>
{
    public CreateUsuarioCommand(UsuarioInputModel usuarioInput)
    {
        UsuarioInput = usuarioInput;
    }

    public UsuarioInputModel UsuarioInput { get; set; }
}
