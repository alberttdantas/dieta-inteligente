
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Repositories;
using DietaInteligente.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DietaInteligente.Infrastructure.Repositories.GruposAlimentares;

public class GrupoAlimentarRepository : IGrupoAlimentarRepository
{
    private readonly DietaInteligenteDbContext _dbContext;

    public GrupoAlimentarRepository(DietaInteligenteDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<GrupoAlimentar>> BuscarGruposAlimentarAsync()
    {
        return await _dbContext.Set<GrupoAlimentar>()
            .Include(g => g.Alimentos)
            .ToListAsync();
    }

    public async Task<GrupoAlimentar> BuscarGrupoAlimentarAsync(int? id)
    {
        if (id == null)
            throw new ArgumentNullException(nameof(id));

        return await _dbContext.GruposAlimentares
            .Include(g => g.Alimentos)
            .FirstOrDefaultAsync(g => g.Id == id);
    }

    public async Task<bool> CriarGrupoAlimentarAsync(GrupoAlimentar grupoAlimentar)
    {
        if (grupoAlimentar == null)
            throw new ArgumentNullException(nameof(grupoAlimentar));

        _dbContext.Set<GrupoAlimentar>().Add(grupoAlimentar);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeletarGrupoAlimentarAsync(GrupoAlimentar grupoAlimentar)
    {
        if (grupoAlimentar == null)
            throw new ArgumentNullException(nameof(grupoAlimentar));

        _dbContext.Set<GrupoAlimentar>().Remove(grupoAlimentar);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> AtualizarGrupoAlimentarAsync(GrupoAlimentar grupoAlimentar)
    {
        if (grupoAlimentar == null)
            throw new ArgumentNullException(nameof(grupoAlimentar));

        _dbContext.Entry(grupoAlimentar).State = EntityState.Modified;
        return await _dbContext.SaveChangesAsync() > 0;
    }
}
