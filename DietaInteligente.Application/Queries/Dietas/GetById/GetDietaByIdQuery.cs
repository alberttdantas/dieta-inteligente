
using DietaInteligente.Application.ViewModels;
using MediatR;

namespace DietaInteligente.Application.Queries.Dietas.GetById
{
    public class GetDietaByIdQuery : IRequest<DietaViewModel>
    {
        public int Id { get; set; }
        public GetDietaByIdQuery (int id) { Id = id; }
    }
}
