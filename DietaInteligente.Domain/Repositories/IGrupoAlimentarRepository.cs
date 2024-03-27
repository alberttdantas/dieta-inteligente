
using DietaInteligente.Domain.Entities;

namespace DietaInteligente.Domain.Repositories;

public interface IGrupoAlimentarRepository
{
    Task<IEnumerable<GruposAlimentares>> BuscarGruposAlimentarAsync();
    Task<GruposAlimentares> BuscarGrupoAlimentarAsync(int id);
    Task InserirGrupoAlimentarAsync(string nome);
    Task AtualizarGrupoAlimentarAsync(int ind);
    Task DeletarGrupoAlimentarAsync(int id);
}
