
using DietaInteligente.Domain.Entities;

namespace DietaInteligente.Domain.Repositories;

public interface IInformacaoNutricionalRepository
{
    Task<IEnumerable<InformacaoNutricional>> BuscarInformacoesNutricionaisAsync();
    Task<InformacaoNutricional> BuscarInformacaoNutricionalAsync(int id);
    Task<bool> CriarInformacaoNutricionalAsync (InformacaoNutricional informacaoNutricional);
    Task<bool> AtualizarInformacaoNutricionalAsync(InformacaoNutricional informacaoNutricional);
    Task<bool> DeletarInformacaoNutricionalAsync(InformacaoNutricional informacaoNutricional);
}
