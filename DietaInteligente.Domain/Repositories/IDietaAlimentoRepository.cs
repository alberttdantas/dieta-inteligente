
using DietaInteligente.Domain.Entities;

namespace DietaInteligente.Domain.Repositories;

public interface IDietaAlimentoRepository
{
    Task<IEnumerable<Dieta>> BuscarDietasAlimentosAsync();
    Task<Dieta> BuscarDietaAlimentoAsync(int id);
    Task<bool> AssociarDietaAlimentoAsync(DietaAlimento dietaAlimento);
    Task<bool> DesassociarDietaAlimentoAsync(DietaAlimento dietaAlimento);
}
