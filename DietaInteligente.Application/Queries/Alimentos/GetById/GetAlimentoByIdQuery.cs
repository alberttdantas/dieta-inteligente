
using DietaInteligente.Application.ViewModels;
using MediatR;

namespace DietaInteligente.Application.Queries.Alimentos.GetById;

public class GetAlimentoByIdQuery : IRequest<AlimentoViewModel>
{
    public int Id { get; set; }
    public GetAlimentoByIdQuery(int id) { Id = id; }
}
