using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Repositories;
using DietaInteligente.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DietaInteligente.Infrastructure.Repositories
{
    public class AlimentoRepository : IAlimentoRepository
    {
        private readonly DietaInteligenteDbContext _dbContext;

        public AlimentoRepository(DietaInteligenteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Alimento>> BuscarAlimentosAsync()
        {
            return await _dbContext.Alimentos
                .Include(a => a.InformacaoNutricional)
                .ToListAsync();
        }

        public async Task<Alimento> BuscarAlimentoAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return await _dbContext.Alimentos
                .Include(a => a.InformacaoNutricional)
                .FirstOrDefaultAsync(a => a.Id == id);

        }

        public async Task<bool> InserirAlimentoAsync(Alimento alimento)
        {
            if (alimento == null)
                throw new ArgumentNullException(nameof(alimento));

            _dbContext.Set<Alimento>().Add(alimento);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeletarAlimentoAsync(Alimento alimento)
        {
            if (alimento == null)
                throw new ArgumentNullException(nameof(alimento));

            _dbContext.Set<Alimento>().Remove(alimento);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> AtualizarAlimentoAsync(Alimento alimento)
        {
            if (alimento == null)
                throw new ArgumentNullException(nameof(alimento));

            _dbContext.Entry(alimento).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
