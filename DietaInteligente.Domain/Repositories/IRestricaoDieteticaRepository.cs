
using DietaInteligente.Domain.Entities;

namespace DietaInteligente.Domain.Repositories;

public interface IRestricaoDieteticaRepository
{
    Task<RestricoesDieteticas> BuscarRestricoesDieteticas();
    Task<RestricoesDieteticas> BuscarRestricaoDietetica(int usuarioId);
    Task<bool> AssociarRestricaoDieteticaAsync(int usuarioId, int grupoAlimentarId);
    Task<bool> DesassociarRestricaoDieteticaAsync(int usuarioId, int grupoAlimentarId);
    Task DeleterRestricaoDietetica(int usuarioId);
}
