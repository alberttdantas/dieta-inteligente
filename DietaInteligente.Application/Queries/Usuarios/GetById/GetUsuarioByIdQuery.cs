
using DietaInteligente.Application.ViewModels;
using MediatR;

namespace DietaInteligente.Application.Queries.Usuarios.GetById;

public class GetUsuarioByIdQuery : IRequest<UsuarioViewModel>
{
    public int Id { get; set; }
    public GetUsuarioByIdQuery (int id) { Id = id; }
}
