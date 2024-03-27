
using DietaInteligente.Domain.Entities;

namespace DietaInteligente.Domain.Repositories;

public interface IInformacaoNutricionalRepository
{
    Task<IEnumerable<InformacaoNutricional>> BuscarInformacoesNutricionaisAsync();
    Task<InformacaoNutricional> BuscarInformacaoNutricionalAsync(int id);
    Task<bool> CriarInformacaoNutricional (InformacaoNutricional informacaoNutricional);
    Task<bool> AtualizarInformacaoNutricional(InformacaoNutricional informacaoNutricional);
    Task<bool> DeletarInformacaoNutricional(InformacaoNutricional informacaoNutricional);
}
