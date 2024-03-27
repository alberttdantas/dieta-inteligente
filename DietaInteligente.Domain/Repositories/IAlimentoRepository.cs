using DietaInteligente.Domain.Entities;

namespace DietaInteligente.Domain.Repositories;

public interface IAlimentoRepository
{
    Task<IEnumerable<Alimento>> BuscarAlimentosAsync();
    Task<Alimento> BuscarAlimentoAsync (int? id);
    Task<bool> InserirAlimentoAsync (Alimento alimento);
    Task<bool> DeletarAlimentoAsync (Alimento alimento);
    Task<bool> AtualizarAlimento(Alimento alimento);
}
