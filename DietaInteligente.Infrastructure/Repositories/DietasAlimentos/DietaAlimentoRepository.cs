using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Repositories;
using DietaInteligente.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DietaInteligente.Infrastructure.Repositories
{
    public class DietaAlimentoRepository : IDietaAlimentoRepository
    {
        private readonly DietaInteligenteDbContext _dbContext;

        public DietaAlimentoRepository(DietaInteligenteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AssociarDietaAlimentoAsync(DietaAlimento dietaAlimento)
        {
            if (dietaAlimento == null)
                throw new ArgumentNullException(nameof(dietaAlimento));

            try
            {
                _dbContext.Set<DietaAlimento>().Add(dietaAlimento);
                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<DietaAlimento>> BuscarAlimentosPorDietaAsync(int id)
        {
            return await _dbContext.Set<DietaAlimento>()
                .Where(da => da.DietaId == id)
                .Include(da => da.Alimentos)
                .ToListAsync();
        }

        public async Task<IEnumerable<DietaAlimento>> BuscarDietasAlimentosAsync()
        {
            return await _dbContext.Set<DietaAlimento>()
                .Include(da => da.Alimentos)
                .ToListAsync();
        }

        public async Task<bool> DesassociarDietaAlimentoAsync(DietaAlimento dietaAlimento)
        {
            if (dietaAlimento == null)
                throw new ArgumentNullException(nameof(dietaAlimento));

            try
            {
                var existingAssociation = await _dbContext.Set<DietaAlimento>()
                    .FirstOrDefaultAsync(da => da.DietaId == dietaAlimento.DietaId && da.AlimentoId == dietaAlimento.AlimentoId);

                if (existingAssociation != null)
                    _dbContext.Set<DietaAlimento>().Remove(existingAssociation);
                    return await _dbContext.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
