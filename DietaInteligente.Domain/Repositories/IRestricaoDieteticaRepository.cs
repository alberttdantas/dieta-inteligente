
using DietaInteligente.Domain.Entities;

namespace DietaInteligente.Domain.Repositories;

public interface IRestricaoDieteticaRepository
{
    Task<IEnumerable<RestricaoDietetica>> BuscarRestricoesDieteticasAsync();
    Task<IEnumerable<RestricaoDietetica>> BuscarRestricaoDieteticaAsync(int usuarioId);
    Task<bool> AssociarRestricaoDieteticaAsync(RestricaoDietetica restricaoDietetica);
    Task<bool> DesassociarRestricaoDieteticaAsync(RestricaoDietetica restricaoDietetica);
}
