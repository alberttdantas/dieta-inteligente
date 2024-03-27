
using DietaInteligente.Domain.Entities;

namespace DietaInteligente.Domain.Repositories;

public interface IRestricaoDieteticaRepository
{
    Task<RestricaoDietetica> BuscarRestricoesDieteticas();
    Task<RestricaoDietetica> BuscarRestricaoDietetica(int usuarioId);
    Task<bool> AssociarRestricaoDieteticaAsync(RestricaoDietetica restricaoDietetica);
    Task<bool> DesassociarRestricaoDieteticaAsync(RestricaoDietetica restricaoDietetica);
}
