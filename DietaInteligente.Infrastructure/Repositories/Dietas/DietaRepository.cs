
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Repositories;
using DietaInteligente.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DietaInteligente.Infrastructure.Repositories.Dietas;

public class DietaRepository : IDietaRepository
{
    private readonly DietaInteligenteDbContext _dbContext;

    public DietaRepository(DietaInteligenteDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Dieta>> BuscarDietasAsync()
    {
        return await _dbContext.Set<Dieta>().ToListAsync();
    }

    public async Task<Dieta> BuscarDietaAsync(int id)
    {
        if (id == null)
        {
            throw new ArgumentNullException(nameof(id));
        }

        return await _dbContext.Set<Dieta>().FindAsync(id);
    }

    public async Task<bool> CriarDietaAsync(Dieta dieta)
    {
        if (dieta == null)
        {
            throw new ArgumentNullException(nameof(dieta));
        }

        _dbContext.Set<Dieta>().Remove(dieta);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeletarDietaAsync(Dieta dieta)
    {
        if (dieta == null)
        {
            throw new ArgumentNullException(nameof(dieta));
        }

        _dbContext.Set<Dieta>().Remove(dieta);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> AtualizarDietaAsync(Dieta dieta)
    {
        if (dieta == null)
        {
            throw new ArgumentNullException(nameof(dieta));
        }

        _dbContext.Entry(dieta).State = EntityState.Modified;
        return await _dbContext.SaveChangesAsync() > 0;
    }
}
