
using DietaInteligente.Application.ViewModels;
using MediatR;

namespace DietaInteligente.Application.Queries.GruposAlimentares.GetById;

public class GetGrupoAlimentarByIdQuery : IRequest<GrupoAlimentarViewModel>
{
    public int Id { get; set; }
    public GetGrupoAlimentarByIdQuery(int id) { Id = id; }
}