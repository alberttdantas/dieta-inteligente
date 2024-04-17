
namespace DietaInteligente.Application.ViewModels;

public class DietaAlimentoViewModel
{
    public int DietaId { get; set; }
    public IEnumerable<AlimentoViewModel>? Alimentos { get; set; }
    public decimal? QuantidadedeGramas { get; set; }
}