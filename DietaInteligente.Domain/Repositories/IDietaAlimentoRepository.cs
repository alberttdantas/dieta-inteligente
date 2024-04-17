
using DietaInteligente.Domain.Entities;

namespace DietaInteligente.Domain.Repositories;

public interface IDietaAlimentoRepository
{
    Task<IEnumerable<DietaAlimento>> BuscarDietasAlimentosAsync();
    Task<IEnumerable<DietaAlimento>> BuscarAlimentosPorDietaAsync (int id);
    Task<bool> AssociarDietaAlimentoAsync(DietaAlimento dietaAlimento);
    Task<bool> DesassociarDietaAlimentoAsync(DietaAlimento dietaAlimento);
}
