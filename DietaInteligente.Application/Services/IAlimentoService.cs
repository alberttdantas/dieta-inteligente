using DietaInteligente.Application.InputModels;
using DietaInteligente.Application.ViewModels;

namespace DietaInteligente.Application.Services;

internal interface IAlimentoService
{
    Task<IEnumerable<AlimentoViewModel>> GetAllAlimentosAsync();
    Task<AlimentoViewModel> GetAlimentoByIdAsync(int alimentoId);
    Task<AlimentoViewModel> CreateAlimentoAsync(AlimentoInputModel alimentoInputModel);
    Task<AlimentoViewModel> UpdateAlimentoAsync(int alimentoId, AlimentoInputModel alimentoInputModel);
    Task<bool> DeleteAlimentoAsync(int alimentoId);
}
