
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Repositories;
using DietaInteligente.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DietaInteligente.Infrastructure.Repositories.InformacoesNutricionais;

public class InformacaoNutricionalRepository : IInformacaoNutricionalRepository
{
    private readonly DietaInteligenteDbContext _dbContext;

    public InformacaoNutricionalRepository(DietaInteligenteDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<InformacaoNutricional>> BuscarInformacoesNutricionaisAsync()
    {
        return await _dbContext.Set<InformacaoNutricional>().ToListAsync();
    }

    public async Task<InformacaoNutricional> BuscarInformacaoNutricionalAsync(int id)
    {
        if (id == null)
            throw new ArgumentNullException(nameof(id));

        return await _dbContext.Set<InformacaoNutricional>().FindAsync(id);
    }

    public async Task<bool> CriarInformacaoNutricionalAsync(InformacaoNutricional informacaoNutricional)
    {
        if (informacaoNutricional == null)
            throw new ArgumentNullException(nameof(informacaoNutricional));

        _dbContext.Set<InformacaoNutricional>().Add(informacaoNutricional);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeletarInformacaoNutricionalAsync(InformacaoNutricional informacaoNutricional)
    {
        if (informacaoNutricional == null)
            throw new ArgumentNullException(nameof(informacaoNutricional));

        _dbContext.Set<InformacaoNutricional>().Remove(informacaoNutricional);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> AtualizarInformacaoNutricionalAsync(InformacaoNutricional informacaoNutricional)
    {
        if (informacaoNutricional == null)
            throw new ArgumentNullException(nameof(informacaoNutricional));

        _dbContext.Entry(informacaoNutricional).State = EntityState.Modified;
        return await _dbContext.SaveChangesAsync() > 0;
    }
}
