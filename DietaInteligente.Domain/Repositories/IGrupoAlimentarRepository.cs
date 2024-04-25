
using DietaInteligente.Domain.Entities;

namespace DietaInteligente.Domain.Repositories;

public interface IGrupoAlimentarRepository
{
    Task<IEnumerable<GrupoAlimentar>> BuscarGruposAlimentarAsync();
    Task<GrupoAlimentar> BuscarGrupoAlimentarAsync(int? id);
    Task<bool> CriarGrupoAlimentarAsync(GrupoAlimentar grupoAlimentar);
    Task<bool> AtualizarGrupoAlimentarAsync(GrupoAlimentar grupoAlimentar);
    Task<bool> DeletarGrupoAlimentarAsync(GrupoAlimentar grupoAlimentar);
}
