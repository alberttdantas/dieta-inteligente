
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Repositories;
using DietaInteligente.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DietaInteligente.Infrastructure.Repositories.RestricoesDieteticas;

public class RestricaoDieteticaRepository : IRestricaoDieteticaRepository
{
    private readonly DietaInteligenteDbContext _dbContext;

    public RestricaoDieteticaRepository(DietaInteligenteDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> AssociarRestricaoDieteticaAsync(RestricaoDietetica restricaoDietetica)
    {
        if (restricaoDietetica == null)
        {
            throw new ArgumentNullException(nameof(restricaoDietetica));
        }

        try
        {
            _dbContext.Set<RestricaoDietetica>().Add(restricaoDietetica);
            return await _dbContext.SaveChangesAsync() > 0;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<IEnumerable<RestricaoDietetica>> BuscarRestricaoDieteticaAsync(int usuarioId)
    {
        return await _dbContext.Set<RestricaoDietetica>().Where(rd => rd.UsuarioId == usuarioId).ToListAsync();
    }

    public async Task<IEnumerable<RestricaoDietetica>> BuscarRestricoesDieteticasAsync()
    {
        return await _dbContext.Set<RestricaoDietetica>().ToListAsync();
    }

    public async Task<bool> DesassociarRestricaoDieteticaAsync(RestricaoDietetica restricaoDietetica)
    {
        if (restricaoDietetica == null)
        {
            throw new ArgumentNullException(nameof(restricaoDietetica));
        }

        try
        {
            var existingAssociation = await _dbContext.Set<RestricaoDietetica>()
                .FirstOrDefaultAsync(rd => rd.UsuarioId == restricaoDietetica.UsuarioId && rd.GrupoAlimentarId == restricaoDietetica.GrupoAlimentarId);

            if (existingAssociation != null)
            {
                _dbContext.Set<RestricaoDietetica>().Remove(existingAssociation);
                return await _dbContext.SaveChangesAsync() > 0;
            }
            return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
