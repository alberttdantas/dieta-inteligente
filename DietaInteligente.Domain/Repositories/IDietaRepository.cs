
using DietaInteligente.Domain.Entities;

namespace DietaInteligente.Domain.Repositories;

public interface IDietaRepository
{
    Task<IEnumerable<Dieta>> BuscarDietasAsync();
    Task<Dieta> BuscarDietaAsync(int id);
    Task<bool> CriarDietaAsync(Dieta dieta);
    Task<bool> AtualizarDietaAsync(Dieta dieta);
    Task<bool> DeletarDietaAsync(Dieta dieta);
}
