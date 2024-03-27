
using DietaInteligente.Application.ViewModels;
using MediatR;

namespace DietaInteligente.Application.Queries.RestricoesDieteticas.GetById;

public class GetRestricoesDieteticasByIdQuery : IRequest<RestricaoDieteticaViewModel>
{
    public int UsuarioId { get; set; }
    public GetRestricoesDieteticasByIdQuery(int usuarioId) { UsuarioId = usuarioId; }
}
